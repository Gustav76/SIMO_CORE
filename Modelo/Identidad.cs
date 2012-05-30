// File:    Identidad.cs
// Author:  vsis
// Created: sábado, 26 de mayo de 2012 23:57:53
// Purpose: Definition of Class Identidad

using System;
using System.Collections.Generic;
using NHibernate;

namespace SIMO_CORE.Modelo
{
    public class Identidad
    {
        virtual public int idIdentidad { get; set; }
        virtual public Usuario usuarioIdentidad { get; set; }
        virtual public string nombreIdentidad { get; set; }
        virtual public string claveIdentidad { get; set; }  /* usuario y clave para los SO */

        /* se sobreescriben Equals y GetHashCode, para que el sistema entienda que dos objetos son el mismo,
       * incluso si están en posiciones de memoria distintos
       * */
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            else
            {
                Identidad aux = obj as Identidad;
                if (aux == null)
                    return false;
                return aux.idIdentidad.Equals(this.idIdentidad);
            }
        }

        public override int GetHashCode()
        {
            return idIdentidad;
        }

        /* Devuelve una lista con todas las identidades del sistema */
        public static IList<Identidad> Listar()
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            IQuery query = sesion.CreateQuery("from Identidad");
            IList<Identidad> resultado = query.List<Identidad>();
            tx.Commit();
            return resultado;
        }

        /* Devuelve una lista con todas las identidades del usuario objetivo */
        public static IList<Identidad> Listar(int idUsuario)
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            IQuery query = sesion.CreateQuery("from Identidad where usuarioIdentidad=" + idUsuario);
            IList<Identidad> resultado = query.List<Identidad>();
            tx.Commit();
            return resultado;
        }

        /* Guarda una identidad nueva en la base de datos */
        /* el id debe ser 0 */
        public virtual void Guardar()
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            sesion.Save(this);
            tx.Commit();
            sesion.Close();
        }

        /*Updatea una identidad existente en la base de datos */
        /* el id debe ser distinto de 0 */
        public virtual void Actualizar()
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            sesion.Update(this);
            tx.Commit();
            sesion.Close();
        }

        /* Elimina una identidad */
        public virtual void Eliminar()
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            sesion.Delete(this);
            tx.Commit();
            sesion.Close();
        }

        /* Obtener a partir de una id */
        public static Identidad ObtenerPorId(int id)
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            Identidad identidad = sesion.Get<Identidad>(id);
            tx.Commit();
            sesion.Close();
            return identidad;
        }
    }
}