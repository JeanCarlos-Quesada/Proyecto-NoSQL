using DO.Objects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConnectionCliente
    {
        private readonly MongoClient client = new MongoClient("mongodb+srv://root:root@myatlascluster-wregg.gcp.mongodb.net/VEPA?retryWrites=true&w=majority");
        private IMongoDatabase dataBase = null;
        private IMongoCollection<Cliente> collectionCliente = null;

        public ConnectionCliente()
        {
            dataBase = client.GetDatabase("VEPA");
            collectionCliente = dataBase.GetCollection<Cliente>("cliente");
        }

        public Boolean insertCliente(Cliente newCliente)
        {
            try
            {
                var ultimoId = GetAll().LastOrDefault().idCliente;
                newCliente.idCliente = ultimoId + 1;
                collectionCliente.InsertOne(newCliente);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Cliente> GetByIdentificacion(String identificacion)
        {
            try
            {
                var tmp = collectionCliente.Find(s => s.identificacion == identificacion).FirstOrDefault();
                List<Cliente> clientes = new List<Cliente>();
                clientes.Add(tmp);
                return clientes;
            }
            catch
            {
                return new List<Cliente>();
            }
        }

        public List<Cliente> GetByIdCliente(long id)
        {
            try
            {
                var tmp = collectionCliente.Find(s => s.idCliente == id).FirstOrDefault();
                List<Cliente> clientes = new List<Cliente>();
                clientes.Add(tmp);
                return clientes;
            }
            catch
            {
                return new List<Cliente>();
            }
        }

        public List<Cliente> GetAll()
        {
            try
            {
                return collectionCliente.Find(_ => true).ToList();
            }
            catch
            {
                return new List<Cliente>();
            }
        }

        public Boolean UpdateTelefonoCliente(long idCliente, String telefono)
        {
            try
            {
                var filter = Builders<Cliente>.Filter.Eq(s => s.idCliente, idCliente);
                var update = Builders<Cliente>.Update
                 .Set(d => d.telefono, telefono);
                UpdateResult result = collectionCliente.UpdateOne(filter, update);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
