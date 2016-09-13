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
    public class Service3 : IService3
    {
        public List<Prueba3> encontrarTodo()
        {

            using (UsuariosEntities mde = new UsuariosEntities())
            {

                return mde.usuario_preferencias.Select(pe => new Prueba3
                {
                    id_usuario = pe.id_usuario,  
                    id_preferencias = pe.id_preferencias,
                   
                }).ToList();
            };
        }


        public Prueba3 encontrar(string id)
        {
            using (UsuariosEntities mde = new UsuariosEntities())
            {

                int nid = Convert.ToInt32(id);
                return mde.usuario_preferencias.Where(pe => pe.id_usuario == nid).Select(pe => new Prueba3
                {
                    id_usuario = pe.id_usuario,
                    id_preferencias = pe.id_preferencias,           
                }).First();
            };
        }



        public bool create(Prueba3 user)
        {
            using (UsuariosEntities mde = new UsuariosEntities())
            {
                try
                {

                   usuario_preferencias pe = new usuario_preferencias();
                    pe.id_usuario = user.id_usuario;
                    pe.id_preferencias = user.id_preferencias;                  
                    mde.usuario_preferencias.Add(pe);
                    mde.SaveChanges();

                    return true;
                }
                catch
                {

                    return false;

                }


            };

        }


        public bool edit(Prueba3 user)
        {
            using (UsuariosEntities mde = new UsuariosEntities())
            {
                try
                {

                    int id = Convert.ToInt32(user.id_preferencias);
                    usuario_preferencias pe = mde.usuario_preferencias.Single(p => p.id_usuario == user.id_usuario);
                    pe.id_usuario = user.id_usuario;
                    pe.id_preferencias = user.id_preferencias;                                  
                    mde.SaveChanges();
                    return true;
                }
                catch
                {

                    return false;

                }


            };
        }


        public bool delete(Prueba3 user)
        {
            using (UsuariosEntities mde = new UsuariosEntities())
            {
                try
                {

                    int id = Convert.ToInt32(user.id_preferencias);
                    usuario_preferencias pe = mde.usuario_preferencias.Single(p => p.id_usuario == user.id_usuario);
                    mde.usuario_preferencias.Remove(pe);
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
