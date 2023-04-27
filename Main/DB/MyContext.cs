using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using UpdateDataWithDynamicLinq.Model;

namespace UpdateDataWithDynamicLinq.DB;

public class MyContext : DbContext
{
    public MyContext()
    {

    }

    public DbSet<Student> Student => Set<Student>();


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .LogTo(Console.WriteLine, (_, level) => level == LogLevel.Information)

            .UseSqlServer("Password=@@;Persist Security Info=True;User ID=@@;Initial Catalog=UpdateDataWithDynamicLinq;Data Source=@@;TrustServerCertificate=True ");

    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {


    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {





    }



}

