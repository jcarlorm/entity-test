using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace E2E.uitest
{
    /// <summary>
    /// Descripción resumida de CodedUITest1
    /// </summary>
    [CodedUITest]
    public class UITestLogin
    {
        public UITestLogin()
        {
        }

        [TestMethod]
        public void CodedUITestMethod1()
        {


            // Para generar código para esta prueba, seleccione "Generar código para prueba automatizada de IU" en el menú contextual y seleccione uno de los elementos de menú.
            this.UIMap.TestLogin();
            this.UIMap.Acepto();

            //WinEdit  uITxtNombreEdit = this.UIMap.UILoginWindow.UITxtNombreWindow.UITxtNombreEdit;
            //WinEdit uITxtPasswordEdit = this.UIMap.UILoginWindow.UITxtPasswordWindow.UITxtPasswordEdit;
            //WinButton uILoginButton = this.UIMap.UILoginWindow.UILoginWindow1.UILoginButton;
            //WinButton uIAceptarButton = this.UIMap.UIAceptarWindow.UIAceptarButton;

            //uITxtNombreEdit.Text = "Prueba";
            //uITxtPasswordEdit.SetFocus();
            //uITxtPasswordEdit.Text = "clave";
            //uILoginButton.SetFocus();

            //// Escribir '{Space}' en botón 'Login'
            //Keyboard.SendKeys(uILoginButton, "{space}", ModifierKeys.None);
            //// Clic 'Aceptar' botón
            //if (uIAceptarButton.TryFind())
            //{
            //    Assert.IsTrue(true);
            //}
            //Assert.IsTrue(false);


            //Mouse.Click(uIAceptarButton, new Point(28, 15));

        }

        #region Atributos de prueba adicionales

        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:

        ////Use TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // Para generar código para esta prueba, seleccione "Generar código para prueba automatizada de IU" en el menú contextual y seleccione uno de los elementos de menú.
        //}

        ////Use TestCleanup para ejecutar el código después de ejecutar cada prueba
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // Para generar código para esta prueba, seleccione "Generar código para prueba automatizada de IU" en el menú contextual y seleccione uno de los elementos de menú.
        //}

        #endregion

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }


  
}
