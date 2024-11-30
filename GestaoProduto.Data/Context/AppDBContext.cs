using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestaoProduto.Domain.Entidades;

namespace GestaoProduto.Data.Context
{
    public class AppDBContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
    }
}
