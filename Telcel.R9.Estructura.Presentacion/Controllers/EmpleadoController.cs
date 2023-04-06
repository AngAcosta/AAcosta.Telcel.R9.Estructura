using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Telcel.R9.Estructura.Presentacion.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        [HttpGet]
        public ActionResult GetAll()
        {
            Celeste.R9.Estructura.Negocio.Empleado empleado = new Celeste.R9.Estructura.Negocio.Empleado();
            Celeste.R9.Estructura.Negocio.Result result = Celeste.R9.Estructura.Negocio.Empleado.GetAll();

            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
                return View(empleado);
            }
            else
            {
                return View(empleado);
            }
        }

        [HttpPost]
        public ActionResult GetAll(Celeste.R9.Estructura.Negocio.Empleado empleado)
        {
            Celeste.R9.Estructura.Negocio.Result result = Celeste.R9.Estructura.Negocio.Empleado.GetNombre(empleado);
            Celeste.R9.Estructura.Negocio.Result resultPuesto = Celeste.R9.Estructura.Negocio.Puesto.GetAll();
            Celeste.R9.Estructura.Negocio.Result resultDepartamento = Celeste.R9.Estructura.Negocio.Departamento.GetAll();

            empleado.Puesto = new Celeste.R9.Estructura.Negocio.Puesto();
            empleado.Departamento = new Celeste.R9.Estructura.Negocio.Departamento();
            
            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
                empleado.Puesto.Puestos = resultPuesto.Objects;
                empleado.Departamento.Departamentos = resultDepartamento.Objects;
                return View(empleado);
            }
            else
            {
                return View(empleado);
            }
        }

        [HttpGet]
        public ActionResult Form(int? EmpleadoID)
        {
            Celeste.R9.Estructura.Negocio.Result resultPuesto = Celeste.R9.Estructura.Negocio.Puesto.GetAll();
            Celeste.R9.Estructura.Negocio.Result resultDepartamento = Celeste.R9.Estructura.Negocio.Departamento.GetAll();

            Celeste.R9.Estructura.Negocio.Empleado empleado = new Celeste.R9.Estructura.Negocio.Empleado();

            empleado.Puesto = new Celeste.R9.Estructura.Negocio.Puesto();
            empleado.Departamento = new Celeste.R9.Estructura.Negocio.Departamento();

            if (resultPuesto.Correct && resultDepartamento.Correct)
            {
                empleado.Puesto.Puestos = resultPuesto.Objects;
                empleado.Departamento.Departamentos = resultDepartamento.Objects;
            }
            if (EmpleadoID == null)
            {
                //add //Formulario vacio
                return View(empleado);
            }
            else
            {
            }
            return View();
        }

        [HttpPost]
        public ActionResult Form(Celeste.R9.Estructura.Negocio.Empleado empleado)
        {
            Celeste.R9.Estructura.Negocio.Result result = new Celeste.R9.Estructura.Negocio.Result(); 

            if (empleado.EmpleadoID == 0)
            {
                //add
                result = Celeste.R9.Estructura.Negocio.Empleado.Add(empleado);

                if (result.Correct)
                {
                    ViewBag.Message = "Se completo el Registro";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al Insertar el Registro";
                }
                return View("Modal");
            }
            else
            {
            }
            return View("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int EmpleadoID)
        {
            Celeste.R9.Estructura.Negocio.Result result = Celeste.R9.Estructura.Negocio.Empleado.Delete(EmpleadoID);

            if (result.Correct)
            {
                ViewBag.message = "se elimino el registro";
                return View("Modal");
            }
            else
            {
                ViewBag.message = "no se elimino el registro";
            }
            return View("Modal");
        }
    }
}