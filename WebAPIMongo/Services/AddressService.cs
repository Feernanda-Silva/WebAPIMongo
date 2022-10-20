using System.Collections.Generic;
using MongoDB.Driver;
using WebAPIMongo.Models;
using WebAPIMongo.Utils;

namespace WebAPIMongo.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _adress;

        public AddressService(IDatabaseSettings settings)
        {
            var adress = new MongoClient(settings.ConnectionString);
            var database = adress.GetDatabase(settings.DatabaseName);
            _adress = database.GetCollection<Address>(settings.AddressCollectionName);
        }

        public Address Create(Address adress)
        {
            _adress.InsertOne(adress);
            return adress;
        }

        public List<Address> Get() => _adress.Find(address => true).ToList();

        public Address Get(string id) => _adress.Find(adress => adress.Id == id).FirstOrDefault();

        public void Update(string id, Address adressIn) => _adress.ReplaceOne(adress => adress.Id == id, adressIn);

        public void Remove(Address adressIn) => _adress.DeleteOne(adress => adress.Id == adressIn.Id);


    }
}
