// File:    PuntoDeAprobacion.cs
// Author:  vsis
// Created: sábado, 26 de mayo de 2012 23:57:53
// Purpose: Definition of Class PuntoDeAprobacion

using System;

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
    }
}