namespace TravelPalette.PL.Test
{
    [TestClass]
    public class utBase<T> where T : class
    {
        protected TravelPaletteEntities dc;
        protected IDbContextTransaction transaction;
        private IConfigurationRoot _configuration;
        private DbContextOptions<TravelPaletteEntities> options;

        public utBase()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
            options = new DbContextOptionsBuilder<TravelPaletteEntities>()
                .UseSqlServer(_configuration.GetConnectionString("DatabaseConnection"))
                .UseLazyLoadingProxies()
                .Options;
            dc = new TravelPaletteEntities(options);
        }


        [TestInitialize]
        public void Initialize()
        {
            transaction = dc.Database.BeginTransaction();
        }
        [TestCleanup]
        public void Cleanup()
        {
            transaction.Rollback();
            transaction.Dispose();
            transaction = null;
        }

        public List<T> LoadTest()
        {
            return dc.Set<T>().ToList();
        }
        public int InsertTest(T row)
        {
            dc.Set<T>().Add(row);
            return dc.SaveChanges();
        }

        public int UpdateTest(T row)
        {

            dc.Entry(row).State = EntityState.Modified;
            return dc.SaveChanges();
        }

        public int DeleteTest(T row)
        {
            dc.Set<T>().Remove(row);
            return dc.SaveChanges();
        }
    }
}