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
    public class InscripcionesBLL
    {
        //Guarda o modifica el registro dependiendo de si esta o no registrado en la base de datos.
        public static bool Guardar(Inscripciones inscripcion)
        {
            if (!Existe(inscripcion.InscripcionId))//Si no existe no inserta.
                return Insertar(inscripcion);
            else
                return Modificar(inscripcion);//Si existe lo modifica.
        }

        //Verifica si existe el registro en la base de datos.
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Inscripciones.Any(i => i.InscripcionId == id);//Busca alguna coicidencia en la tabla y devuelve true o false.
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
        private static bool Insertar(Inscripciones inscripcion)
        {
            Contexto contexto = new Contexto();
            bool ok = false;
            
            try
            {
                //Esto se coloca para evitar que los registros se dupliquen.
                foreach (var item in inscripcion.InscripcionesDetalles)
                {
                    contexto.Entry(inscripcion.Estudiante).State = EntityState.Modified;
                    contexto.Entry(item.Materia).State = EntityState.Modified;
                }

                contexto.Inscripciones.Add(inscripcion);//Agrega el registro.
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
        private static bool Modificar(Inscripciones inscripcion)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                //Se elimina el detalle de la inscripcion para luego volver a agregarlo pero con los cambios realizados.
                contexto.Database.ExecuteSqlRaw($"Delete FROM InscripcionesDetalle Where InscripcionId={inscripcion.InscripcionId}");
                foreach (var item in inscripcion.InscripcionesDetalles)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(inscripcion).State = EntityState.Modified;//Se modifica el registro.
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

        //Busca el registro mediante el Id
        public static Inscripciones Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Inscripciones inscripcion;

            try
            {
                //Busca el registro y se incluye el detalle y la materia del detalle.
                inscripcion = contexto.Inscripciones.Where(i => i.InscripcionId == id).Include(d => d.InscripcionesDetalles).
                    ThenInclude(m => m.Materia).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return inscripcion;
        }

        //Elimina el registro mediante el Id.
        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var elemento = contexto.Inscripciones.Find(id);//Busca el registro.
                if(elemento != null)//Si la busqueda arroja un objeto diferente de null lo elimina.
                {
                    contexto.Entry(elemento).State = EntityState.Deleted;//Elimina.
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
        public static List<Inscripciones> GetInscripciones()
        {
            Contexto contexto = new Contexto();
            List<Inscripciones> lista = new List<Inscripciones>();

            try
            {
                lista = contexto.Inscripciones.ToList();//Este metodo convierte la tabla en un List y lista se iguala al List.
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
        public static List<Inscripciones> GetInscripciones(Expression<Func<Inscripciones, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Inscripciones> lista = new List<Inscripciones>();

            try
            {
                //Todos los registros que coincidan con el criterio se convierten en un List.
                lista = contexto.Inscripciones.Where(criterio).ToList();
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

        //Retorna un List con todas las materias de una inscripcion.
        public static List<Materias> GetInscripcionesMaterias(int id)
        {
            Contexto contexto = new Contexto();
            Inscripciones inscripcion = new Inscripciones();
            List<Materias> lista = new List<Materias>();

            try
            {
                if (id != 0)
                {
                    //Busca la isncripcion
                    inscripcion = contexto.Inscripciones.Where(p => p.InscripcionId == id).Include(d => d.InscripcionesDetalles).
                    ThenInclude(m => m.Materia).SingleOrDefault();
                    foreach (var item in inscripcion.InscripcionesDetalles)
                    {
                        lista.Add(item.Materia);//Se agregan las materias de la inscripcion.
                    }
                    
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

            return lista;
        }

        //Verifica si la materia ya fue inscrita por el estudiante y devuelve true en caso de que si y false en caso de que no.
        public static bool MateriaInscrita(string clave, int matricula)
        {
            Contexto contexto = new Contexto();
            bool ok = false;
            List<Inscripciones> inscripciones = new List<Inscripciones>();

            try
            {
                //Busca todas las inscripciones del estudiante
                inscripciones = contexto.Inscripciones.Where(i => i.Matricula == matricula).Include(d => d.InscripcionesDetalles).
                    ThenInclude(m => m.Materia).ToList();
                foreach (var aux in inscripciones)
                {
                    foreach (var aux2 in aux.InscripcionesDetalles)
                    {
                        if(clave == aux2.Clave) { ok = true; }//Compara la clave pasada por parametro con las claves que hay en la inscripcion.
                    }
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
    }
}
