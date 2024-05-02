using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    internal class TelaRequisicaoEntrada : TelaBase
    {
        public TelaMedicamento telaMedicamento = null;
        public TelaPaciente telaPaciente = null;
        public TelaFuncionario telaFuncionario = null;
        public TelaFornecedor telaFornecedor = null;

        public RepositorioFuncionario repositorioFuncionario = null;
        public RepositorioPaciente repositorioPaciente = null;
        public RepositorioMedicamento repositorioMedicamento = null;
        public RepositorioFornecedor repositorioFornecedor = null;

        public override void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}");

            Console.WriteLine();

            RequisicaoEntrada entidade = (RequisicaoEntrada)ObterRegistro();

            string[] erros = entidade.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            bool conseguiuRetirar = entidade.RequisitarMedicamento();

            if (!conseguiuRetirar)
            {
                ExibirMensagem("A quantidade de requisitada informada deve ser maior que zero.", ConsoleColor.DarkYellow);
                return;
            }

            repositorio.Cadastrar(entidade);

            ExibirMensagem($"O {tipoEntidade} foi cadastrado com sucesso!", ConsoleColor.Green);
        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Requisições de Entrada...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -15} | {4, -20} | {5, -5}",
                "Id", "Funcionário", "Medicamento", "Paciente", "Data de Requisição", "Quantidade"
            );

            EntidadeBase[] requisicoesCadastradas = repositorio.SelecionarTodos();

            foreach (RequisicaoEntrada requisicao in requisicoesCadastradas)
            {
                if (requisicao == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -15} | {4, -20} | {5, -5}",
                    requisicao.Id,
                    requisicao.Funcionario.Nome,
                    requisicao.Medicamento.Nome,
                    requisicao.Paciente.Nome,
                    requisicao.DataRequisicao.ToShortDateString(),
                    requisicao.QuantidadeRequisitada
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            telaMedicamento.VisualizarRegistros(false);
            Console.Write("Digite o ID do medicamento requisitado: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());
            Medicamento medicamentoSelecionado = (Medicamento)repositorioMedicamento.SelecionarPorId(idMedicamento);

            telaPaciente.VisualizarRegistros(false);
            Console.Write("Digite o ID do paciente requisitante: ");
            int idPaciente = Convert.ToInt32(Console.ReadLine());
            Paciente pacienteSelecionado = (Paciente)repositorioPaciente.SelecionarPorId(idPaciente);

            telaFuncionario.VisualizarRegistros(false);
            Console.Write("Digite o ID do funcionário que está registrando a requisição: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());
            Funcionario funcionarioSelecionado = (Funcionario)repositorioFuncionario.SelecionarPorId(idFuncionario);

            telaFornecedor.VisualizarRegistros(false);
            Console.Write("Digite o ID do fornecedor que será requisitado: ");
            int idFornecedor = Convert.ToInt32(Console.ReadLine());
            Fornecedor fornecedorSelecionado = (Fornecedor)repositorioFornecedor.SelecionarPorId(idFornecedor);

            Console.Write("Digite a quantidade do medicamente que deseja requisitar: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            DateTime dataRequisicao = DateTime.Now;

            RequisicaoEntrada novaRequisicao = new RequisicaoEntrada(dataRequisicao, medicamentoSelecionado,
                pacienteSelecionado, fornecedorSelecionado, funcionarioSelecionado, quantidade);

            return novaRequisicao;
        }

    }
}
