using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    internal class RequisicaoEntrada : EntidadeBase
    {
        public DateTime DataRequisicao { get; set; }
        public Medicamento Medicamento { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public Funcionario Funcionario { get; set; }
        public int QuantidadeRequisitada { get; set; }

        public override string[] Validar()
        {
            string[] erros = new string[5];
            int contadorErros = 0;

            if (DataRequisicao == null)
                erros[contadorErros++] = "A data de requisição precisa ser preenchida";

            if (Medicamento == null)
                erros[contadorErros++] = "O Medicamento precisa ser informado";

            if (Fornecedor == null)
                erros[contadorErros++] = "O Fornecedor precisa ser informado";

            if (Funcionario == null)
                erros[contadorErros++] = "O Funcionario precisa ser informado";

            if (QuantidadeRequisitada < 1)
                erros[contadorErros++] = "Por favor informe uma quantidade válida";

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
        public bool RequisitarMedicamento()
        {
            if (Medicamento.Quantidade < QuantidadeRequisitada)
                return false;

            Medicamento.Quantidade += QuantidadeRequisitada;
            return true;
        }
    }
}
