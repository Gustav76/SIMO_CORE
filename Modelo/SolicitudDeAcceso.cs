// File:    SolicitudDeAcceso.cs
// Author:  vsis
// Created: sábado, 26 de mayo de 2012 23:57:53
// Purpose: Definition of Class SolicitudDeAcceso

using System;

namespace SIMO_CORE.Modelo
{
    public class SolicitudDeAcceso
    {
        virtual public int idSolicitud { get; set; }
        virtual public Usuario usuarioSolicitud { get; set; }
        virtual public PuntoDeAprobacion puntoSolicitud { get; set; }
        virtual public short estadoSolicitud { get; set; }
        virtual public DateTime fechaSolicitud { get; set; }

        /* se sobreescriben Equals y GetHashCode, para que el sistema entienda que dos objetos son el mismo,
        * incluso si están en posiciones de memoria distintos
        * */
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            else
            {
                SolicitudDeAcceso aux = obj as SolicitudDeAcceso;
                if (aux == null)
                    return false;
                return aux.idSolicitud.Equals(this.idSolicitud);
            }
        }

        public override int GetHashCode()
        {
            return idSolicitud;
        }
    }
}