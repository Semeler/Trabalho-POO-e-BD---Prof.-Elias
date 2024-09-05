using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TrabalhoBDePOO.Modelos;

namespace TrabalhoBDePOO.dao;

internal class DespesaDAO
{
    public static void Insert(Despesa despesa)
    {
        try
        {
            string dataPagamento = despesa.DataPagamento.ToString("yyyy-MM-dd");
            string dataVencimento = despesa.DataVencimento.ToString("yyyy-MM-dd");
            string sql = "INSERT INTO despesa(idDespesa,valor,dataVencimento,DataPagamento,situacao,fk_id_caixa,fk_id_fornecedor)" +
                "VALUES(@idDespesa,@valor,@dataVencimento,@dataPagamento,@situacao,@fk_id_caixa,@fk_id_fornecedor)";
            MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
            comando.Parameters.AddWithValue("@idDespesa", despesa.IdDespesa);
            comando.Parameters.AddWithValue("@valor", despesa.Valor);
            comando.Parameters.AddWithValue("@dataVencimento", dataVencimento);
            comando.Parameters.AddWithValue("@dataPagamento", dataPagamento);
            comando.Parameters.AddWithValue("@situacao", despesa.Situacao);
            comando.Parameters.AddWithValue("@fk_id_caixa", despesa.Fk_Id_Caixa);
            comando.Parameters.AddWithValue("@fk_id_fornecedor", despesa.Fk_Id_Fornecedor);
            
            comando.ExecuteNonQuery();
            Console.WriteLine("Despesa cadastrada com sucesso");
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao cadastrar despesa " + ex.Message);

        }
        finally
        {
            Conexao.FecharConexao();
        }
    }

    public static void Delete(Despesa despesa)
    {
        try
        {
            string sql = "DELETE FROM despesa WHERE idDespesa = @idDespesa";
            MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
            comando.Parameters.AddWithValue("@idDespesa", despesa.IdDespesa);
            comando.ExecuteNonQuery();
            Console.WriteLine("Despesa excluida com sucesso!");

        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao excluir despesa " + ex.Message);
        }
        finally
        {
            Conexao.FecharConexao();
        }
    }

    public static List<Despesa> List()
    {
        List<Despesa> despesas = new List<Despesa>();

        try
        {
            var sql = "SELECT * FROM despesa ORDER BY valor";
            MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
            using (MySqlDataReader dr = comando.ExecuteReader())
            {
                while (dr.Read())
                {
                    Despesa despesa = new Despesa();
                    despesa.IdDespesa = dr.GetInt32("idDespesa");
                    despesa.Valor = dr.GetDecimal("valor");
                    despesa.DataVencimento = DateOnly.FromDateTime(dr.GetDateTime("dataVencimento"));
                    despesa.DataPagamento = DateOnly.FromDateTime(dr.GetDateTime("dataPagamento"));
                    despesa.Situacao = dr.GetBoolean("situacao");
                    despesa.Fk_Id_Caixa = dr.GetInt32("fk_id_caixa");
                    despesa.Fk_Id_Fornecedor = dr.GetInt32("fk_id_fornecedor");

                    despesas.Add(despesa);
                    
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar as despesas! " + ex.Message);
        }
        finally
        {
            Conexao.FecharConexao();
        }

        return despesas;
    }


    public static void Update(Despesa despesa)
    {
        try
        {
            string sql = "UPDATE despesa SET valor = @valor, dataVencimento = @dataVencimento, dataPagamento = @dataPagamento," +
                "situacao = @situacao , fk_id_caixa = @fk_id_caixa, fk_id_fornecedor = @fk_id_fornecedor " +
                "WHERE idDespesa = @idDespesa";

            string dataPagamento = despesa.DataPagamento.ToString("yyyy-MM-dd");
            string dataVencimento = despesa.DataVencimento.ToString("yyyy-MM-dd");
            MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

            
            comando.Parameters.AddWithValue("@idDespesa", despesa.IdDespesa);
            comando.Parameters.AddWithValue("@valor", despesa.Valor);
            comando.Parameters.AddWithValue("@dataVencimento", dataVencimento);
            comando.Parameters.AddWithValue("@dataPagamento", dataPagamento);
            comando.Parameters.AddWithValue("@situacao", despesa.Situacao);
            comando.Parameters.AddWithValue("@fk_id_caixa", despesa.Fk_Id_Caixa);
            comando.Parameters.AddWithValue("@fk_id_fornecedor", despesa.Fk_Id_Fornecedor);
            

            comando.ExecuteNonQuery();

            Console.WriteLine("Atualizado com sucesso!");

            
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao atualizar a despesa " + ex.Message);
        }
        finally
        {
            Conexao.FecharConexao();
        }
    }

    public static Despesa Read(Despesa despesa)
    {
        

        try
        {
            var sql = "SELECT * FROM despesa WHERE @idDespesa = idDespesa";

            MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

            comando.Parameters.AddWithValue("@idDespesa", despesa.IdDespesa);

            using (MySqlDataReader dr = comando.ExecuteReader())
            {
                while (dr.Read())
                {
                    
                    despesa.IdDespesa = dr.GetInt32("idDespesa");
                    despesa.Valor = dr.GetDecimal("valor");
                    despesa.DataVencimento = DateOnly.FromDateTime(dr.GetDateTime("dataVencimento"));
                    despesa.DataPagamento = DateOnly.FromDateTime(dr.GetDateTime("dataPagamento"));
                    despesa.Situacao = dr.GetBoolean("situacao");
                    despesa.Fk_Id_Caixa = dr.GetInt32("fk_id_caixa");
                    despesa.Fk_Id_Fornecedor = dr.GetInt32("fk_id_fornecedor");

                }
                
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao visualizar a despesa! " + ex.Message);
        }
        finally
        {
            Conexao.FecharConexao();
        }

        return despesa;
    }

}
