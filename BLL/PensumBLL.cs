using Microsoft.EntityFrameworkCore;
using PensumProgresoAcademico.DAL;
using PensumProgresoAcademico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Media;

namespace PensumProgresoAcademico.BLL
{
    public class PensumBLL
    {
        public static bool Guardar(Pensum pensum)
        {
            if (!Existe(pensum.PensumId))
                return Insertar(pensum);
            else
                return Modificar(pensum);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Pensum.Any(p => p.PensumId == id);
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

        private static bool Insertar(Pensum pensum)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Pensum.Add(pensum);
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

        private static bool Modificar(Pensum pensum)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM PensumDetalle Where PensumId={pensum.PensumId}");
                foreach (var item in pensum.PensumDetalles)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                contexto.Entry(pensum).State = EntityState.Modified;
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

        public static Pensum Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Pensum pensum;

            try
            {
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

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var elemento = contexto.Pensum.Find(id);
                if(elemento != null)
                {
                    contexto.Entry(elemento).State = EntityState.Deleted;
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

        public static List<Pensum> GetPensum()
        {
            Contexto contexto = new Contexto();
            List<Pensum> lista = new List<Pensum>();

            try
            {
                lista = contexto.Pensum.ToList();
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

        public static List<Pensum> GetPensum(Expression<Func<Pensum, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Pensum> lista = new List<Pensum>();

            try
            {
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
    }
}
