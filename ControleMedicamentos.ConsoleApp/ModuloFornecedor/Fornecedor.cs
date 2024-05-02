using ControleMedicamentos.ConsoleApp.Compartilhado;

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

        public override string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros[contadorErros++] = ("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Telefone.Trim()))
                erros[contadorErros++] = ("O campo \"Telefone\" é obrigatório");

            if (string.IsNullOrEmpty(CNPJ.Trim()))
                erros[contadorErros++] = ("O campo \"CNPJ\" é obrigatório");

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
    }
}
