using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<ExpenseEntry> ExpenseEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenseCategory>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<ExpenseEntry>()
                .HasOne(e => e.Category)
                .WithMany()
                .HasForeignKey(e => e.CategoryId);
        }
    }
}
