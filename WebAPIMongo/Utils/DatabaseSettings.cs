namespace WebAPIMongo.Utils
{
    public class DatabaseSettings : IDatabaseSettings //erro: implementar interface
    {
        public string ClientCollectionName { get; set; }
       public string AddressCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
