using Microsoft.EntityFrameworkCore;
using PensumProgresoAcademico.DAL;
using PensumProgresoAcademico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PensumProgresoAcademico.BLL
{
    public class MateriasBLL
    {
        public static bool Guardar(Materias materia)
        {
            if (!Existe(materia.Clave))
                return Insertar(materia);
            else
                return Modificar(materia);
        }

        public static bool Existe(string clave)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Materias.Any(m => m.Clave == clave);
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

        private static bool Insertar(Materias materia)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Materias.Add(materia);
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

        private static bool Modificar(Materias materia)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Entry(materia).State = EntityState.Modified;
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

        public static Materias Buscar(string clave)
        {
            Contexto contexto = new Contexto();
            Materias materia;

            try
            {
                materia = contexto.Materias.Find(clave);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return materia;
        }

        public static bool Eliminar(string clave)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var elemento = contexto.Materias.Find(clave);
                if(elemento != null)
                {
                    contexto.Materias.Remove(elemento);
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

        public static List<Materias> GetMaterias()
        {
            Contexto contexto = new Contexto();
            List<Materias> lista = new List<Materias>();

            try
            {
                lista = contexto.Materias.ToList();
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

        public static List<Materias> GetMaterias(Expression<Func<Materias, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Materias> lista = new List<Materias>();

            try
            {
                lista = contexto.Materias.Where(criterio).ToList();
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

        public static Materias ExisteMateria(string descripcion)
        {
            Contexto contexto = new Contexto();
            List<Materias> lista = new List<Materias>();
            Materias materia;

            try
            {
                lista = contexto.Materias.ToList();
                materia = lista.Find(m => m.Descripcion == descripcion);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return materia;
        }
    }
}
