using DO.Objects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConnectionEmpleado
    {
        private readonly MongoClient client = new MongoClient("mongodb+srv://root:root@myatlascluster-wregg.gcp.mongodb.net/VEPA?retryWrites=true&w=majority");
        private IMongoDatabase dataBase = null;
        private IMongoCollection<Empleado> collectionEmpleado = null;

        public ConnectionEmpleado()
        {
            dataBase = client.GetDatabase("VEPA");
            collectionEmpleado = dataBase.GetCollection<Empleado>("empleado");
        }

        public Boolean insertEmpleado(Empleado newEmpleado)
        {
            try
            {
                var ultimoId = GetAll().LastOrDefault().idEmpleado;
                newEmpleado.idEmpleado = ultimoId + 1;
                collectionEmpleado.InsertOne(newEmpleado);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Empleado> GetByIdentificacion(String identificacion)
        {
            try
            {
                var tmp = collectionEmpleado.Find(s => s.identificacion == identificacion).FirstOrDefault();
                List<Empleado> empleados = new List<Empleado>();
                empleados.Add(tmp);
                return empleados;
            }
            catch
            {
                return new List<Empleado>();
            }
        }

        public List<Empleado> GetByIdEmpleado(long id)
        {
            try
            {
                var tmp = collectionEmpleado.Find(s => s.idEmpleado == id).FirstOrDefault();
                List<Empleado> empleados = new List<Empleado>();
                empleados.Add(tmp);
                return empleados;
            }
            catch
            {
                return new List<Empleado>();
            }
        }

        public List<Empleado> GetAll()
        {
            try
            {
                return collectionEmpleado.Find(_ => true).ToList();
            }
            catch
            {
                return new List<Empleado>();
            }
        }

        public Boolean UpdateFechaContratacionEmpleado(long idEmpleado, DateTime newDate)
        {
            try
            {
                var filter = Builders<Empleado>.Filter.Eq(s => s.idEmpleado, idEmpleado);
                var update = Builders<Empleado>.Update
                 .Set(d => d.fechaContratacion, newDate);
                UpdateResult result = collectionEmpleado.UpdateOne(filter, update);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
