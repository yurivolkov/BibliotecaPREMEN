﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProjetoBiblioteca.Code.DAL;

namespace ProjetoBiblioteca.Code.BLL
{
    class ClienteBLL
    {
        //==================================Form Login===================================
        internal void Logar(MaterialSkin.Controls.MaterialSingleLineTextField txtUsuario, MaterialSkin.Controls.MaterialSingleLineTextField txtSenha)
        {
            if (txtUsuario.Text == "admin" && txtSenha.Text == "admin")
            {
                Controle NewControle = new Controle();
                NewControle.Show();
            }
            else if (txtUsuario.Text != "admin" && txtSenha.Text != "admin")
            {
                MessageBox.Show("Senha ou Usuario Incorreto");
            }
        }

        internal void CarregarCriarDB()
        {
            var Criar = new ClienteDAL();
            Criar.CarregarCriarDb();
        }
    }
}