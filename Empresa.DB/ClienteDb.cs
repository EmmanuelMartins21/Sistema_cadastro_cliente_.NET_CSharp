using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using empresa_models;
using Empresa.DB;
using Empresa;
using System.Data.SqlTypes;


namespace Empresa.DB
{
    public class ClienteDb
    {
        public void Incluir(Clientes cliente)
        {
            //inclusão de clientes
            string sql = "INSERT INTO Clientes(Id,NOME,EMAIL,TELEFONE) VALUES (@Id, @NOME, @EMAIL, @TELEFONE)";
            var cn = new SqlConnection(Db.Conexao);
            var cmd = new SqlCommand(sql,cn); // Passa o comando e a conexão a ser utilizada
            //POPULANDO O BANCO
            cmd.Parameters.AddWithValue("@Id", cliente.Id);
            cmd.Parameters.AddWithValue("@Nome", cliente.nome);
            cmd.Parameters.AddWithValue("@Email", cliente.email);
            cmd.Parameters.AddWithValue("@Telefone", cliente.telefone);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

        }
    
        public void Excluir(int Id)
        {
            //inclusão de clientes
            string sql = "DELETE Clientes WHERE ID=@Id";
            var cn = new SqlConnection(Db.Conexao);
            var cmd = new SqlCommand(sql, cn); // Passa o comando e a conexão a ser utilizada
            //POPULANDO O BANCO
            cmd.Parameters.AddWithValue("@Id", Id);         
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

        }
        public void Alterar(Clientes cliente)
        {
            //inclusão de clientes
            string sql = "UPDATE Clientes SET NOME=@NOME, TELEFONE=@TELEFONE, EMAIL=@EMAIL WHERE ID=@ID";
            var cn = new SqlConnection(Db.Conexao);
            var cmd = new SqlCommand(sql, cn); // Passa o comando e a conexão a ser utilizada
            //POPULANDO O BANCO
            cmd.Parameters.AddWithValue("@Id", cliente.Id);
            cmd.Parameters.AddWithValue("@NOME", cliente.nome);
            cmd.Parameters.AddWithValue("@EMAIL", cliente.email);
            cmd.Parameters.AddWithValue("@TELEFONE", cliente.telefone);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public List<Clientes> Listar()
        {
            string sql = "SELECT Id,Nome,Telefone, Email FROM CLIENTES";
            var cn = new SqlConnection(Db.Conexao); // Criando a conexão com o banco de dados
            var cmd = new SqlCommand(sql,cn);

            List<Clientes> lista = new List<Clientes>();

            cn.Open(); //abrindo o banco para leitura

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read()) // Aqui l~e o banco enquanto houver infomação e exibe na tela
                {
                    var cliente = new Clientes();
                    cliente.Id = Convert.ToInt32(reader["Id"]);
                    cliente.nome = reader["Nome"].ToString();
                    cliente.telefone = reader["Telefone"].ToString();
                    cliente.email = reader["Email"].ToString();

                    lista.Add(cliente);
                }
                reader.Close();
                cn.Close();
                //return lista;
            }
            catch(ObjectDisposedException)
            {
                
            }
            return lista;
        }

    }
}
