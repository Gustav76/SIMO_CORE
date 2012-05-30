// File:    RespuestaCampo.cs
// Author:  vsis
// Created: sábado, 26 de mayo de 2012 23:57:53
// Purpose: Definition of Class RespuestaCampo

using System;

namespace SIMO_CORE.Modelo
{
    public class RespuestaCampo
    {
        virtual public int idRespuesta { get; set; }
        virtual public SolicitudDeAcceso solicitudRespuesta { get; set; }
        virtual public CampoFormulario campoRespuesta { get; set; }
        virtual public string valorCampo { get; set; }

        /* se sobreescriben Equals y GetHashCode, para que el sistema entienda que dos objetos son el mismo,
       * incluso si están en posiciones de memoria distintos
       * */
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            else
            {
                RespuestaCampo aux = obj as RespuestaCampo;
                if (aux == null)
                    return false;
                return aux.idRespuesta.Equals(this.idRespuesta);
            }
        }

        public override int GetHashCode()
        {
            return idRespuesta;
        }
    }
}