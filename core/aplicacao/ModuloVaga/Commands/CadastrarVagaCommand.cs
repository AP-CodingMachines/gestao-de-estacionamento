using FluentResults;
using MediatR;

namespace GestaoDeEstacionamento.Core.Aplicacao.ModuloVaga.Commands;
public record CadastrarVagaCommand(string Numero) : IRequest<Result<CadastrarVagaResult>>;

public record CadastrarVagaResult(Guid Id);
