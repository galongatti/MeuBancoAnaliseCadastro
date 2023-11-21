using System.Data.SqlClient;
using Dapper;
using MeuBancoConsumerAnaliseCadastro.Connection;
using MeuBancoConsumerAnaliseCadastro.Model;

namespace MeuBancoConsumerAnaliseCadastro.Repository
{

    public class PessoaRepository
    {
        public PessoaRepository() { }

        public Pessoa BuscarPessoa(long IdPessoa)
        {
            string sql = "SELECT * FROM Pessoa WHERE IdPessoa = @IdPessoa";
            using (CustomSQLConnection customSQL = new CustomSQLConnection())
            {
                SqlConnection sqlConnection = customSQL.ConexaoBanco();
                Pessoa resultado = sqlConnection.Query<Pessoa>(sql, new { IdPessoa = IdPessoa }).First();
                return resultado;
            }
        }
    }
}