﻿using Microsoft.EntityFrameworkCore;
using PensumProgresoAcademico.DAL;
using PensumProgresoAcademico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PensumProgresoAcademico.BLL
{
    public class InscripcionesBLL
    {
        public static bool Guardar(Inscripciones inscripcion)
        {
            if (!Existe(inscripcion.InscripcionId))
                return Insertar(inscripcion);
            else
                return Modificar(inscripcion);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Inscripciones.Any(i => i.InscripcionId == id);
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

        private static bool Insertar(Inscripciones inscripcion)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Inscripciones.Add(inscripcion);
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

        private static bool Modificar(Inscripciones inscripcion)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM InscripcionesDetalle Where InscripcionId={inscripcion.InscripcionId}");
                foreach (var item in inscripcion.InscripcionesDetalles)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                contexto.Entry(inscripcion).State = EntityState.Modified;
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

        public static Inscripciones Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Inscripciones inscripcion;

            try
            {
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

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var elemento = contexto.Inscripciones.Find(id);
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

        public static List<Inscripciones> GetInscripciones()
        {
            Contexto contexto = new Contexto();
            List<Inscripciones> lista = new List<Inscripciones>();

            try
            {
                lista = contexto.Inscripciones.ToList();
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

        public static List<Inscripciones> GetInscripciones(Expression<Func<Inscripciones, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Inscripciones> lista = new List<Inscripciones>();

            try
            {
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
    }
}
