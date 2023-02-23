
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Xname.EVO.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Xname.EVO.Database.EvoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    } 
}