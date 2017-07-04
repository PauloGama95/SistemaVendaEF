using AprendendoEF.BLL;
using AprendendoEF.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AprendendoEF.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {

            var usuario = new Usuario();

            usuario.Login = txtLogin.Text;
            usuario.Senha = txtSenha.Text;

            var login = new LoginBO();

            var logado = login.Logar(usuario);




            if (logado)
            {
                var form = new MenuForm(usuario);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario ou senha incorretos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
