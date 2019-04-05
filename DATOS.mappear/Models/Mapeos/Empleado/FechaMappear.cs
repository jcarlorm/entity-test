using AutoMapper;

namespace DATOS.mappear.Models.Mapeos
{
    public class FechaMappear : IValueResolver<Empleado.Empleado, EmpleadoView.Empleado, string>
    {
        public string Resolve(Empleado.Empleado source, EmpleadoView.Empleado destination, string destMember, ResolutionContext context)
        {
            return source.StartDate.ToShortDateString();
        }
    }
}
