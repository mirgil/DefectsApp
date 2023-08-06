using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DefectsApp
{
    public class DefectsContext : DbContext
    {
        public DbSet<Defect> Defects { get; set; }

        public string DbPath { get; }

        public DefectsContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "defects.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
            options.LogTo(message => Debugger.Log(0, "EF", message));
        }
    }


    public class Defect
    {
        public uint Id { get; set; }
        public int Severity { get; set; }
        public int Impact { get; set; }
    }


}