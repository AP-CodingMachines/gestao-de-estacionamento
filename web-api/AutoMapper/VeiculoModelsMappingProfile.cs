using AutoMapper;
using GestaoDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
using GestaoDeEstacionamento.Core.Dominio.ModuloCheckIn;
using GestaoDeEstacionamento.WebAPI.Models.ModuloVeiculo;

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
    }
}
