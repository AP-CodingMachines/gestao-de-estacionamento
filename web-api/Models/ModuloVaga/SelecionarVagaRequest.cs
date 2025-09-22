using GestaoDeEstacionamento.Core.Aplicacao.ModuloVaga.Commands;
using System.Collections.Immutable;

namespace GestaoDeEstacionamento.WebAPI.Models.ModuloVaga;

public record SelecionarVagaRequest(int? Quantidade);

public record SelecionarVagaResponse(
    int Quantidade,
    ImmutableList<SelecionarVagasDto> Vagas
    );

