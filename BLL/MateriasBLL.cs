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
        //Guarda o modifica el registro dependiendo de si esta o no registrado en la base de datos.
        public static bool Guardar(Materias materia)
        {
            if (!Existe(materia.Clave))
                return Insertar(materia);//Si no existe no inserta.
            else
                return Modificar(materia);//Si existe lo modifica.
        }

        //Verifica si existe el registro en la base de datos.
        public static bool Existe(string clave)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Materias.Any(m => m.Clave == clave);//Busca alguna coicidencia en la tabla y devuelve true o false.
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
        private static bool Insertar(Materias materia)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Materias.Add(materia);//Agrega el registro.
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
        private static bool Modificar(Materias materia)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Entry(materia).State = EntityState.Modified;//El registro se envia a la tabla para sustituir al anterior.
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

        //Busca el registro correspondiente a la clave.
        public static Materias Buscar(string clave)
        {
            Contexto contexto = new Contexto();
            Materias materia;
            try
            {
                materia = contexto.Materias.Find(clave);//Busca el registro en la base de datos.
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

        //Elimina el registro correspondiente a la clave.
        public static bool Eliminar(string clave)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var elemento = contexto.Materias.Find(clave);//Busca el registro.
                if (elemento != null)//Si la busqueda arroja un objeto diferente de null lo elimina.
                {
                    contexto.Materias.Remove(elemento);//Elimina.
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
        public static List<Materias> GetMaterias()
        {
            Contexto contexto = new Contexto();
            List<Materias> lista = new List<Materias>();

            try
            {
                lista = contexto.Materias.ToList();
                lista.Sort((x, y) => x.Descripcion.CompareTo(y.Descripcion));//Ordena lista
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
        public static List<Materias> GetMaterias(Expression<Func<Materias, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Materias> lista = new List<Materias>();

            try
            {
                //Todos los registros que coincidan con el criterio se convierten en un List.
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

        //Verifica que exista la materia
        public static Materias ExisteMateria(string descripcion)
        {
            Contexto contexto = new Contexto();
            List<Materias> lista = new List<Materias>();
            Materias materia;
            try
            {
                lista = contexto.Materias.ToList();
                materia = lista.Find(m => m.Descripcion == descripcion);//Si hay un aconsidencia la guarda en materia.

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
