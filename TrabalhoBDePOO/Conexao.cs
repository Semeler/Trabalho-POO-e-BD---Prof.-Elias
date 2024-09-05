using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TrabalhoBDePOO;

public static class Conexao
{
    static MySqlConnection conexao;

    public static MySqlConnection Conectar()
    {
		try
		{
			string strconexao = "server=127.0.0.1;port=3306;uid=root;pwd=root;database=gestao_financeira_semeler";
			conexao = new MySqlConnection(strconexao);
			conexao.Open();
            Console.WriteLine("Conexão realizada com sucesso!");
            Console.WriteLine("");
        }
		catch (Exception ex)
		{
			throw new Exception("Erro ao realizar a conexao com a base de dados!");
        }

        return conexao;
    }

	public static void FecharConexao()
	{
		conexao.Close();
	}
}
