namespace GestaoDeEstacionamento.WebAPI.Models.ModuloVaga;

public record EditarVagaRequest(string Numero, bool Ocupada);

public record EditarVagaResponse( string Numero, bool Ocupada);

