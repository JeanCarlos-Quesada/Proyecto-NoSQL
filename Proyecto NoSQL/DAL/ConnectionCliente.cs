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
                collectionCliente.InsertOne(newCliente);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Cliente GetByIdentificacion(String identificacion)
        {
            try
            {
                return collectionCliente.Find(s => s.identificacion == identificacion).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
    }
}
