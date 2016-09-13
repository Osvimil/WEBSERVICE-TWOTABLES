using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web; 
using System.Text;

namespace WebServiceFull
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<Prueba> findAll()
        {

            using (UsuariosEntities mde = new UsuariosEntities())
            {

                return mde.usuarios.Select(pe => new Prueba
                {
                    
                    id = pe.id_usuario,
                    clave = pe.clave,
                    nombre = pe.nombre,
                    correo = pe.correo
                }).ToList();
            };
        }


        public Prueba find(string id)
        {
            using (UsuariosEntities mde = new UsuariosEntities())
            {

                int nid = Convert.ToInt32(id);
                return mde.usuarios.Where(pe => pe.id_usuario == nid).Select(pe => new Prueba
                {
                    id = pe.id_usuario,
                    clave = pe.clave,
                    nombre = pe.nombre,
                    correo = pe.correo

                }).First();
            };
        }



        public bool create(Prueba user)
        {
            using (UsuariosEntities mde = new UsuariosEntities())
            {
                try
                {

                    usuario pe = new usuario();
                    pe.clave = user.clave;
                    pe.nombre = user.nombre;
                    pe.correo = user.correo;
                    mde.usuarios.Add(pe);
                    mde.SaveChanges();

                    return true;
                }
                catch
                {

                    return false;

                }


            };

        }


        public bool edit(Prueba user)
        {
            using (UsuariosEntities mde = new UsuariosEntities())
            {
                try
                {

                    int id = Convert.ToInt32(user.id);
                    usuario pe = mde.usuarios.Single(p => p.id_usuario == user.id);
                    pe.clave = user.clave;
                    pe.nombre = user.nombre;
                    pe.correo = user.correo;
                    mde.SaveChanges();

                    return true;
                }
                catch
                {

                    return false;

                }


            };
        }


        public bool delete(Prueba user)
        {
            using (UsuariosEntities mde = new UsuariosEntities())
            {
                try
                {

                    int id = Convert.ToInt32(user.id);
                    usuario pe = mde.usuarios.Single(p => p.id_usuario == user.id);
                    mde.usuarios.Remove(pe);
                    mde.SaveChanges();

                    return true;
                }
                catch
                {

                    return false;

                }


            };
        }

    }
}
