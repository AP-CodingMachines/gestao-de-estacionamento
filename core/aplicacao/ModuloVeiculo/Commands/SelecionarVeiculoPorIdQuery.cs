using FluentResults;
using MediatR;

namespace GestaoDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;

public record SelecionarVeiculoPorIdQuery(Guid TicketId)
    : IRequest<Result<SelecionarVeiculoPorIdResult>>;

public record SelecionarVeiculoPorIdResult(
    Guid TicketId,
    string Placa,
    string Modelo,
    string Cor,
    string CpfHospede,
    string? Observacoes,
    DateTime DataEntrada
);