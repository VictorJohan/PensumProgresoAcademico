using Microsoft.EntityFrameworkCore;
using PensumProgresoAcademico.DAL;
using PensumProgresoAcademico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows;

namespace PensumProgresoAcademico.BLL
{
    public class EstudiantesBLL
    {
        //Guarda o modifica el registro dependiendo de si esta o no registrado en la base de datos.
        public static bool Guardar(Estudiantes estudiante)
        {
            if (!Existe(estudiante.Matricula))
                return Insertar(estudiante);//Si no existe no inserta.
            else
                return Modificar(Restablecer(estudiante));//Si existe lo modifica.
        }

        //Verifica si existe el registro en la base de datos.
        public static bool Existe(int matricula)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Estudiantes.Any(e => e.Matricula == matricula);//Busca alguna coicidencia en la tabla y devuelve true o false.
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();//Cierra el contexto.
            }

            return ok;
        }

        //Inserta un nuevo registro en la base de datos.
        private static bool Insertar(Estudiantes estudiante)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Estudiantes.Add(estudiante);//Agrega el registro.
                ok = contexto.SaveChanges() > 0;//Guarda los cambios y devuelve un bool.
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        //Si existe el registro lo modifica.
        private static bool Modificar(Estudiantes estudiante)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Entry(estudiante).State = EntityState.Modified;//El registro se envia a la tabla para sustituir al anterior.
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        //Busca el registro correspondiente a la matricula.
        public static Estudiantes Buscar(int matricula)
        {
            Contexto contexto = new Contexto();
            Estudiantes estudiante;

            try
            {
                estudiante = contexto.Estudiantes.Find(matricula);//Busca el registro.
                //Si es diferente a null envia el registro a la funcion Actualizar para retornar el regigistro con los calculos actualizados.
                if (estudiante != null) { estudiante = Actualizar(estudiante); }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return estudiante;
        }

        //Elimina el registro correspondiente a la matricula.
        public static bool Eliminar(int matricula)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var elemento = contexto.Estudiantes.Find(matricula);//Busca el registro.
                if (elemento != null)//Si la busqueda arroja un objeto diferente de null lo elimina.
                {
                    contexto.Estudiantes.Remove(elemento);//Elimina
                    ok = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        //Retorna todos los registros de la tabla.
        public static List<Estudiantes> GetEstudiantes()
        {
            Contexto contexto = new Contexto();
            List<Estudiantes> lista = new List<Estudiantes>();

            try
            {
                lista = contexto.Estudiantes.ToList();//Este metodo convierte la tabla en un List y lista se iguala al List.
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        //Se retornan todos los registros que coicidan con el criterio.
        public static List<Estudiantes> GetEstudiantes(Expression<Func<Estudiantes, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Estudiantes> lista = new List<Estudiantes>();

            try
            {
                //Todos los registros que coincidan con el criterio se convierten en un List.
                lista = contexto.Estudiantes.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        //Restablece los datos del esstudiante con excepcion del nombre en caso de un cambio de pensum.
        private static Estudiantes Restablecer(Estudiantes estudiantes)
        {
            var aux = Buscar(estudiantes.Matricula);//Busca el estudiante para obtener el Id del pensum asignado.
            if(aux.PensumId != estudiantes.PensumId)//Si el Id del pensum es diferente significa que el estudiante cambio de pensum
            {                                      //Y se procedera modificar el registro y a eliminar las inscripciones.
                Modificar(estudiantes);
                EliminarInscripciones(estudiantes.Matricula);
            }
            else//Aqui se restablecen los creditos, materias, horas practicas y las horas teoricas pendintes
            {//Esto se hace con el objetivo de reducir el margen de error a la hora de calcular los pendientes.
                estudiantes.CreditosPendientes = estudiantes.Pensum.PensumCreditos;
                estudiantes.MateriasPendientes = estudiantes.Pensum.TotalMaterias;
                estudiantes.HorasPracticasPendientes = estudiantes.Pensum.PensumHorasPracticas;
                estudiantes.HorasTeoricasPendientes = estudiantes.Pensum.PensumHorasTeoricas;
            }
            

            return estudiantes;
        }

        //Hace los calculos para mostrar los pendientes que realmente hacen falta.
        private static Estudiantes Actualizar(Estudiantes estudiante)
        {
            //Busca todas las inscripciones referentes al pensum del estudiante.
            List<Inscripciones> Aux = InscripcionesBLL.GetInscripciones(i => i.Estudiante.PensumId == estudiante.PensumId);
            List<Materias> Aux2;

            foreach (var item in Aux)
            {//Se le restan los creditos y las materias pendientes al estudiante.
                estudiante.CreditosPendientes -= item.CreditosSelccionados;
                estudiante.MateriasPendientes -= item.CantidadMateria;
                Aux2 = InscripcionesBLL.GetInscripcionesMaterias(item.InscripcionId);//Se buscan todas las materias selecionadas en la inscripcion.

                foreach (var item2 in Aux2)
                {
                    //Se le restan las horas practicas y horas teoricas pendientes al estudiante.
                    estudiante.HorasPracticasPendientes -= item2.HorasPracticas;
                    estudiante.HorasTeoricasPendientes -= item2.HorasTeoricas;
                }
                
            }

            return estudiante;
        }

        //Elimina todas las inscripciones relacionadas a un estudiante.
        private static void EliminarInscripciones(int id)
        {
            List<Inscripciones> inscripciones = InscripcionesBLL.GetInscripciones(i => i.Matricula == id);
            foreach (var item in inscripciones)
            {
                InscripcionesBLL.Eliminar(item.InscripcionId);
            }
        }
    }
}
