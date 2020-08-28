using DO.Objects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConnectionVehiculo
    {
        private readonly MongoClient client = new MongoClient("mongodb+srv://root:root@myatlascluster-wregg.gcp.mongodb.net/VEPA?retryWrites=true&w=majority");
        private IMongoDatabase dataBase = null;
        private IMongoCollection<Vehiculo> collectionVehiculo = null;

        public ConnectionVehiculo()
        {
            dataBase = client.GetDatabase("VEPA");
            collectionVehiculo = dataBase.GetCollection<Vehiculo>("vehiculo");
        }

        public Boolean insertVehiculo(Vehiculo newVehiculo)
        {
            try
            {
                var ultimoId = GetAll().LastOrDefault().idVehiculo;
                newVehiculo.idVehiculo = ultimoId + 1;
                collectionVehiculo.InsertOne(newVehiculo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Vehiculo> GetByidVehiculo(long idVehiculo)
        {
            try
            {
                return collectionVehiculo.Find(s => s.idVehiculo == idVehiculo).ToList();
            }
            catch
            {
                return new List<Vehiculo>();
            }
        }

        public List<Vehiculo> GetByFechaIngreso(DateTime fechaIngreso)
        {
            try
            {
                return collectionVehiculo.Find(s => s.fechaIngreso == (fechaIngreso.AddHours(-6))).ToList();
            }
            catch
            {
                return new List<Vehiculo>();
            }
        }

        public List<Vehiculo> GetByYearModelo(String yearModelo)
        {
            try
            {
                return collectionVehiculo.Find(s => s.Modelo.yearModelo == yearModelo).ToList();
            }
            catch
            {
                return new List<Vehiculo>();
            }
        }

        public List<Vehiculo> GetByMarca(String marca)
        {
            try
            {
                return collectionVehiculo.Find(s => s.Modelo.marcaVehiculo == marca).ToList();
            }
            catch
            {
                return new List<Vehiculo>();
            }
        }

        public List<Vehiculo> GetByDefecto(String defecto)
        {
            try
            {
                return collectionVehiculo.Find(s => s.Defectos.Contains(defecto)).ToList();
            }
            catch
            {
                return new List<Vehiculo>();
            }
        }

        public List<Vehiculo> GetAll()
        {
            try
            {
                return collectionVehiculo.Find(_ => true).ToList();
            }
            catch
            {
                return new List<Vehiculo>();
            }
        }

        public Boolean UpdateRegistardoPor(long idVehiculo, Empleado empleado)
        {
            try
            {
                var filter = Builders<Vehiculo>.Filter.Eq(s => s.idVehiculo, idVehiculo);
                var update = Builders<Vehiculo>.Update
                 .Set(d => d.RegistardoPor, empleado);
                UpdateResult result = collectionVehiculo.UpdateOne(filter, update);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

