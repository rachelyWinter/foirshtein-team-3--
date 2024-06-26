using Librarians.Repository.Entities;
using Librarians.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Librarians.DataContext
{

    public class DataContext: DbContext ,IContext
    {
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Item> Items { get; set; }
        public DbSet<ApprovalRequest> ApprovalReqest { get; set; }



        public async Task Save()
        {
            await SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=liberiansDB;User Id=sa;Password=Foir100#;\r\n");//נשנה לפי השם של הטבלה שלנו
            Console.WriteLine("conect to DB!!!!");
        }
    }
}
