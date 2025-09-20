using FluentValidation;
using GestaoDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;

namespace GestaoDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Validators;

public class EditarVeiculoCommandValidator : AbstractValidator<EditarVeiculoCommand>
{
    public EditarVeiculoCommandValidator()
    {
        RuleFor(x => x.Placa)
            .NotEmpty().WithMessage("A placa é obrigatória")
            .Length(7).WithMessage("A placa deve ter 7 caracteres");

        RuleFor(x => x.Modelo)
            .NotEmpty().WithMessage("O modelo é obrigatório");
    }
}
