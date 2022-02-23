using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test_reservas.Models;

namespace test_reservas.Data
{
    public class test_reservasContext : DbContext
    {
        public test_reservasContext (DbContextOptions<test_reservasContext> options)
            : base(options)
        {
        }

        public DbSet<Reserva> Reserva { get; set; }
    }
}
