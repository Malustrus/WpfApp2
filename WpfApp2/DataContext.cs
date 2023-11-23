using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    internal class DataContext : DbContext
    {
        public DbSet<Info> Infos { get; set; }

        public DataContext() : base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestDB;Trusted_Connection=True;");
        }
    }

    public class Info
    {
        [Key]
        public string SerialNumber { get;set; }
        public int Status { get; set; }
        public int Batch { get; set;}
    }
}
