using System.Data.SqlClient;
using Dapper;
using MeuBancoConsumerAnaliseCadastro.Connection;
using MeuBancoConsumerAnaliseCadastro.Model;

namespace MeuBancoConsumerAnaliseCadastro.Repository
{
    public class EmprestimoRepository
    {
        public EmprestimoRepository() { }

        public void AtualizarEmprestimo(Emprestimo emprestimo)
        {
            string sql = "UPDATE Emprestimo SET NotaSalario = @NotaSalario, PercentualSalario = @PercentualSalario WHERE IdEmprestimo = @IdEmprestimo;";

            using (CustomSQLConnection customSQL = new CustomSQLConnection())
            {
                SqlConnection sqlConnection = customSQL.ConexaoBanco();
                var affectedRows = sqlConnection.Execute(sql, new { NotaSalario = emprestimo.NotaSalario, PercentualSalario = emprestimo.PercentualSalario, IdEmprestimo = emprestimo.IdEmprestimo });
            }
        }
    }

}