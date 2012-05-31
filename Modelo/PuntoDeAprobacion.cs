// File:    PuntoDeAprobacion.cs
// Author:  vsis
// Created: sábado, 26 de mayo de 2012 23:57:53
// Purpose: Definition of Class PuntoDeAprobacion

using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Transaction;

namespace SIMO_CORE.Modelo
{
    public class PuntoDeAprobacion
    {
        virtual public int idPuntoAprobacion { get; set; }
        virtual public SistemaObjetivo sistemaPunto { get; set; }
        virtual public int posicionPuntoAprobacion { get; set; }

        /* se sobreescriben Equals y GetHashCode, para que el sistema entienda que dos objetos son el mismo,
       * incluso si están en posiciones de memoria distintos
       * */
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            else
            {
                PuntoDeAprobacion aux = obj as PuntoDeAprobacion;
                if (aux == null)
                    return false;
                return aux.idPuntoAprobacion.Equals(this.idPuntoAprobacion);
            }
        }

        public override int GetHashCode()
        {
            return idPuntoAprobacion;
        }

        //TODO LIST: REVISAR MAPEO Y QUERY
        public static IList<PuntoDeAprobacion> Listar()
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            IQuery query = sesion.CreateQuery("from PuntoDeAprobacion");
            IList<PuntoDeAprobacion> resultado = query.List<PuntoDeAprobacion>();
            tx.Commit();
            return resultado;
        }
    }
}