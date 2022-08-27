using ACC_Pay.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;

namespace ACC_Pay.Server.Context
{
    public class AccPayDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeContactInformation> EmployeeContactInformation { get; set; }
        public DbSet<EmployeeW4Configuration> EmployeeW4Configuration { get; set; }
        public DbSet<W4Years> W4Years { get; set; }

        public AccPayDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }

        /// <summary>
        /// Converts <see cref="DateOnly" /> to <see cref="DateTime"/> and vice versa.
        /// </summary>
        public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
        {
            /// <summary>
            /// Creates a new instance of this converter.
            /// </summary>
            public DateOnlyConverter() : base(
                    d => d.ToDateTime(TimeOnly.MinValue),
                    d => DateOnly.FromDateTime(d))
            { }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var decimalProps = modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => (System.Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

            foreach (var property in decimalProps)
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }
        }
    }
}
