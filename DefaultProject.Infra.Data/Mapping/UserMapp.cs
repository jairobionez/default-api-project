using DefaultProject.Domain.Entities;
using DefaultProject.Domain.ValueObjects;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace DefaultProject.Infra.Data.Mapping
{
    public class UserMapp : EntityTypeConfiguration<User>
    {
        public UserMapp()
        {
            ToTable("USUARIO");

            HasKey(u => u.Id);

            Property(u => u.Id)
                .HasColumnName("Id");

            Property(u => u.Name.FirstName)
                .HasColumnName("NOME")
                .HasMaxLength(40)
                .IsRequired();

            Property(u => u.Name.LastName)
                .HasColumnName("SOBRENOME")
                .HasMaxLength(40)
                .IsRequired();

            Property(u => u.Address.City)
                .HasColumnName("CIDADE")
                .HasMaxLength(50)
                .IsRequired();

            Property(u => u.Address.Country)
                .HasMaxLength(50)
                .HasColumnName("PAIS");

            Property(u => u.Address.Neighborhood)
                .HasMaxLength(50)
                .HasColumnName("BAIRRO");

            Property(u => u.Address.Number)
                .HasMaxLength(50)
                .HasColumnName("NUMERO");

            Property(u => u.Address.State)
                .HasMaxLength(50)
                .HasColumnName("ESTADO")
                .IsRequired();

            Property(u => u.Address.Street)
                .HasMaxLength(50)
                .HasColumnName("RUA");

            Property(u => u.Address.ZipCode)
                .HasMaxLength(50)
                .HasColumnName("CEP");           
        }
    }
}
