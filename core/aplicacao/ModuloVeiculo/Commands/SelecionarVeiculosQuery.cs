using FluentResults;
using MediatR;
using System.Collections.Immutable;

namespace GestaoDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;

public record SelecionarVeiculosQuery(int? Quantidade = null)
    : IRequest<Result<SelecionarVeiculosResult>>;

public record SelecionarVeiculosResult(
    ImmutableList<SelecionarVeiculosDto> Veiculos
);

public record SelecionarVeiculosDto(
    Guid TicketId,
    string Placa,
    string Modelo,
    string Cor,
    string CpfHospede,
    string? Observacoes,
    DateTime DataEntrada
);