using AutoMapper;
using GestaoDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
using GestaoDeEstacionamento.Core.Dominio.ModuloCheckIn;
using GestaoDeEstacionamento.WebAPI.Models.ModuloVeiculo;
using System.Collections.Immutable;

namespace GestaoDeEstacionamento.WebAPI.AutoMapper;

public class VeiculoRequestMappingProfile : Profile
{
    public VeiculoRequestMappingProfile()
    {
        // Request -> Command
        CreateMap<CadastrarVeiculoRequest, CadastrarVeiculoCommand>();

        // Result -> Response (usando construtor explícito, já que o Response é positional record)
        CreateMap<CadastrarVeiculoResult, CadastrarVeiculoResponse>()
            .ConstructUsing(src => new CadastrarVeiculoResponse(
                src.Ticket,
                src.Placa,
                src.Modelo,
                src.Cor,
                src.CpfHospede,
                src.Observacoes,
                src.DataEntrada
            ));

        // Request -> Command (Editar)
        CreateMap<(Guid, EditarVeiculoRequest), EditarVeiculoCommand>()
            .ConvertUsing(src => new EditarVeiculoCommand(
                src.Item1,
                src.Item2.Placa,
                src.Item2.Modelo,
                src.Item2.Cor,
                src.Item2.CpfHospede,
                src.Item2.Observacoes
            ));

        // Result -> Response (Editar)
        CreateMap<EditarVeiculoResult, EditarVeiculoResponse>()
            .ConvertUsing(src => new EditarVeiculoResponse(
                src.Ticket,
                src.Placa,
                src.Modelo,
                src.Cor,
                src.CpfHospede,
                src.Observacoes,
                src.DataEntrada
            ));

        CreateMap<Veiculo, SelecionarVeiculoPorIdResponse>()
            .ConvertUsing(src => new SelecionarVeiculoPorIdResponse(
                src.Ticket,
                src.Placa ?? "",
                src.Modelo ?? "",
                src.Cor ?? "",
                src.CpfHospede ?? "",
                src.Observacoes ?? "",
                src.DataEntrada
            ));

        // Veículo -> SelecionarVeiculosDto (para lista)
        CreateMap<Veiculo, SelecionarVeiculosDto>()
            .ConvertUsing(src => new SelecionarVeiculosDto(
                src.Ticket,
                src.Placa ?? "",
                src.Modelo ?? "",
                src.Cor ?? "",
                src.CpfHospede ?? "",
                src.Observacoes ?? "",
                src.DataEntrada
            ));

        // IEnumerable<Veiculo> -> SelecionarVeiculosResult
        CreateMap<IEnumerable<Veiculo>, SelecionarVeiculosResult>()
            .ConvertUsing((src, dest, ctx) =>
                new SelecionarVeiculosResult(
                    src?.Select(v => ctx.Mapper.Map<SelecionarVeiculosDto>(v))
                       .ToImmutableList()
                       ?? ImmutableList<SelecionarVeiculosDto>.Empty
                )
            );

        // SelecionarVeiculosResult -> SelecionarVeiculosResponse (para WebAPI)
        CreateMap<SelecionarVeiculosResult, SelecionarVeiculosResponse>()
            .ConvertUsing((src, dest, ctx) =>
                new SelecionarVeiculosResponse(
                    src.Veiculos.Select(v => ctx.Mapper.Map<SelecionarVeiculosResponseDto>(v))
                                .ToImmutableList()
                )
            );

        // DTO individual para Response
        CreateMap<SelecionarVeiculosDto, SelecionarVeiculosResponseDto>()
            .ConvertUsing(src => new SelecionarVeiculosResponseDto(
                src.TicketId,
                src.Placa,
                src.Modelo,
                src.Cor,
                src.CpfHospede,
                src.Observacoes,
                src.DataEntrada
            ));
    }
}
