using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO.Objects
{
    public class Pedido
    {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("idPedido")]
        public long idPedido { get; set; }
        [BsonElement("cliente")]
        public Cliente cliente { get; set; }
        [BsonElement("empleado")]
        public Empleado empleado { get; set; }
        [BsonElement("fechaInicio")]
        public DateTime fechaInicio { get; set; }
        [BsonElement("fechaFinalizacion")]
        public DateTime? fechaFinalizacion { get; set; }
        [BsonElement("marcaVehiculo")]
        public String marcaVehiculo { get; set; }
        [BsonElement("modeloVehiculo")]
        public String modeloVehiculo { get; set; }
        [BsonElement("yearModelo")]
        public String yearModelo { get; set; }
        [BsonElement("transimision")]
        public String transimision { get; set; }
        [BsonElement("cilindraje")]
        public String cilindraje { get; set; }
        [BsonElement("tipoCombutible")]
        public String tipoCombutible { get; set; }
        [BsonElement("traccion")]
        public String traccion { get; set; }
        [BsonElement("color")]
        public String color { get; set; }
        [BsonElement("detalle")]
        public String detalle { get; set; }
        [BsonElement("estado")]
        public Int32 estado { get; set; }
    }
}

