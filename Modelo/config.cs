using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate;

namespace SIMO_CORE.Modelo
{
    public class config
    {
        static public Configuration cfg;
        static public ISessionFactory sesiones;
        /* datos para conectarse a la BD */
        static public String servidor = "localhost";
        static public String baseDatos = "simo im";
        static public String usuario = "simo";
        static public String pass = "123456";

        static public void configurarSesiones()
        {
            cfg = new Configuration();
            cfg.SetProperty("dialect", "NHibernate.Dialect.MySQLDialect");
            cfg.SetProperty("connection.driver_class", "NHibernate.Driver.MySqlDataDriver");
            cfg.SetProperty("connection.connection_string", "Server='" + servidor + "';Database='" + baseDatos + "';User ID=" + usuario + ";Password=" + pass + ";CharSet=utf8");
            cfg.AddAssembly("SIMO_CORE");
            sesiones = cfg.BuildSessionFactory();
        }

        static public void comprobarSesiones()
        {
            if (sesiones == null)
                configurarSesiones();
        }

        public static ISession abrirSesion()
        {
            return sesiones.OpenSession();
        }
    }
}
