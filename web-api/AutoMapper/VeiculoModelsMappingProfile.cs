using AutoMapper;
using GestaoDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
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

        // Se futuramente tiver mais operações (Editar, Excluir, Selecionar, etc.),
        // basta seguir o mesmo padrão daqui pra frente.
    }
}
