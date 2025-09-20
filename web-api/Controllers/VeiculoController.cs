using AutoMapper;
using FluentResults;
using GestaoDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
using GestaoDeEstacionamento.WebAPI.Models.ModuloVeiculo;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEstacionamento.WebAPI.Controllers;

[ApiController]
[Authorize]
[Route("veiculos")]
public class VeiculoController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CadastrarVeiculoResponse>> Cadastrar(CadastrarVeiculoRequest request)
    {
        try
        {
            var command = mapper.Map<CadastrarVeiculoCommand>(request);
            var result = await mediator.Send(command);

            if (result.IsFailed)
            {
                if (result.HasError(e => e.HasMetadataKey("TipoErro")))
                {
                    var errosDeValidacao = result.Errors
                        .SelectMany(e => e.Reasons.OfType<IError>())
                        .Select(e => e.Message);

                    return BadRequest(errosDeValidacao);
                }

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var response = mapper.Map<CadastrarVeiculoResponse>(result.Value);

            return Created(string.Empty, response);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, statusCode: 500);
        }
    }
}
