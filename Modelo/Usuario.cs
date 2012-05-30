// File:    Usuario.cs
// Author:  vsis
// Created: sábado, 26 de mayo de 2012 23:57:53
// Purpose: Definition of Class Usuario

using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Transaction;



namespace SIMO_CORE.Modelo
{

    /// Es la entidad base del sistema, consiste en los usuarios directos de la aplicación SIMO IM, un usuario puede tener varios pares nombre usuario-contraseña (Identidades) que permiten acceso a los sistemas objetivos. Un usuario puede realizar solicitudes de acceso a un sistema objetivo en particular, además de estar a cargo de la aprobación/rechazo de solicitudes en determinados puntos de aprobación.
    public class Usuario
    {
        virtual public int idUsuario { get; set; }
        virtual public string usuario { get; set; }
        virtual public string claveUsuario { get; set; } /*usuario y nombre para acceder a este sistema */
        virtual public string nombres { get; set; }
        virtual public string apellidos { get; set; }
        virtual public DateTime fechaNacimiento { get; set; }
        virtual public DateTime fechaIngreso { get; set; }
        virtual public DateTime fechaDesligado { get; set; }
        virtual public short estado { get; set; } /* por ahora los estados son 0:activo 1:eliminado */
        virtual public short grupos { get; set; } /* 1: usuario de S.O. 2: usuario punto aprobación 4: administrador
                                                   * por ejemplo 5 significa que es usuario de SO y administrador a la vez (5 = 4 + 1)

        /* se sobreescriben Equals y GetHashCode, para que el sistema entienda que dos objetos son el mismo,
            * incluso si están en posiciones de memoria distintos
            * */
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            else
            {
                Usuario aux = obj as Usuario;
                if (aux == null)
                    return false;
                return aux.idUsuario.Equals(this.idUsuario);
            }
        }

        public override int GetHashCode()
        {
            return idUsuario;
        }

        /* Devuelve una lista con todos los usuarios del sistema */
        public static IList<Usuario> Listar()
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            IQuery query = sesion.CreateQuery("from Usuario");
            IList<Usuario> resultado = query.List<Usuario>();
            tx.Commit();
            return resultado;
        }

        /* Cuando se trata de un usuario nuevo, lo guarda en la base de datos
         * debe tener un id=0 */
        public virtual void Guardar()
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            sesion.Save(this);
            tx.Commit();
            sesion.Close();
        }

        /* Cuando se trata de un usuario existente del sistma, actualiza los cambios hechos sobre él
         * debe tener un id!=0 */
        public virtual void Actualizar()
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            sesion.Update(this);
            tx.Commit();
            sesion.Close();
        }

        /* Elimina un usuario del sistema
         * no lo borra de la base de datos, sólo lo marca como eliminado */
        public virtual void Eliminar()
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            this.estado = 1;
            sesion.Update(this);
            tx.Commit();
            sesion.Close();
        }

        /* Elimina un usuario del sistema
        * no lo borra de la base de datos, sólo lo marca como eliminado */
        public static Usuario ObtenerPorId(int id)
        {
            ISession sesion = config.abrirSesion();
            ITransaction tx = sesion.BeginTransaction();
            Usuario usuario = sesion.Get<Usuario>(id);
            tx.Commit();
            sesion.Close();
            return usuario;
        }
    }
}