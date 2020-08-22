using DO.Objects;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConnectionPedido
    {
        private readonly MongoClient client = new MongoClient("mongodb+srv://root:root@myatlascluster-wregg.gcp.mongodb.net/VEPA?retryWrites=true&w=majority");
        private IMongoDatabase dataBase = null;
        private IMongoCollection<Pedido> collectionPedido = null;

        public ConnectionPedido()
        {
            dataBase = client.GetDatabase("VEPA");
            collectionPedido = dataBase.GetCollection<Pedido>("pedido");
        }

        public Boolean insertPedido(Pedido newPedido)
        {
            try
            {
                collectionPedido.InsertOne(newPedido);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Pedido> GetByFechaInicio(DateTime fechaInicio)
        {
            try
            {
                return collectionPedido.Find(s => s.fechaInicio.ToString("dd/MM/yyyy") == fechaInicio.ToString("dd/MM/yyyy")).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Pedido> GetByIdPedido(long id)
        {
            try
            {
                return collectionPedido.Find(s => s.idPedido == id).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Pedido> GetAll()
        {
            try
            {
                return collectionPedido.Find(_ => true).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<String> GroupByEmpleado()
        {
            try
            {
                List<String> GroupByEmpleado = new List<string>();
                var GroupBy = collectionPedido.AsQueryable()
                    .GroupBy(p => p.empleado.nombre)
                    .Select(g => new { Name = g.Key, Count = g.Count() }).ToList();

                foreach (var aux in GroupBy)
                {
                    GroupByEmpleado.Add("Nombre del Empleado: " + aux.Name + ", Cantidad: " + aux.Count);
                }

                return GroupByEmpleado;
            }
            catch
            {
                return null;
            }
        }
    }
}