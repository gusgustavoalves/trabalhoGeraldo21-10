﻿using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Trabalho21_10_2019_1ponto.Dao
{
    class Conexao
    {
        MySqlConnection conexao = new MySqlConnection();
        private string statusbd;

        public string Statusbd { get => statusbd; set => statusbd = value; }

        public void Conectar()
        {
            try
            {
                conexao.ConnectionString = @"server=localhost;port=3306;User Id=root;database=cadastro;password=";
                conexao.Open();
                MessageBox.Show("Conectado com Sucesso !!!");
                conexao.Close();
            }
            catch
            {
                MessageBox.Show("Erro de Conexao Com O Banco de Dados !!!!");
            }
        }

        public void Desconectar()
        {
            try
            {
                conexao.Close();
            }
            catch
            {
                MessageBox.Show("Erro de Fechamento de conexão com Banco de Dados !!!!");
            }
        }

        public bool Checkconection()
        {
            string temp = conexao.State.ToString(Statusbd);
            Statusbd = temp;
            if (conexao.State == ConnectionState.Open && temp == "Open")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
