using FluentResults;
using GestaoDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
using GestaoDeEstacionamento.Core.Dominio.Compartilhado;
using GestaoDeEstacionamento.Core.Dominio.ModuloCheckIn;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace GestaoDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Handlers;

public class ExcluirVeiculoCommandHandler(
    IRepositorioVeiculo repositorio,
    IUnitOfWork unitOfWork,
    IDistributedCache cache,
    ILogger<ExcluirVeiculoCommandHandler> logger
) : IRequestHandler<ExcluirVeiculoCommand, Result<ExcluirVeiculoResult>>
{
    public async Task<Result<ExcluirVeiculoResult>> Handle(
        ExcluirVeiculoCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var veiculo = await repositorio.SelecionarRegistroPorIdAsync(command.Id);

            if (veiculo is null)
                return Result.Fail("Veículo não encontrado.");

            await repositorio.ExcluirRegistroAsync(veiculo.Id);
            await unitOfWork.CommitAsync();

            // Invalida cache de listagem de veículos
            await cache.RemoveAsync("veiculos:all", cancellationToken);

            var result = new ExcluirVeiculoResult();
            return Result.Ok(result);
        }
        catch (Exception ex)
        {
            await unitOfWork.RollbackAsync();
            logger.LogError(ex, "Ocorreu um erro durante a exclusão de {@Veiculo}.", command.Id);
            return Result.Fail("Erro interno ao excluir veículo.");
        }
    }
}