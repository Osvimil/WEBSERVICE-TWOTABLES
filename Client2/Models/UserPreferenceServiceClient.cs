using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
namespace Client2.Models
{
    public class UserPreferenceServiceClient
    {
        
        private string BASE_URL = "http://localhost:3279/Service1.svc/";
        public List<UserPreferences> trouverTout()
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



    public UserPreferences trouver(string id)
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

    public bool create(UserPreferences us_pr)
    {
        try
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(UserPreferences));
            MemoryStream mem = new MemoryStream();
            ser.WriteObject(mem, us_pr);
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

    public bool edit(UserPreferences us_pr)
    {
        try
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(UserPreferences));
            MemoryStream mem = new MemoryStream();
            ser.WriteObject(mem, us_pr);
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