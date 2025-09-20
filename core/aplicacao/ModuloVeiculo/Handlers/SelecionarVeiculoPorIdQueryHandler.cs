using AutoMapper;
using FluentResults;
using GestaoDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
using GestaoDeEstacionamento.Core.Dominio.ModuloCheckIn;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GestaoDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Handlers;

public class SelecionarVeiculoPorIdQueryHandler(
    IRepositorioVeiculo repositorioVeiculo,
    IMapper mapper,
    ILogger<SelecionarVeiculoPorIdQueryHandler> logger
) : IRequestHandler<SelecionarVeiculoPorIdQuery, Result<SelecionarVeiculoPorIdResult>>
{
    public async Task<Result<SelecionarVeiculoPorIdResult>> Handle(
        SelecionarVeiculoPorIdQuery query, CancellationToken cancellationToken)
    {
        try
        {
            var veiculo = await repositorioVeiculo.SelecionarRegistroPorIdAsync(query.TicketId);

            if (veiculo is null)
                return Result.Fail($"Veículo com TicketId '{query.TicketId}' não encontrado.");

            var result = mapper.Map<SelecionarVeiculoPorIdResult>(veiculo);

            return Result.Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                "Ocorreu um erro durante a seleção de {@Veiculo}.",
                query
            );

            return Result.Fail("Erro interno ao selecionar o veículo.");
        }
    }
}