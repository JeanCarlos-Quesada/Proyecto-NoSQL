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
                var ultimoId = GetAll().LastOrDefault().idPedido;
                newPedido.idPedido = ultimoId + 1;
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
                return collectionPedido.Find(s => s.fechaInicio == (fechaInicio.AddHours(-6))).ToList();
            }
            catch
            {
                return new List<Pedido>();
            }
        }

        public List<Pedido> GetByIdPedido(long id)
        {
            try
            {
                var tmp = collectionPedido.Find(s => s.idPedido == id).FirstOrDefault();
                List<Pedido> pedidos = new List<Pedido>();
                pedidos.Add(tmp);
                return pedidos;
            }
            catch
            {
                return new List<Pedido>();
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
                return new List<Pedido>();
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
                return new List<String>();
            }
        }

        public Boolean UpdateEstadoPedido(long idPedido, int estado)
        {
            try
            {
                DateTime? date = DateTime.Now.AddHours(-6);
                if (estado == 0)
                {
                    date = null;
                }
                var filter = Builders<Pedido>.Filter.Eq(s => s.idPedido, idPedido);
                var updateEstado = Builders<Pedido>.Update
                 .Set(d => d.estado, estado);
                var updateFechaFinalizacion = Builders<Pedido>.Update
                 .Set(d => d.fechaFinalizacion, date);
                UpdateResult result = collectionPedido.UpdateOne(filter, updateEstado);
                result = collectionPedido.UpdateOne(filter, updateFechaFinalizacion);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}