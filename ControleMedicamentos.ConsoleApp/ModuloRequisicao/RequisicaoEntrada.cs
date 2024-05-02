using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    internal class RequisicaoEntrada : EntidadeBase
    {
        public RequisicaoEntrada(DateTime dataRequisicao, Medicamento medicamento, Paciente paciente, Fornecedor fornecedor, Funcionario funcionario, int quantidadeRequisitada)
        {
            DataRequisicao = dataRequisicao;
            Medicamento = medicamento;
            Paciente = paciente;
            Fornecedor = fornecedor;
            Funcionario = funcionario;
            QuantidadeRequisitada = quantidadeRequisitada;
        }

        public DateTime DataRequisicao { get; set; }
        public Medicamento Medicamento { get; set; }
        public Paciente Paciente { get; set; }
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

            if (Paciente == null)
                erros[contadorErros++] = "O Paciente precisa ser informado";

            if (QuantidadeRequisitada < 1)
                erros[contadorErros++] = "Por favor informe uma quantidade válida";

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
        public bool RequisitarMedicamento()
        {
            if (QuantidadeRequisitada == 0)
                return false;

            Medicamento.Quantidade += QuantidadeRequisitada;
            return true;
        }
    }
}
