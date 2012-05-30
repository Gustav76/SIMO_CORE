// File:    CampoFormulario.cs
// Author:  vsis
// Created: sábado, 26 de mayo de 2012 23:57:53
// Purpose: Definition of Class CampoFormulario

using System;

namespace SIMO_CORE.Modelo
{
    public class CampoFormulario
    {
        virtual public int idCampoFormulario { get; set; }
        virtual public PuntoDeAprobacion puntoCampo { get; set; }
        virtual public string etiqueta { get; set; }
        virtual public int posicionCampo { get; set; }

        /* se sobreescriben Equals y GetHashCode, para que el sistema entienda que dos objetos son el mismo,
       * incluso si están en posiciones de memoria distintos
       * */
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            else
            {
                CampoFormulario aux = obj as CampoFormulario;
                if (aux == null)
                    return false;
                return aux.idCampoFormulario.Equals(this.idCampoFormulario);
            }
        }

        public override int GetHashCode()
        {
            return idCampoFormulario;
        }
    }
}