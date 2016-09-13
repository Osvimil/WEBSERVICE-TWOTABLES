using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Client2.Models
{
    public class UserPreferences
    {

        [Display(Name = "id_usr")]
        public int id
        {
            get;
            set;
        }
        [Display(Name = "id_pref")]
        public int id_pref
        {
            get;
            set;
        }
    }
}