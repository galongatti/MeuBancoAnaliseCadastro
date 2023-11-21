using MeuBancoConsumerAnaliseCadastro.Model;
using MeuBancoConsumerAnaliseCadastro.Repository;

namespace MeuBancoConsumerAnaliseCadastro.Service
{
   
    public class PessoaService
    {
        private PessoaRepository _pessoaRepository; 

        public PessoaService() 
        { 
            _pessoaRepository = new PessoaRepository();
        }


        public Pessoa BuscarPessoa(long IdPessoa)
        {
            return _pessoaRepository.BuscarPessoa(IdPessoa);
        }
    }
}