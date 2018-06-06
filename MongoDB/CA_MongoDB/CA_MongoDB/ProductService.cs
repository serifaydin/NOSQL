using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace CA_MongoDB
{
    public class ProductService
    {
        private static ProductService _client;
        private static object lockObject = new object();

        private MongoClient mongoClient;
        private IMongoCollection<Product> productCollection;

        public static ProductService ProductClientAsSingleton()
        {
            lock (lockObject)
            {
                return _client ?? (_client = new ProductService());
            }
        }

        public ProductService()
        {
            mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("mydemo");
            productCollection = database.GetCollection<Product>("mydemo");
        }

        public void ProductInsert()
        {
            Product product = new Product
            {
                Name = "Armut",
                Price = 11,
                Quantity = 3,
                Status = true,
                CategoryId = 1,
                Date = DateTime.Now,
                isActive = true
            };
            productCollection.InsertOne(product);
        }

        public void ProductList()
        {
            var products = productCollection.AsQueryable<Product>().ToList();

            foreach (var product in products)
            {
                Console.WriteLine("id: " + product.Id);
                Console.WriteLine("Name: " + product.Name);
                Console.WriteLine("Price: " + product.Price);
                Console.WriteLine("Quantity: " + product.Quantity);
                Console.WriteLine("Status: " + product.Status);
                Console.WriteLine("Date: " + product.Date);
                Console.WriteLine("CategoryID: " + product.CategoryId);
                Console.WriteLine("IsActive: " + product.isActive);
                Console.WriteLine("=========================");
            }
        }

        public void ProductUpdate(string id)
        {
            var result = productCollection.UpdateOne(
                Builders<Product>.Filter.Eq("_id", ObjectId.Parse(id)),
                Builders<Product>.Update
                .Set("price", 525)
                .Set("quantity", 888)
                );
        }

        public bool ProductDelete(string id)
        {
            var result = productCollection.DeleteOne(Builders<Product>.Filter.Eq("_id", ObjectId.Parse(id)));
            return Convert.ToBoolean(result.DeletedCount);
        }

        public void ProductListWhere(bool status)
        {
            var products = productCollection.AsQueryable<Product>().Where(p => p.Status == status).ToList();

            foreach (var product in products)
            {
                Console.WriteLine("id: " + product.Id);
                Console.WriteLine("Name: " + product.Name);
                Console.WriteLine("Price: " + product.Price);
                Console.WriteLine("Quantity: " + product.Quantity);
                Console.WriteLine("Status: " + product.Status);
                Console.WriteLine("Date: " + product.Date);
                Console.WriteLine("CategoryID: " + product.CategoryId);
                Console.WriteLine("IsActive: " + product.isActive);
                Console.WriteLine("=========================");
            }
        }
    }
}