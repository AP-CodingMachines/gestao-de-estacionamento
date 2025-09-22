namespace GestaoDeEstacionamento.WebAPI.Models.ModuloVaga;

public record SelecionarVagaPorIdRequest(Guid Id);

public record SelecionarVagaPorIdResponse(
    Guid Id,
    string Numero,
    bool Ocupada
    );

