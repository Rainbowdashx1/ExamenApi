using ExamenApi.Models.ModelBD;
using System.Configuration;
using System.Data.Entity;

namespace ExamenApi.Models
{
    public class BDContextSqlLite :System.Data.Entity.DbContext
    {
        public BDContextSqlLite():base("name=ConexionSqlLite") { }
        public DbSet<Clientes> Clientes { get; set; }
    }
}