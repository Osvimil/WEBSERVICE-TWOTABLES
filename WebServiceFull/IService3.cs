using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebServiceFull
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService3
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "trouverTout", ResponseFormat = WebMessageFormat.Json)]
        List<Prueba3> encontrarTodo();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "trouver/{id}", ResponseFormat = WebMessageFormat.Json)]
        Prueba3 encontrar(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool create(Prueba3 product);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "edit", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool edit(Prueba3 user);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "delete", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool delete(Prueba3 user);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
   
}
