using AutoMapper;
using FluentResults;
using GestaoDeEstacionamento.Core.Aplicacao.Compartilhado;
using GestaoDeEstacionamento.Core.Aplicacao.ModuloVaga.Commands;
using GestaoDeEstacionamento.Core.Dominio.ModuloVaga;
using MediatR;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GestaoDeEstacionamento.Core.Aplicacao.ModuloVaga.Handlers;
public class SelecionarVagaPorPlacaQueryHandler(
    IMapper mapper,
    IRepositorioVaga repositorioVaga,
    ILogger<SelecionarVagaPorPlacaQueryHandler> logger
    ) : IRequestHandler<SelecionarVagaPorPlacaQuery, Result<SelecionarVagaPorPlacaResult>>
{
    public async Task<Result<SelecionarVagaPorPlacaResult>> Handle(SelecionarVagaPorPlacaQuery query, CancellationToken cancellationToken)
    {
        try
        {
            var registro = await repositorioVaga.SelecionarPorPlacaAsync(query.Placa);

            if (registro is null)
                return Result.Fail("Placa não encontrada.");

            var result = mapper.Map<SelecionarVagaPorPlacaResult>(registro);

            return Result.Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(
                 ex,
                 "Ocorreu um erro durante a seleção da vaga pela placa {@Query}.",
                 query
             );
            return Result.Fail(ResultadosErro.ExcecaoInternaErro(ex));
        }
    }
}
