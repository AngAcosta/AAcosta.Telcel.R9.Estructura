using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.R9.Estructura.Negocio
{
    public class Puesto
    {
        //ML Puesto

        public int PuestoID { get; set; }

        public string Descripcion { get; set; }

        public List<object> Puestos { get; set; }

        //BL Puesto

        public static Result GetAll()
        {
            Result result = new Result();

            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.AAcostaEstructuraEntities context = new Telcel.R9.Estructura.AccesoDatos.AAcostaEstructuraEntities())
                {
                    var query = context.PuestoGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            Puesto puesto = new Puesto();

                            puesto.PuestoID = obj.PuestoID;
                            puesto.Descripcion = obj.Descripcion;

                            result.Objects.Add(puesto);
                        }
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Exception = ex;

            }
            return result;
        }
    }
}