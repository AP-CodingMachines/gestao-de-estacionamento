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
public class EditarVagaCommandHandler(
    IRepositorioVaga repositorioVaga,
    ITenantProvider tenantProvider,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    ILogger<EditarVagaCommandHandler> logger
    ) : IRequestHandler<EditarVagaCommand, Result<EditarVagaResult>>
{
    public async Task<Result<EditarVagaResult>> Handle(EditarVagaCommand command, CancellationToken cancellationToken) 
    {
        try
        {
            var vagaEditada = mapper.Map<Vaga>(command);

            vagaEditada.UsuarioId = tenantProvider.UsuarioId.GetValueOrDefault();

            await repositorioVaga.EditarRegistroAsync(command.Id, vagaEditada);

            await unitOfWork.CommitAsync();

            var result = mapper.Map<EditarVagaResult>(vagaEditada);

            return Result.Ok(result);
        }
        catch (Exception ex)
        {
            await unitOfWork.RollbackAsync();

            logger.LogError(
                ex,
                "Ocorreu um erro durante a edição de {@Registro}",
                command
                );

            return Result.Fail(ResultadosErro.ExcecaoInternaErro(ex));
            
        }
    }
}
