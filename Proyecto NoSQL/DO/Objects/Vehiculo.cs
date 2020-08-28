using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO.Objects
{
    public class Vehiculo
    {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("idVehiculo")]
        public long idVehiculo { get; set; }
        [BsonElement("fechaIngreso")]
        public DateTime fechaIngreso { get; set; }
        [BsonElement("RegistardoPor")]
        public RegistradoPor RegistardoPor { get; set; }
        [BsonElement("Modelo")]
        public Modelo Modelo { get; set; }
        [BsonElement("Defectos")]
        public List<String> Defectos{ get; set; }
    }
}
