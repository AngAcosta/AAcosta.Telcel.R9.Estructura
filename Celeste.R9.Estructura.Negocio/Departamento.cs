using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.R9.Estructura.Negocio
{
    public class Departamento
    {
        //ML Departamento

        public int DepartamentoID { get; set; }

        public   string Descripcion { get; set; }

        public List<object> Departamentos { get; set; }

        //BL Departamento

        public static Result GetAll()
        {
            Result result = new Result();

            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.AAcostaEstructuraEntities context = new Telcel.R9.Estructura.AccesoDatos.AAcostaEstructuraEntities())
                {
                    var query = context.DepartamentoGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            Departamento departamento = new Departamento();

                            departamento.DepartamentoID= obj.DepartamentoID;
                            departamento.Descripcion = obj.Descripcion;

                            result.Objects.Add(departamento);
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