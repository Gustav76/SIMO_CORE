// File:    SistemaObjetivo.cs
// Author:  vsis
// Created: sábado, 26 de mayo de 2012 23:57:53
// Purpose: Definition of Class SistemaObjetivo

using System;
using System.Collections.Generic;
using NHibernate;

namespace SIMO_CORE.Modelo
{
    public class SistemaObjetivo
    {
        virtual public int idSistemaObjetivo { get; set; }
        virtual public string nombreSistemaObjetivo { get; set; }
        virtual public string direccionSistemaObjetivo { get; set; }

        /* se sobreescriben Equals y GetHashCode, para que el sistema entienda que dos objetos son el mismo,
        * incluso si están en posiciones de memoria distintos
        * */
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            else
            {
                SistemaObjetivo aux = obj as SistemaObjetivo;
                if (aux == null)
                    return false;
                return aux.idSistemaObjetivo.Equals(this.idSistemaObjetivo);
            }
        }

        public override int GetHashCode()
        {
            return idSistemaObjetivo;
        }

        /* Devuelve una lista con todos los sistemas objetivos */
        public static IList<SistemaObjetivo> Listar()
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            IQuery query = sesion.CreateQuery("from SistemaObjetivo");
            IList<SistemaObjetivo> resultado = query.List<SistemaObjetivo>();
            tx.Commit();
            return resultado;
        }

        /* Un SO nuevo es alamcenado en la base de datos
         * debe tener una id=0 */
        public virtual void Guardar()
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            sesion.Save(this);
            tx.Commit();
            sesion.Close();
        }

        /* El SO existente es updateado en la base de datos
         * debe tener un id != 0 */
        public virtual void Actualizar()
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            sesion.Update(this);
            tx.Commit();
            sesion.Close();
        }

        /* Elimina un sistema objetivo */
        public virtual void Eliminar()
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            sesion.Delete(this);
            tx.Commit();
            sesion.Close();
        }

        /* Obtener sistema por id */
        public virtual SistemaObjetivo ObtenerPorId(int id)
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            SistemaObjetivo sis = sesion.Get<SistemaObjetivo>(id);
            tx.Commit();
            sesion.Close();
            return sis;
        }
    }
}