
using FluentResults;
using MediatR;

namespace GestaoDeEstacionamento.Core.Aplicacao.ModuloVaga.Commands;
public record EditarVagaCommand(
    Guid Id, 
    string Numero, 
    bool Ocupada) : IRequest<Result<EditarVagaResult>>;


public record EditarVagaResult(
    string Numero, 
    bool Ocupada
    );
