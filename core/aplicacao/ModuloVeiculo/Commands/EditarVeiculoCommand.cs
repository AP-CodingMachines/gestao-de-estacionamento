using FluentResults;
using MediatR;

namespace GestaoDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;

public record EditarVeiculoCommand(
    Guid Id,
    string Placa,
    string Modelo,
    string Cor,
    string CpfHospede,
    string? Observacoes = null
) : IRequest<Result<EditarVeiculoResult>>;

public record EditarVeiculoResult(
    Guid Ticket,
    string Placa,
    string Modelo,
    string Cor,
    string CpfHospede,
    string? Observacoes,
    DateTime DataEntrada
);