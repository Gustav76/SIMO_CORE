// File:    DetalleIdentidadSistemaObjetivo.cs
// Author:  vsis
// Created: sábado, 26 de mayo de 2012 23:57:53
// Purpose: Definition of Class DetalleIdentidadSistemaObjetivo

using System;
using System.Collections.Generic;
using NHibernate;

namespace SIMO_CORE.Modelo
{
    public class DetalleIdentidadSistemaObjetivo
    {
        virtual public int idDetalle { get; set; }
        virtual public Identidad identidadDetalle { get; set; }
        virtual public SistemaObjetivo sistemaDetalle { get; set; }

        /* se sobreescriben Equals y GetHashCode, para que el sistema entienda que dos objetos son el mismo,
       * incluso si están en posiciones de memoria distintos
       * */
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            else
            {
                DetalleIdentidadSistemaObjetivo aux = obj as DetalleIdentidadSistemaObjetivo;
                if (aux == null)
                    return false;
                return aux.idDetalle.Equals(this.idDetalle);
            }
        }

        public override int GetHashCode()
        {
            return idDetalle;
        }

        /* Devuelve todos los detalles del sistema */
        public static IList<DetalleIdentidadSistemaObjetivo> Listar()
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            IQuery query = sesion.CreateQuery("from DetalleIdentidadSistemaObjetivo");
            IList<DetalleIdentidadSistemaObjetivo> resultado = query.List<DetalleIdentidadSistemaObjetivo>();
            tx.Commit();;
            return resultado;
        }

        /* Devuelve los detalles de una determinada identidad */
        public static IList<DetalleIdentidadSistemaObjetivo> ListarPorIdentidad(int idIdentidad)
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            IQuery query = sesion.CreateQuery("from DetalleIdentidadSistemaObjetivo where identidadDetalle=" + idIdentidad);
            IList<DetalleIdentidadSistemaObjetivo> resultado = query.List<DetalleIdentidadSistemaObjetivo>();
            tx.Commit();
            return resultado;
        }

        /* Devuelve los detalles de un determinado sistema */
        public static IList<DetalleIdentidadSistemaObjetivo> ListarPorSistema(int idSistemaObjetivo)
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            IQuery query = sesion.CreateQuery("from DetalleIdentidadSistemaObjetivo where sistemaDetalle=" + idSistemaObjetivo);
            IList<DetalleIdentidadSistemaObjetivo> resultado = query.List<DetalleIdentidadSistemaObjetivo>();
            tx.Commit();
            return resultado;
        }

        /* Devuelve los detalles de una determinada identidad que se relacionen con un determinado sistema */
        public static IList<DetalleIdentidadSistemaObjetivo> ListarPorIdentidadSistema(int idIdentidad, int idSistemaObjetivo)
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            IQuery query = sesion.CreateQuery(
                "from DetalleIdentidadSistemaObjetivo where identidadDetalle=" + idIdentidad + 
                " and sistemaDetalle=" + idSistemaObjetivo);
            IList<DetalleIdentidadSistemaObjetivo> resultado = query.List<DetalleIdentidadSistemaObjetivo>();
            tx.Commit();
            return resultado;
        }

        /* Guarda un nuevo detalle
         * debe tener un id = 0*/
        public virtual void Guardar()
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            sesion.Save(this);
            tx.Commit();
            sesion.Close();
        }

        /*Updatea un detalle existente
         * debe tener id != 0 */
        public virtual void Actualizar()
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            sesion.Update(this);
            tx.Commit();
            sesion.Close();
        }

        /* Elimina un detalle */
        public virtual void Eliminar()
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            sesion.Delete(this);
            tx.Commit();
            sesion.Close();
        }
    }
}