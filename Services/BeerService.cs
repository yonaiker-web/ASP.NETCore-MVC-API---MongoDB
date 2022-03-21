using System.Collections.Generic;
using MongoDB.Driver;
using MVCMongoDB.Models;

namespace MVCMongoDB.Services
{
    public class BeerService
    {
        private IMongoCollection<Beer> _beers;

        //creamos la conexion completa a la base de datos
        public BeerService(IBarSettings settings)
        {
            //nos conectamos al servidor por medio del cliente de MongoCLient
            var cliente = new MongoClient(settings.Server);
            //ese cliente se conecta a la base de datos
            var database = cliente.GetDatabase(settings.Database);
            //y hacemos referencia a la collection en mongodb
            _beers = database.GetCollection<Beer>(settings.Collection);
        }


        //obetner todos los elementos
        public List<Beer> Get()
        {
            return _beers.Find(d=> true).ToList();
        }

        public Beer Create(Beer beer)
        {
            _beers.InsertOne(beer);
            return beer;
        }

        public void Update(string id, Beer beer)
        {
            _beers.ReplaceOne(beer => beer.Id == id, beer);
        }

        public void Delete(string id)
        {
            _beers.DeleteOne(d => d.Id == id);
        }
    }
}