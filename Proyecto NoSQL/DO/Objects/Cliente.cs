﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO.Objects
{
    public class Cliente
    {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("idCliente")]
        public long idCliente { get; set; }
        [BsonElement("identificacion")]
        public String identificacion { get; set; }
        [BsonElement("nombre")]
        public String nombre { get; set; }
        [BsonElement("telefono")]
        public String telefono { get; set; }
        [BsonElement("email")]
        public String email { get; set; }
    }
}
