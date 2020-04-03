using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie_Database_MVC.Models;

namespace Movie_Database_MVC.Data
{
    public class Movie_Database_DBContext : DbContext
    {
        public Movie_Database_DBContext (DbContextOptions<Movie_Database_DBContext> options)
            : base(options)
        {
        }

        public DbSet<Movie_Database_MVC.Models.Actor> Actor { get; set; }

        public DbSet<Movie_Database_MVC.Models.Director> Director { get; set; }

        public DbSet<Movie_Database_MVC.Models.Movie> Movie { get; set; }

        public DbSet<Movie_Database_MVC.Models.MovieCastAssignment> MovieCastAssignment { get; set; }
    }
}
