using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace MVCMongoDB.Models
{
    public class Beer
    {
        //crea la llave primary
        [BsonId]
        //hace referencia del id a id de mongo que es objectId
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        //hacemos referencia al nombre textual en la base de datos
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("alcohol")]
        public decimal Alcohol { get; set; }
    }
}