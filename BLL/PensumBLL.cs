using Microsoft.EntityFrameworkCore;
using PensumProgresoAcademico.DAL;
using PensumProgresoAcademico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace PensumProgresoAcademico.BLL
{
    public class PensumBLL
    {
        //Guarda o modifica el registro dependiendo de si esta o no registrado en la base de datos.
        public static bool Guardar(Pensum pensum)
        {
            if (!Existe(pensum.PensumId))
                return Insertar(pensum);//Si no existe no inserta.
            else
                return Modificar(pensum);//Si existe lo modifica.
        }

        //Verifica si existe el registro en la base de datos.
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Pensum.Any(p => p.PensumId == id);//Busca alguna coicidencia en la tabla y devuelve true o false.
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
        private static bool Insertar(Pensum pensum)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                //Evita que se dupliquen los registros.
                foreach (var item in pensum.PensumDetalles)
                {
                    contexto.Entry(item.Materia).State = EntityState.Modified;
                }
                contexto.Pensum.Add(pensum);//Agrega el registro.
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

        //Si existe el registro lo modifica.
        private static bool Modificar(Pensum pensum)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                //Se elimina el detalle del pensum para luego volver a agregarlo pero con los cambios realizados.
                contexto.Database.ExecuteSqlRaw($"Delete FROM PensumDetalle Where PensumId={pensum.PensumId}");
                foreach (var item in pensum.PensumDetalles)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                contexto.Entry(pensum).State = EntityState.Modified;//Modifica el registro.
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

        //Busca el registro correspondiente al Id.
        public static Pensum Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Pensum pensum;

            try
            {
                //Busca el pensum incluyendo el detalle y las materias que hay en el.
                pensum = contexto.Pensum.Where(p => p.PensumId == id).Include(d => d.PensumDetalles).
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

            return pensum;
        }

        //Elimina el registro correspondiente al Id.
        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var elemento = contexto.Pensum.Find(id);//Busca el registro.
                if (elemento != null)//Si la busqueda arroja un objeto diferente de null lo elimina.
                {
                    contexto.Entry(elemento).State = EntityState.Deleted;//Elimina
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
        public static List<Pensum> GetPensum()
        {
            Contexto contexto = new Contexto();
            List<Pensum> lista = new List<Pensum>();

            try
            {
                lista = contexto.Pensum.ToList();//Este metodo convierte la tabla en un List y lista se iguala al List.

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
        public static List<Pensum> GetPensum(Expression<Func<Pensum, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Pensum> lista = new List<Pensum>();

            try
            {
                //Todos los registros que coincidan con el criterio se convierten en un List.
                lista = contexto.Pensum.Where(criterio).ToList();
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

        //Retorna en un List ordenado alfabeticamente todas las materias de un pensum.
        public static List<Materias> GetPensumMaterias(int id)
        {
            Contexto contexto = new Contexto();
            Pensum pensum = new Pensum();
            List<Materias> lista = new List<Materias>();

            try
            {
                if(id != 0)
                {
                    //Busca el pensum
                    pensum = contexto.Pensum.Where(p => p.PensumId == id).Include(d => d.PensumDetalles).
                    ThenInclude(m => m.Materia).SingleOrDefault();
                    foreach (var item in pensum.PensumDetalles)
                    {
                        lista.Add(item.Materia);//Agrega todas las materias en el List.
                    }
                    lista.Sort((x, y) => x.Descripcion.CompareTo(y.Descripcion));//Ordena la lista.
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

    }
}
