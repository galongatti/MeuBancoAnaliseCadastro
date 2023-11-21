using System.Data.SqlClient;
using MeuBancoConsumerAnaliseCadastro.Configurations;

namespace MeuBancoConsumerAnaliseCadastro.Connection
{
    public class CustomSQLConnection : IDisposable
    {
        private IConfiguration _configuration;
        private SqlConnection _sqlConn;

        public CustomSQLConnection()
        {
            _configuration = Configuration.MyConfiguration;
            _sqlConn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public SqlConnection ConexaoBanco()
        {
            return _sqlConn;
        }

        public void Dispose()
        {
            _sqlConn.Close();
            GC.SuppressFinalize(this);
        }
    }
}