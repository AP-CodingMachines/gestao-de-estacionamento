using GestaoDeEstacionamento.Core.Dominio.ModuloVaga;
using GestaoDeEstacionamento.Infraestrutura.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeEstacionamento.Infraestrutura.ORM.ModuloVaga;
public class RepositorioVagaEmOrm(AppDbContext contexto) : RepositorioBaseORM<Vaga>(contexto), IRepositorioVaga
{
    public override async Task<List<Vaga>> SelecionarRegistrosAsync()
    {
        return await registros
            .Include(x => x.Veiculo)
            .ToListAsync();
    }

    public override async Task<Vaga?> SelecionarRegistroPorIdAsync(Guid id)
    {
        return await registros
            .Include(x => x.Veiculo)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Vaga?> SelecionarPorPlacaAsync(string placa)
    {
        return await registros
            .Include(x => x.Veiculo)
            .FirstOrDefault(x => x.Veiculo != null && x.Veiculo.Placa == placa);
    }
}
