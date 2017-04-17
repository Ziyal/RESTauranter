using System;
using Microsoft.EntityFrameworkCore;

namespace RESTauranter.Models
{
    public class RestContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RestContext(DbContextOptions<RestContext> options) : base(options) { }

        // Below must match the object and the DB table name
         public DbSet<Review> Reviews { get; set; }
    }
}