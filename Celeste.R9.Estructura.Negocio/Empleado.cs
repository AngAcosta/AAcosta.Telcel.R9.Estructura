using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.R9.Estructura.Negocio
{
    public class Empleado
    {
        // ML Empleado

        public int EmpleadoID { get; set; }

        public string Nombre { get; set; }

        public Puesto Puesto { get; set; }

        public Departamento Departamento { get; set; }

        public List<object> Empleados { get; set; }

        //BL Empleado

        public static Result GetAll()
        {
            Result result = new Result();

            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.AAcostaEstructuraEntities context = new Telcel.R9.Estructura.AccesoDatos.AAcostaEstructuraEntities())
                {
                    var query = context.EmpleadoGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            Empleado empleado = new Empleado();

                            empleado.EmpleadoID = obj.EmpleadoID;
                            empleado.Nombre = obj.Nombre;

                            empleado.Puesto = new Puesto();
                            empleado.Puesto.PuestoID = obj.PuestoID.Value;
                            empleado.Puesto.Descripcion = obj.DescripcionPuesto;

                            empleado.Departamento = new Departamento();
                            empleado.Departamento.DepartamentoID = obj.DepartamentoID.Value;
                            empleado.Departamento.Descripcion = obj.DescripcionDepartamento; ;

                            result.Objects.Add(empleado);
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

        public static Result Add(Empleado empleado)
        {

            Result result = new Result();

            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.AAcostaEstructuraEntities context = new Telcel.R9.Estructura.AccesoDatos.AAcostaEstructuraEntities())
                {
                    int query = context.EmpleadoAdd(empleado.Nombre, empleado.Puesto.PuestoID, empleado.Departamento.DepartamentoID);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se Inserto el Empleado";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static Result Delete(int EmpleadoID)
        {
            Result result = new Result();

            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.AAcostaEstructuraEntities context = new Telcel.R9.Estructura.AccesoDatos.AAcostaEstructuraEntities())
                {
                    var query = context.EmpleadoDelete(EmpleadoID);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se Elimino el Elpleado";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static Result GetNombre(Empleado empleado)
        {
            Result result = new Result();

            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.AAcostaEstructuraEntities context = new Telcel.R9.Estructura.AccesoDatos.AAcostaEstructuraEntities())
                {
                    var query = context.EmpleadoGetNombre(empleado.Nombre).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            empleado = new Empleado();

                            empleado.EmpleadoID = obj.EmpleadoID;
                            empleado.Nombre = obj.Nombre;

                            empleado.Puesto = new Puesto();
                            empleado.Puesto.PuestoID = obj.PuestoID.Value;
                            empleado.Puesto.Descripcion = obj.DescripcionPuesto;

                            empleado.Departamento = new Departamento();
                            empleado.Departamento.DepartamentoID = obj.DepartamentoID.Value;
                            empleado.Departamento.Descripcion = obj.DescripcionDepartamento; ;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}