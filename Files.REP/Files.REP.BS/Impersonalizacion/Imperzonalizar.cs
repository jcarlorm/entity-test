using System;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace PELom.REP.BS.Impersonalizacion
{
    internal class Win32NativeMethods
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern int LogonUser(string lpszUserName,
            string lpszDomain,
            string lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            ref IntPtr phToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int DuplicateToken(IntPtr hToken,
            int impersonationLevel,
            ref IntPtr hNewToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool RevertToSelf();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);
    }
    public class Imperzonalizar : IDisposable
    {
        private WindowsImpersonationContext wic;
        private string tipoImpersonalizacion;
        private string tipoProveedorImpersonalizacion;
        /// <summary>
        ///     Libera la impersonalización
        /// </summary>
        public void Dispose()
        {
            UndoImpersonation();
        }

        /// <summary>
        ///     Inicializa la impersonalizacion con los parámetros indicados
        /// </summary>
        /// <param name="usuario">Usuario de Dominio</param>
        /// <param name="password">Password</param>
        /// <param name="dominio">Dominio</param>
        public void Impersonalizar(string usuario, string password, string dominio,string tipoImpersonalizacion,string tipoProveedorImpersonalizacion)
        {
            this.tipoImpersonalizacion = tipoImpersonalizacion;
            this.tipoProveedorImpersonalizacion = tipoProveedorImpersonalizacion;

            Impersonate(usuario, dominio, password);
        }

        /// <summary>
        ///     Método que realiza la impersonalización correspondiente
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="domainName"></param>
        /// <param name="password"></param>
        private void Impersonate(string userName, string domainName, string password)
        {
            UndoImpersonation();

            var logonToken = IntPtr.Zero;
            var logonTokenDuplicate = IntPtr.Zero;
            try
            {
                // revert to the application pool identity, saving the identity of the current requestor
                wic = WindowsIdentity.Impersonate(IntPtr.Zero);


                var tipoImpersonalizacion = 
                    int.Parse(this.tipoImpersonalizacion);

                var tipoProveedorImpersonalizacion =
                    int.Parse(this.tipoProveedorImpersonalizacion);

                if (Win32NativeMethods.LogonUser(userName,
                    domainName,
                    password,
                    tipoImpersonalizacion,
                    tipoProveedorImpersonalizacion,
                    ref logonToken) != 0)
                {
                    // 2 = SecurityIdentification
                    if (Win32NativeMethods.DuplicateToken(logonToken, 2, ref logonTokenDuplicate) != 0)
                    {
                        var wi = new WindowsIdentity(logonTokenDuplicate);
                        wi.Impersonate();
                        // discard the returned identity context (which is the context of the application pool)
                    }
                    else
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                else
                    throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            finally
            {
                if (logonToken != IntPtr.Zero)
                    Win32NativeMethods.CloseHandle(logonToken);

                if (logonTokenDuplicate != IntPtr.Zero)
                    Win32NativeMethods.CloseHandle(logonTokenDuplicate);
            }
        }

        /// <summary>
        ///     Método que reversa la impersonalización correspondiente
        /// </summary>
        private void UndoImpersonation()
        {
            // restore saved requestor identity
            if (wic != null)
                wic.Undo();
            wic = null;
        }
    }
}

