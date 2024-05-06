using ControleMedicamentos.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloFornecedor
{
    internal class Fornecedor : EntidadeBase
    {
        public Fornecedor(string nome, string telefone, string cNPJ)
        {
            Nome = nome;
            Telefone = telefone;
            CNPJ = cNPJ;
        }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CNPJ { get; set; }

        public override ArrayList Validar()
        {
            ArrayList erros = new();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Telefone.Trim()))
                erros.Add("O campo \"Telefone\" é obrigatório");

            if (string.IsNullOrEmpty(CNPJ.Trim()))
                erros.Add("O campo \"CNPJ\" é obrigatório");
            return erros;
        }
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Fornecedor fornecedor = (Fornecedor)novoRegistro;

            this.Nome = fornecedor.Nome;
            this.Telefone = fornecedor.Telefone;
            this.CNPJ = fornecedor.CNPJ;
        }
    }
}
