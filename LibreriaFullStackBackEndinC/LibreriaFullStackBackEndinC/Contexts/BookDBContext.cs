﻿using System.Data;
using System.Xml;
using LibreriaFullStackBackEndinC.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LibreriaFullStackBackEndinC.Contexts
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {
        }
        public DbSet<BookModel> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookModel>(entity =>
            {
                entity.ToTable("Books");
                entity.Metadata.SetAnnotation("Relational:Triggers", new[] { "TrgAfterInsertBook" });
            });
        }


        /*public void InsertBook(string title, string author, int pages, double price) { 
            using (var command = Database.GetDbConnection().CreateCommand()) 
            { 
              command.CommandText = "InsertBook"; 
              command.CommandType = CommandType.StoredProcedure; 
              command.Parameters.Add(new SqlParameter("@Title", title)); 
              command.Parameters.Add(new SqlParameter("@Author", author));
              command.Parameters.Add(new SqlParameter("@Pages", pages));
              command.Parameters.Add(new SqlParameter("@Price", price)); 

              Database.OpenConnection(); 
              command.ExecuteNonQuery(); 
              Database.CloseConnection(); 
            } 
        }*/
    }
}
