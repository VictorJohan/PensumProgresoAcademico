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
        public static bool Guardar(Estudiantes estudiante)
        {
            if (!Existe(estudiante.Matricula))
                return Insertar(estudiante);
            else
                return Modificar(Restablecer(estudiante));
        }

        public static bool Existe(int matricula)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Estudiantes.Any(e => e.Matricula == matricula);
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

        private static bool Insertar(Estudiantes estudiante)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Estudiantes.Add(estudiante);
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

        private static bool Modificar(Estudiantes estudiante)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Entry(estudiante).State = EntityState.Modified;
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

        public static Estudiantes Buscar(int matricula)
        {
            Contexto contexto = new Contexto();
            Estudiantes estudiante;

            try
            {
                estudiante = contexto.Estudiantes.Find(matricula);
                if(estudiante != null) { estudiante = Actualizar(estudiante); }
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

        public static bool Eliminar(int matricula)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var elemento = contexto.Estudiantes.Find(matricula);
                if(elemento != null)
                {
                    contexto.Estudiantes.Remove(elemento);
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

        public static List<Estudiantes> GetEstudiantes()
        {
            Contexto contexto = new Contexto();
            List<Estudiantes> lista = new List<Estudiantes>();

            try
            {
                lista = contexto.Estudiantes.ToList();
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

        public static List<Estudiantes> GetEstudiantes(Expression<Func<Estudiantes, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Estudiantes> lista = new List<Estudiantes>();

            try
            {
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

        private static Estudiantes Restablecer(Estudiantes estudiantes)
        {
            estudiantes.CreditosPendientes = estudiantes.Pensum.PensumCreditos;
            estudiantes.MateriasPendientes = estudiantes.Pensum.TotalMaterias;
            estudiantes.HorasPracticasPendientes = estudiantes.Pensum.PensumHorasPracticas;
            estudiantes.HorasTeoricasPendientes = estudiantes.Pensum.PensumHorasTeoricas;

            return estudiantes;
        }

        private static Estudiantes Actualizar(Estudiantes estudiante)
        {
            List<Inscripciones> Aux = InscripcionesBLL.GetInscripciones();
            List<Materias> Aux2;
            foreach (var item in Aux)
            {
                estudiante.CreditosPendientes -= item.CreditosSelccionados;
                estudiante.MateriasPendientes -= item.CantidadMateria;
                Aux2 = InscripcionesBLL.GetInscripcionesMaterias(item.InscripcionId);
                foreach (var item2 in Aux2)
                {
                    estudiante.HorasPracticasPendientes -= item2.HorasPracticas;
                    estudiante.HorasTeoricasPendientes -= item2.HorasTeoricas;
                }
                
            }

            return estudiante;
        }
    }
}
