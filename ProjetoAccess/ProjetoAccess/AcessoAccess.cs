using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;

namespace ProjetoAccess
{
    public class AcessoAccess
    {
        private string stringConexao;
        private string sql;

        public AcessoAccess()
        {
            stringConexao = ConfigurationManager.AppSettings["Access"].ToString();
            sql = "INSERT INTO SMS (Telefone, Valor, Conta, Transacao, DataEnvio, HoraEnvio, RespostaCliente, DataRecebimento, HoraRecebimento) " +
                "VALUES (@Telefone, @Valor, @Conta, @Transacao, @DataEnvio, @HoraEnvio, @RespostaCliente, @DataRecibimento, @HoraRecibimento)";
        }

        public void GravarAccessSMS(List<SMS> smss)
        {   
            using (OleDbConnection conexao = new OleDbConnection(stringConexao))
            {
                using (OleDbCommand comando = new OleDbCommand(sql, conexao))
                {
                    conexao.Open();

                    foreach (var sms in smss)
                    {
                        comando.Parameters.AddWithValue("@Telefone", sms.Telefone);
                        comando.Parameters.AddWithValue("@Valor", sms.Valor);
                        comando.Parameters.AddWithValue("@Conta", sms.Conta);
                        comando.Parameters.AddWithValue("@Transacao", sms.Transacao);
                        comando.Parameters.AddWithValue("@DataEnvio", sms.DataEnvio.ToString().Substring(0, 10));
                        comando.Parameters.AddWithValue("@HoraEnvio", sms.DataEnvio.ToString().Substring(11, 8));
                        comando.Parameters.AddWithValue("@RespostaCliente", sms.RespostaCliente);
                        comando.Parameters.AddWithValue("@DataRecibimento", sms.DataRecibimento.ToString().Substring(0, 10));
                        comando.Parameters.AddWithValue("@HoraRecibimento", sms.DataRecibimento.ToString().Substring(11, 8));

                        comando.ExecuteNonQuery();

                        comando.Parameters.Clear();
                    }                                        
                }
            }            
        }
    }
}
