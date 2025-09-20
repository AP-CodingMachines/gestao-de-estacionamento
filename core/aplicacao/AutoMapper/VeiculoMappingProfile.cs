using AutoMapper;
using GestaoDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
using GestaoDeEstacionamento.Core.Dominio.ModuloCheckIn;

namespace GestaoDeEstacionamento.Core.Aplicacao.AutoMapper;

public class VeiculoMappingProfile : Profile
{
    public VeiculoMappingProfile()
    {
        // Command -> Domain
        CreateMap<CadastrarVeiculoCommand, Veiculo>();

        // Domain -> Result
        CreateMap<Veiculo, CadastrarVeiculoResult>();
    }
}