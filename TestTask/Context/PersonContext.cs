using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Context
{
public class PersonContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public DbSet<Skill> Skills { get; set; }
    public PersonContext(DbContextOptions options): base(options)
    {
    }
}
}
