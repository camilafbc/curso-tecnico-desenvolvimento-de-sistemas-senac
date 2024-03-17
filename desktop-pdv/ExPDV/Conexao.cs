using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExPDV
{
    internal class Conexao
    {
        Config_example config = new Config_example();

        public MySqlConnection connection = null;
        public string connectionString = null;
        public string sql;

        public void MySQLCRUD()
        {
            connectionString = config.StringConnection();
            connection = new MySqlConnection(connectionString);
        }

        public Boolean AbrirConexao()
        {
            try
            {
                MySQLCRUD();

                if (connection.State == ConnectionState.Closed)
                {
                    connection = new MySqlConnection(connectionString);
                    connection.Open();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar conectar ao banco: " + ex.Message);

                return false;
            }
        }

        public void FecharConexao()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection = new MySqlConnection(connectionString);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // retornar dados no dataGrid
        public DataTable GetData(string query)
        {
            try
            {
                AbrirConexao();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                return null;
            }
            finally
            {
                FecharConexao();
            }
        }

        public bool ExecuteQuery(string query)
        {
            try
            {
                AbrirConexao();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
                return false;
            }
            finally
            {
                FecharConexao();
            }
        }

        public bool InserirProduto(string descricao, int quantidade, int valor_unitario, string data, string hora_entrada)
        {
            try
            {
                AbrirConexao();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO ex_pdv (descricao, quantidade, valor_unitario, vencimento, hora_entrada) VALUES (@descricao, @quantidade, @valor_unitario, @data, @hora_entrada)"; // adequar o nome dos campos e parâmetros
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@quantidade", quantidade);
                cmd.Parameters.AddWithValue("@valor_unitario", valor_unitario);
                cmd.Parameters.AddWithValue("@data", data);
                cmd.Parameters.AddWithValue("@hora_entrada", hora_entrada);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
                return false;
            }
            finally
            {
                FecharConexao();
            }
        }

        public bool InserirItens(int codigo_compra,  int codigo_produto, int quantidade, int valor_unitario, string data_compra, int id_caixa, string status, string pagamento)
        {
            try
            {
                AbrirConexao();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO ex_pdv_vendas (codigo_compra, codigo_produto, quantidade, valor_unitario, data, id_caixa, status, pagamento) VALUES (@codigo_compra, @codigo_produto, @quantidade, @valor_unitario, @data_compra, @id_caixa, @status, @pagamento)";
                cmd.Parameters.AddWithValue("@codigo_compra", codigo_compra);
                cmd.Parameters.AddWithValue("@codigo_produto", codigo_produto);
                cmd.Parameters.AddWithValue("@quantidade", quantidade);
                cmd.Parameters.AddWithValue("@valor_unitario", valor_unitario);
                cmd.Parameters.AddWithValue("@data_compra", data_compra);
                cmd.Parameters.AddWithValue("@id_caixa", id_caixa);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@pagamento", pagamento);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
                return false;
            }
            finally
            {
                FecharConexao();
            }
        }

        public bool AtualizarProduto(int codigo, string descricao, int quantidade, int valor_unitario)
        {
            try
            {
                AbrirConexao();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE ex_pdv SET descricao=@descricao, quantidade=@quantidade, valor_unitario=@valor_unitario WHERE codigo=@codigo"; 
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@quantidade", quantidade);
                cmd.Parameters.AddWithValue("@valor_unitario", valor_unitario);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
                return false;
            }
            finally
            {
                FecharConexao();
            }
        }

        public bool AtualizarEstoque(int quantidade, int codigo) 
        {
            try
            {
                AbrirConexao();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE ex_pdv SET quantidade=@quantidade WHERE codigo=@codigo"; 
                cmd.Parameters.AddWithValue("@quantidade", quantidade);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
                return false;
            }
            finally
            {
                FecharConexao();
            }
        }

        public bool AtualizarPedido(int codigo_compra,  string status, string pagamento) 
        {
            try
            {
                AbrirConexao();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE ex_pdv_vendas SET status=@status, pagamento=@pagamento WHERE codigo_compra=@codigo_compra"; 
                cmd.Parameters.AddWithValue("@codigo_compra", codigo_compra);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@pagamento", pagamento);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
                return false;
            }
            finally
            {
                FecharConexao();
            }
        }
        public int QuantidadeRegistros(string query)
        {
            try
            {
                int i = 0;
                AbrirConexao();
                string sql = query;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    i++;
                }
                return i;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
                return 0;
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
