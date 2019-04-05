using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DATOS.mappear.Models.Empleado;
using Empleado = DATOS.mappear.Models.Empleado.Empleado;
using EmpleadoView = DATOS.mappear.Models.EmpleadoView.Empleado;

namespace DATOS.mappear
{
    public class Base
    {

        public Base()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Empleado, EmpleadoView>()
                    .ForMember(ev => ev.Address,
                               m => m.MapFrom(a => a.Address.City + ", " +
                                                   a.Address.Street + " " +
                                                   a.Address.Number)
                              )
                   .ForMember(dest => dest.Gender,
                               m => m.MapFrom<Models.Mapeos.GeneroMappear>())
                   .ForMember(dest => dest.StartDate, m => m.MapFrom<Models.Mapeos.FechaMappear>());
            });
        }

        public void MapeoBasico()
        {
            Empleado employee = new Empleado
            {
                Name = "John SMith",
                Email = "john@codearsenal.net",
                Address = new Address
                {
                    Country = "USA",
                    City = "New York",
                    Street = "Wall Street",
                    Number = 7
                },
                Position = "Manager",
                Gender = true,
                Age = 35,
                YearsInCompany = 5,
                StartDate = new DateTime(2007, 11, 2)
            };

            var model = Mapper.Map<EmpleadoView>(employee);
        }
    }
}
