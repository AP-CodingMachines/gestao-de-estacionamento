using GestaoDeEstacionamento.Core.Dominio.Compartilhado;

namespace GestaoDeEstacionamento.Core.Dominio.ModuloVaga;
public class Vaga : EntidadeBase<Vaga>
{
    public string Numero { get; set; }
    public bool Ocupada { get; set; }
    public Veiculo? Veiculo { get; set; }

    public Vaga(){}

    public Vaga(string numero) : this()
    {
        Numero = numero;
        Ocupada = false;
        Veiculo = null;
    }

    public override void AtualizarRegistro(Vaga registroEditado)
    {
        Numero = registroEditado.Numero;
        Ocupada = registroEditado.Ocupada;
    }

    public void Ocupar(Veiculo veiculo) 
    {
        Ocupada = true;
        Veiculo = veiculo;
    }

    public void Desocupar() 
    {
        Ocupada = false;
        Veiculo = null;
    }
}
