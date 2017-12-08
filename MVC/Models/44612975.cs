using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class _44612975 : DbContext
    {
        // Your context has been configured to use a '_44612975' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MVC.Models._44612975' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the '_44612975' 
        // connection string in the application configuration file.
        public _44612975()
            : base("name=44612975")
        {
        }

        public System.Data.Entity.DbSet<MVC.Models.Book> Books { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class Book
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int Num { get; set; }

        [Required]
        public string Name { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}