﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;
using ProjetoBiblioteca.Code.DTO;

namespace ProjetoBiblioteca.Code.DAL
{
    class ClienteDAL
    {
        public static string BancoDs = "Data Source = BibliotecaDB";
        public static string BibliotecaDB = "BibliotecaDB.db";

        public void CarregarCriarDb()
        {
            if (!File.Exists(BibliotecaDB))
            {
                SQLiteConnection.CreateFile(BibliotecaDB);
                SQLiteConnection Conexao = new SQLiteConnection(BancoDs);
                Conexao.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("CREATE TABLE IF NOT EXISTS LIVROS ([ID] INTEGER PRIMARY KEY AUTOINCREMENT, ");
                sql.AppendLine("[TITULO] VARCHAR(50), [AUTOR] VARCHAR(50), [CATEGORIA] VARCHAR(20), ");
                sql.AppendLine("[LANCAMENTO] INTEGER, [EXEMPLARES] INTEGER);");
                sql.AppendLine("CREATE TABLE IF NOT EXISTS ALUNOS ([ID] INTEGER PRIMARY KEY AUTOINCREMENT, [NOME] VARCHAR(50))");
                //sql.AppendLine("[NOME] VARCHAR(50))");

                SQLiteCommand cmd = new SQLiteCommand(sql.ToString(), Conexao);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro Ao Criar DB: " + ex.Message);
                }
            }
        }

        //===================================Livros================================
        public void CarregarDados(MetroFramework.Controls.MetroGrid mgLivros)
        {
            SQLiteConnection Conexao = new SQLiteConnection(BancoDs);
            if (Conexao.State == ConnectionState.Closed)
            Conexao.Open();

            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM LIVROS", Conexao);
            SQLiteDataReader Dr = cmd.ExecuteReader();
            List<ClienteDTO.Livros> Lista = new List<ClienteDTO.Livros>();

            while (Dr.Read())
            {
                Lista.Add(new ClienteDTO.Livros
                { Id = Convert.ToInt32(Dr["ID"]), 
                  Titulo = Dr["TITULO"].ToString(), 
                  Autor = Dr["AUTOR"].ToString(),
                  Categoria = Dr["CATEGORIA"].ToString(),
                  Lancamento = Convert.ToInt32(Dr["LANCAMENTO"]),
                  Exemplares = Convert.ToInt32(Dr["EXEMPLARES"])
                  });
            }
            mgLivros.DataSource = Lista;
        }

        //=====================================Alunos===========================

    }
}
