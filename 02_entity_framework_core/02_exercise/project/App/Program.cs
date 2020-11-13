using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Utils;

namespace App
{
    public class ProjectContext : DbContext
    {

        #region why does it work in jupyter
        // public DbSet<Project> Projects { get; set; }
        // https://docs.microsoft.com/en-us/ef/core/miscellaneous/nullable-reference-types#dbcontext-and-dbset
        #endregion
        public DbSet<Project> Projects => Set<Project>();
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=/home/student/comp_2020_maksymilian_wojcik/02_entity_framework_core/02_exercise/project/App/blog.db");
        } 
    }
    
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static void Main()
        {
            // TODO: Create and use DB context...
            
            using (var db = new ProjectContext())
            {
                var project = new Project { CreationDate = DateTime.Now };
                db.Projects.Add(project);
                db.SaveChanges();
            }

            using (var db = new ProjectContext())
            {
                var projects = db.Projects
                    .ToList();
            }
        }
    }

}