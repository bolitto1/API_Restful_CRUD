using API_Restful_CRUD.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Restful_CRUD.Context
{
	public class AppDbContext: DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
		{
				
		}

		public DbSet<Producto>  Producto { get; set; }
    //public DbSet<Nombre_de_la_clase> nombre_de_la_tabla_en_la_BD { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
			//https://docs.microsoft.com/es-es/ef/core/modeling/keyless-entity-types?tabs=data-annotations

			modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

      modelBuilder.Entity<Producto>(entity =>
      {
        entity.ToTable("Producto");
        entity.HasKey(e => e.pro_codigo);
        entity.Property(e => e.pro_codigo).HasColumnName("pro_codigo");

				entity.Property(e => e.pro_nombre)
						.HasMaxLength(50)
						.IsUnicode(false)
						.HasColumnName("pro_nombre");

				entity.Property(e => e.pro_descripcion)
						.HasMaxLength(200)
						.IsUnicode(false)
						.HasColumnName("pro_descripcion");

				entity.Property(e => e.pro_precio)
					.HasColumnName("pro_precio");


			});

     // OnModelCreatingPartial(modelBuilder);
    }

    
  }
  
}
