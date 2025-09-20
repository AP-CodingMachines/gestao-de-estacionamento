using AutoMapper;
using GestaoDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
using GestaoDeEstacionamento.Core.Dominio.ModuloCheckIn;
using System.Collections.Immutable;

namespace GestaoDeEstacionamento.Core.Aplicacao.AutoMapper;

public class VeiculoMappingProfile : Profile
{
    public VeiculoMappingProfile()
    {
        // Command -> Domain
        CreateMap<CadastrarVeiculoCommand, Veiculo>();

        // Domain -> Result
        CreateMap<Veiculo, CadastrarVeiculoResult>();

        // Command -> Domain
        CreateMap<EditarVeiculoCommand, Veiculo>();

        // Domain -> Result
        CreateMap<Veiculo, EditarVeiculoResult>();

        CreateMap<Veiculo, SelecionarVeiculoPorIdResult>()
            .ConvertUsing(src => new SelecionarVeiculoPorIdResult(
                src.Ticket,
                src.Placa ?? "",
                src.Modelo ?? "",
                src.Cor ?? "",
                src.CpfHospede ?? "",
                src.Observacoes,
                src.DataEntrada
            ));

        CreateMap<IEnumerable<Veiculo>, SelecionarVeiculosResult>()
            .ConvertUsing((src, dest, ctx) =>
                new SelecionarVeiculosResult(
                    src?.Select(v => ctx.Mapper.Map<SelecionarVeiculosDto>(v))
                       .ToImmutableList()
                       ?? ImmutableList<SelecionarVeiculosDto>.Empty
                )
            );

        CreateMap<Veiculo, SelecionarVeiculosDto>()
            .ConvertUsing(src => new SelecionarVeiculosDto(
                src.Ticket,
                src.Placa ?? "",
                src.Modelo ?? "",
                src.Cor ?? "",
                src.CpfHospede ?? "",
                src.Observacoes,
                src.DataEntrada
            ));
    }
}