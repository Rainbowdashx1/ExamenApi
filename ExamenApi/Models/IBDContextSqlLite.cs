using ExamenApi.Models.ModelBD;
using System.Data.Entity;


namespace ExamenApi.Models
{
    public interface IBDContextSqlLite
    {
        DbSet<Clientes> Clientes { get; set; }
        // Include any other DbContext methods you'll need to use, like SaveChanges.
        int SaveChanges();
    }
}