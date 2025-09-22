namespace GestaoDeEstacionamento.WebAPI.Models.ModuloVaga;

public record CadastrarVagaRequest(string Numero);

public record CadastrarVagaResponse(Guid Id);
