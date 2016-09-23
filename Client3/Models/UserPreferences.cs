using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Client3.Models
{
    public class UserPreferences
    {
        [Display(Name = "id_usuario")]
        public int id_usuario
        {
            get;
            set;
        }
        [Display(Name = "id_preferencias")]
        public int id_preferencias
        {
            get;
            set;
        }



    }
}