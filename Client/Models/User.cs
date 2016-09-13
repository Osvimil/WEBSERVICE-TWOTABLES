using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class User
    {
        [Display(Name = "id")]
        public int id
        {
            get;
            set;
        }
        [Display(Name = "clave")]
        public string clave
        {
            get;
            set;
        }
        [Display(Name = "nombre")]
        public string nombre
        {
            get;
            set;
        }
        [Display(Name = "correo")]
        public string correo
        {
            get;
            set;
        }
    }
}