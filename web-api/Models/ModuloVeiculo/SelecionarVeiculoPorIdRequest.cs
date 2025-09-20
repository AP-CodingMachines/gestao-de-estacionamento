namespace GestaoDeEstacionamento.WebAPI.Models.ModuloVeiculo;

public record SelecionarVeiculoPorIdResponse(
    Guid TicketId,
    string Placa,
    string Modelo,
    string Cor,
    string CpfHospede,
    string? Observacoes,
    DateTime DataEntrada
);