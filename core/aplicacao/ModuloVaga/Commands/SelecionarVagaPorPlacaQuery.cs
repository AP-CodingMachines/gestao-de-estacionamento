using FluentResults;
using MediatR;

namespace GestaoDeEstacionamento.Core.Aplicacao.ModuloVaga.Commands;
public record SelecionarVagaPorPlacaQuery(string Placa) : IRequest<Result<SelecionarVagaPorPlacaResult>>;

public record SelecionarVagaPorPlacaResult(
    Guid Id, 
    string Numero, 
    string Placa
    );

