using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfService1_SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service2.svc or Service2.svc.cs at the Solution Explorer and start debugging.
    public class Service2 : IService2
    {
        public async Task<List<AutorDTO>> ListAutores()
        {
            var resultado = new List<AutorDTO>();
            var connString = "Server=localhost;Port=5432;Database=WebApiAutores;User Id=postgres;Password=634510;";

            var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            var query = "SELECT * FROM public.\"Autores\"";

            var cmd = new NpgsqlCommand(query, conn);
            var reader = await cmd.ExecuteReaderAsync();
            {
                while (await reader.ReadAsync())
                {
                    resultado.Add(new AutorDTO
                    {
                        Id = (int)reader.GetValue(0),
                        NombreCompleto = (string)reader.GetValue(1)
                    });
                }
            }
            return resultado;
        }
    }
}
