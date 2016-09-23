using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

namespace Client3.Models
{
    public class UserPreferencesClient
    {
        private string BASE_URL = "http://localhost:24973/Service1.svc/";


        public List<UserPreferences> findAll()
        {
            try
            {
                var webcliente = new WebClient();
                var json = webcliente.DownloadString(BASE_URL + "encontrarTodo");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<UserPreferences>>(json);
            }
            catch
            {
                return null;

            }
        }


        public UserPreferences find(string id)
        {
            try
            {
                var webcliente = new WebClient();
                string url = string.Format(BASE_URL + "encontrar/{0}", id);
                var json = webcliente.DownloadString(url);
                var js = new JavaScriptSerializer();
                return js.Deserialize<UserPreferences>(json);
            }
            catch
            {
                return null;

            }
        }


        public bool create(UserPreferences user_prf)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(UserPreferences));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, user_prf);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webCliente = new WebClient();
                webCliente.Headers["Content-type"] = "application/json";
                webCliente.Encoding = Encoding.UTF8;
                webCliente.UploadString(BASE_URL + "create", "POST", data);

                return true;
            }
            catch
            {
                return false;

            }
        }



        public bool edit(UserPreferences user_prf)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(UserPreferences));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, user_prf);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webCliente = new WebClient();
                webCliente.Headers["Content-type"] = "application/json";
                webCliente.Encoding = Encoding.UTF8;
                webCliente.UploadString(BASE_URL + "edit", "PUT", data);

                return true;
            }
            catch
            {
                return false;

            }
        }



        public bool delete(UserPreferences user_prf)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(UserPreferences));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, user_prf);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webCliente = new WebClient();
                webCliente.Headers["Content-type"] = "application/json";
                webCliente.Encoding = Encoding.UTF8;
                webCliente.UploadString(BASE_URL + "delete", "DELETE", data);

                return true;
            }
            catch
            {
                return false;

            }
        }

    }
}