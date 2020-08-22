using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO.Objects
{
    public class Modelo
    {
        [BsonElement("marcaVehiculo")]
        public String marcaVehiculo { get; set; }
        [BsonElement("modeloVehiculo")]
        public String modeloVehiculo { get; set; }
        [BsonElement("yearModelo")]
        public String yearModelo { get; set; }
    }
}
