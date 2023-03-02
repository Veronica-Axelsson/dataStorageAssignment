using Microsoft.EntityFrameworkCore;

namespace dataStorage.Contexts
{
    internal class DataContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mille\Dropbox\EC-Utbildning\Datalagring\Assignment\dataStorageAssignment\dataStorage\Contexts\sql_database.mdf;Integrated Security=True;Connect Timeout=30";

        #region constructors
        public DataContext()
        {
            
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        #endregion


        #region overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }
        #endregion


    

    }
}
