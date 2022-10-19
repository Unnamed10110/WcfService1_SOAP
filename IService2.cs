using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfService1_SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService2" in both code and config file together.
    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
        Task<List<AutorDTO>> ListAutores();


    }
    [DataContract]
    public class AutorDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string NombreCompleto { get; set; }

        [DataMember]
        public string Imagen { get; set; }
    }
}
