using Microsoft.EntityFrameworkCore;
using Helpdesk.API.Models;

namespace HelpdeskAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketEvent> TicketEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Agent)
                .WithMany(a => a.Tickets)
                .HasForeignKey(t => t.agentFk);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Customer)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.customerFk);

            ///modelBuilder.Entity<TicketEvent>()
            ///    .HasOne(e => e.Ticket)
            ///    .WithMany(t => t.TicketEvents)
            ///    .HasForeignKey(e => e.ticketFk);

            modelBuilder.Entity<TicketEvent>()
                .HasOne(te => te.Ticket)
                .WithMany()
                .HasForeignKey(te => te.ticketFk)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}