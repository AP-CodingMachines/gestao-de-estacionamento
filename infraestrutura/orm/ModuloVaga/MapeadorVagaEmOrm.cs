using GestaoDeEstacionamento.Core.Dominio.ModuloVaga;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GestaoDeEstacionamento.Infraestrutura.ORM.ModuloVaga;
public class MapeadorVagaEmOrm : IEntityTypeConfiguration<Vaga>
{
    public void Configure(EntityTypeBuilder<Vaga> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired();
        
        builder.Property(x => x.Numero)
            .IsRequired();

        builder.Property(x => x.Ocupada)
            .IsRequired();

    }
}
