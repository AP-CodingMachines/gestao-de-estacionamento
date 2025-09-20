using System.Collections.Immutable;

namespace GestaoDeEstacionamento.WebAPI.Models.ModuloVeiculo;

public record SelecionarVeiculosResponseDto(
    Guid TicketId,
    string Placa,
    string Modelo,
    string Cor,
    string CpfHospede,
    string? Observacoes,
    DateTime DataEntrada
);

public record SelecionarVeiculosResponse(
    ImmutableList<SelecionarVeiculosResponseDto> Veiculos
);