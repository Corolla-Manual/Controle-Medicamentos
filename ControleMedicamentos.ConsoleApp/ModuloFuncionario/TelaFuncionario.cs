using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionario
{
    internal class TelaFuncionario : TelaBase
    {
        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome do funcionário: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o Cpf do funcionário: ");
            string cpf = Console.ReadLine();

            Console.Write("Digite o telefone do funcionário: ");
            string telefone = Console.ReadLine();

            Funcionario funcionario = new Funcionario(nome, cpf, telefone);

            return funcionario;
        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Funcionarios...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -12}",
                "Id", "Nome", "Cpf", "Telefone"
            );

            EntidadeBase[] funcionariosCadastrados = repositorio.SelecionarTodos();

            foreach (Funcionario funcionario in funcionariosCadastrados)
            {
                if (funcionario == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -12}",
                    funcionario.Id, funcionario.Nome, funcionario.CPF, funcionario.Telefone
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }
    }
}
