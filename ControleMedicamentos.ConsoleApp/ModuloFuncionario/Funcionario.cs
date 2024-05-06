using ControleMedicamentos.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionario
{
    internal class Funcionario : EntidadeBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }

        public Funcionario(string nome, string cpf, string telefone)
        {
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
        }
        public override ArrayList Validar()
        {
            ArrayList erros = new();

            if (Nome.Length < 3)
                erros.Add("O Nome do Funcionário precisa conter ao menos 3 caracteres");

            if (string.IsNullOrEmpty(Telefone))
                erros.Add("O Telefone precisa ser preenchido");

            if (string.IsNullOrEmpty(CPF))
                erros.Add("O CPF precisa ser preenchido");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Funcionario funcionario = (Funcionario)novoRegistro;

            this.Nome = funcionario.Nome;
            this.Telefone = funcionario.Telefone;
            this.CPF = funcionario.CPF;
        }
    }
}
