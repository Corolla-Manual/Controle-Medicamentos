using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao.Entrada
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

        public override ArrayList Validar()
        {
            ArrayList erros = new();

            if (DataRequisicao == null)
                erros.Add("A data de requisição precisa ser preenchida");

            if (Medicamento == null)
                erros.Add("O Medicamento precisa ser informado");

            if (Fornecedor == null)
                erros.Add("O Fornecedor precisa ser informado");

            if (Funcionario == null)
                erros.Add("O Funcionario precisa ser informado");

            if (Paciente == null)
                erros.Add("O Paciente precisa ser informado");

            if (QuantidadeRequisitada < 1)
                erros.Add("Por favor informe uma quantidade válida");

            return erros;
        }
        public bool RequisitarMedicamento()
        {
            if (QuantidadeRequisitada == 0)
                return false;

            Medicamento.Quantidade += QuantidadeRequisitada;
            return true;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            RequisicaoEntrada reqEntrada = (RequisicaoEntrada)novoRegistro;
            this.DataRequisicao = reqEntrada.DataRequisicao;
            this.Medicamento = reqEntrada.Medicamento;
            this.Paciente = reqEntrada.Paciente;
            this.Fornecedor = reqEntrada.Fornecedor;
            this.Funcionario = reqEntrada.Funcionario;
            this.QuantidadeRequisitada = reqEntrada.QuantidadeRequisitada;
        }
    }
}
