using AutoMapper;
using FluentResults;
using GestaoDeEstacionamento.Core.Aplicacao.Compartilhado;
using GestaoDeEstacionamento.Core.Aplicacao.ModuloVaga.Commands;
using GestaoDeEstacionamento.Core.Dominio.Compartilhado;
using GestaoDeEstacionamento.Core.Dominio.ModuloAutenticacao;
using GestaoDeEstacionamento.Core.Dominio.ModuloVaga;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GestaoDeEstacionamento.Core.Aplicacao.ModuloVaga.Handlers;
public class CadastrarVagaCommandHandler(
    IRepositorioVaga repositorioVaga, 
    ITenantProvider tenantProvider, 
    IUnitOfWork unitOfWork,
    IMapper mapper,
    ILogger<CadastrarVagaCommandHandler> logger
    ) : IRequestHandler<CadastrarVagaCommand, Result<CadastrarVagaResult>>
{
    public async Task<Result<CadastrarVagaResult>> Handle(CadastrarVagaCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var vaga = mapper.Map<Vaga>(command);

            vaga.UsuarioId = tenantProvider.UsuarioId.GetValueOrDefault();

            await repositorioVaga.CadastrarRegistroAsync(vaga);

            await unitOfWork.CommitAsync();

            var result = mapper.Map<CadastrarVagaResult>(vaga);

            return Result.Ok(result);
        }
        catch (Exception ex)
        {
            await unitOfWork.RollbackAsync();

            logger.LogError(
                ex,
                "Ocorreu um erro durante o registro de {@Registro}.",
                command
                );

            return Result.Fail(ResultadosErro.ExcecaoInternaErro(ex));
        }
    }

}
