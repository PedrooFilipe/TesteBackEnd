using Microsoft.EntityFrameworkCore;
using Q5.Entities;

namespace Q5;

public class Context(DbContextOptions options) : DbContext(options)
{
    public DbSet<Conta> Contas { get; set; }
}