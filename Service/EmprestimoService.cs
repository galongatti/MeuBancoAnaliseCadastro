using MeuBancoConsumerAnaliseCadastro.Model;
using MeuBancoConsumerAnaliseCadastro.Repository;

namespace MeuBancoConsumerAnaliseCadastro.Service
{
    public class EmprestimoService
    {
        private PessoaService _pessoaService;
        private EmprestimoRepository _emprestimoRepository;

        public EmprestimoService() 
        { 
            _pessoaService = new PessoaService();
            _emprestimoRepository = new EmprestimoRepository();
        }


        public Emprestimo AvaliarRenda(Emprestimo emprestimo)
        {
            Pessoa pessoa = _pessoaService.BuscarPessoa(emprestimo.IdPessoa);

            decimal razaoSalarioEmprestimo = Math.Round(pessoa.RendaBruta / emprestimo.ValorSolicitado, 2);
            int nota;

            if (razaoSalarioEmprestimo < new decimal(0.21)) nota = 10;
            else if (razaoSalarioEmprestimo < new decimal(0.41)) nota = 8;
            else if (razaoSalarioEmprestimo < new decimal(0.61)) nota = 7;
            else if (razaoSalarioEmprestimo < new decimal(0.81)) nota = 6;
            else if (razaoSalarioEmprestimo < new decimal(0.100)) nota = 5;
            else nota = 4;

            emprestimo.NotaSalario = nota;
            emprestimo.PercentualSalario = razaoSalarioEmprestimo;

            return emprestimo;
        }

          public void AtualarEmprestimo(Emprestimo emprestimo)
        {
            _emprestimoRepository.AtualizarEmprestimo(emprestimo);
        }



    }
}