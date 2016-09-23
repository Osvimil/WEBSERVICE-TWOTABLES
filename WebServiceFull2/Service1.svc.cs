using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebServiceFull2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<Pruebon> findAll()
        {

            using (UsuariosPreferencias mde = new UsuariosPreferencias())
            {

                return mde.usuario_preferencias.Select(pe => new Pruebon
                {

                    id_usuario = pe.id_usuario,
                    id_preferencia = pe.id_preferencias
                }).ToList();
            };
        }


        public Pruebon find(string id)
        {
            using (UsuariosPreferencias mde = new UsuariosPreferencias())
            {

                int nid = Convert.ToInt32(id);
                return mde.usuario_preferencias.Where(pe => pe.id_usuario == nid).Select(pe => new Pruebon
                {
                    id_usuario = pe.id_usuario,
                    id_preferencia = pe.id_preferencias
                    

                }).First();
            };
        }



        public bool create(Pruebon user)
        {
            using (UsuariosPreferencias mde = new UsuariosPreferencias())
            {
                try
                {

                    usuario_preferencias pe = new usuario_preferencias();
                    pe.id_usuario = user.id_usuario;
                    pe.id_preferencias = user.id_preferencia;
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


        public bool edit(Pruebon user)
        {
            using (UsuariosPreferencias mde = new UsuariosPreferencias())
            {
                try
                {

                    int id = Convert.ToInt32(user.id_usuario);
                    usuario_preferencias pe = mde.usuario_preferencias.Single(p => p.id_usuario == user.id_usuario);
                    pe.id_usuario = user.id_usuario;
                    pe.id_preferencias = user.id_preferencia;
                    mde.SaveChanges();

                    return true;
                }
                catch
                {

                    return false;

                }


            };
        }


        public bool delete(Pruebon user)
        {
            using (UsuariosPreferencias mde = new UsuariosPreferencias())
            {
                try
                {

                    int id = Convert.ToInt32(user.id_usuario);
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
