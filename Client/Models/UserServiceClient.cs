using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;


namespace Client.Models
{
    public class UserServiceClient
    {
        private string BASE_URL = "http://localhost:3279/Service1.svc/";
        public List<User> findAll()
        {
            try
            {
                var webcliente = new WebClient();
                var json = webcliente.DownloadString(BASE_URL + "findall");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<User>>(json);
            }
            catch
            {
                return null;

            }
        }

        public User find(string id)
        {
            try
            {
                var webcliente = new WebClient();
                string url = string.Format(BASE_URL + "find/{0}", id);
                var json = webcliente.DownloadString(url);
                var js = new JavaScriptSerializer();
                return js.Deserialize<User>(json);
            }
            catch
            {
                return null;

            }
        }


        public bool create(User user)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(User));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, user);
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

        public bool edit(User user)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(User));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, user);
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
    }
}