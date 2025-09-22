using AutoMapper;
using GestaoDeEstacionamento.Core.Aplicacao.ModuloVaga.Commands;
using GestaoDeEstacionamento.WebAPI.Models.ModuloVaga;
using System.Collections.Immutable;

namespace GestaoDeEstacionamento.WebAPI.AutoMapper;

public class VagaModelsMappingProfile : Profile
{
    public VagaModelsMappingProfile()
    {
        CreateMap<CadastrarVagaRequest, CadastrarVagaCommand>();
        CreateMap<CadastrarVagaResult, CadastrarVagaResponse>();

        CreateMap<(Guid, EditarVagaRequest), EditarVagaCommand>()
            .ConvertUsing(src => new EditarVagaCommand(
                src.Item1,
                src.Item2.Numero,
                src.Item2.Ocupada
                ));

        CreateMap<EditarVagaResult, EditarVagaResponse>();

        CreateMap<Guid, ExcluirVagaCommand>()
            .ConstructUsing(src => new ExcluirVagaCommand(src));

        CreateMap<SelecionarVagaPorPlacaRequest, SelecionarVagaPorPlacaQuery>();
        CreateMap<SelecionarVagaPorPlacaResult, SelecionarVagaPorPlacaResponse>();


        CreateMap<SelecionarVagaRequest, SelecionarVagasQuery>();

        CreateMap<SelecionarVagasResult, SelecionarVagaResponse>()
            .ConvertUsing((src, dest, ctx) => new SelecionarVagaResponse(
                src.Vagas.Count,
                src?.Vagas.Select(c => ctx.Mapper.Map<SelecionarVagasDto>(c)).ToImmutableList() ?? ImmutableList<SelecionarVagasDto>.Empty
            ));

        CreateMap<Guid, SelecionarVagaPorIdQuery>()
            .ConvertUsing(src => new SelecionarVagaPorIdQuery(src));

        CreateMap<SelecionarVagaPorIdResult, SelecionarVagaPorIdResponse>()
            .ConvertUsing(src => new SelecionarVagaPorIdResponse(
                src.Id,
                src.Numero,
                src.Ocupada
            ));
    }
}
