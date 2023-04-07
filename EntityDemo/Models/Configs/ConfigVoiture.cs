using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityDemo.Models.Configs
{
    public class ConfigVoiture : IEntityTypeConfiguration<Voiture>
    {
        public void Configure(EntityTypeBuilder<Voiture> builder)
        {
            builder.HasCheckConstraint("CK_Plate", "[Plate] NOT LIKE '%@%'");
            
            builder.HasKey("Id");
            builder.Property("Brand").IsRequired();
            builder.Property("Brand").HasMaxLength(100);

            // Auto increment
            //builder.Property("Id").ValueGeneratedOnAdd();


            // Ajoute une valeur par defaut
            //builder.Property("Id").HasDefaultValue(42);

            // Change le nom de la colonne
            //builder.Property("Id").HasColumnName("Primary");
        }
    }
}
