using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasColumnName("Id");

            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnName("FullName");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(254)
                .HasColumnName("Email");

            builder.Ignore(x => x.EmailConfirmation);

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("Cpf");

            builder.Property(x => x.Cellphone)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("Cellphone");

            builder.Property(x => x.Birthdate)
                .IsRequired()
                .HasColumnName("Birthdate");

            builder.Property(x => x.EmailSms)
                .HasColumnName("EmailSms");

            builder.Property(x => x.WhatsApp)
                .HasColumnName("WhatsApp");

            builder.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Country");

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("City");

            builder.Property(x => x.PostalCode)
                .IsRequired()
                .HasMaxLength(9)
                .HasColumnName("PostalCode");

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Address");

            builder.Property(x => x.Number)
                .IsRequired()
                .HasColumnName("Number");
        }
    }
}
