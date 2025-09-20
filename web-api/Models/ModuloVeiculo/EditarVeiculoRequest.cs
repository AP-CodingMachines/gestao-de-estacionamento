namespace GestaoDeEstacionamento.WebAPI.Models.ModuloVeiculo;

public record EditarVeiculoRequest(
        string Placa,
        string Modelo,
        string Cor,
        string CpfHospede,
        string? Observacoes = null
    );

public record EditarVeiculoResponse(
    Guid TicketId,
    string Placa,
    string Modelo,
    string Cor,
    string CpfHospede,
    string? Observacoes,
    DateTime DataEntrada
);
