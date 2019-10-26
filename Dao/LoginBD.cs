﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Trabalho21_10_2019_1ponto.Dao
{
    public class LoginBD
    {
        Dao.Conexao Con = new Dao.Conexao();
        Model.Logar Log = new Model.Logar();
        

        public bool Validausuario(string user)
        {
            if (!Con.Checkconection())
            {
                Con.Conectar();
            }

            if (Con.Checkconection())
            {
                MessageBox.Show("entrou no select do login");
                MessageBox.Show("USUARIO",Log.GetUsuario()); 
                MessageBox.Show("Senha",Log.GetSenha());
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM usuario WHERE USUARIO = @usuario AND SENHA = @senha", Con.traz_Conexao());

                command.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = Log.GetUsuario();
                command.Parameters.Add("@senha", MySqlDbType.VarChar).Value = Log.GetSenha();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                //command.ExecuteReader();

                //Verifica se há uma lina no banco com esse Usuário.
                if (table.Rows.Count > 0)
                {
                    return true;
                }

                Con.Desconectar();
            }

            return false;
        }
    }
}
