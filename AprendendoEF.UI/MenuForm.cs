using AprendendoEF.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AprendendoEF.UI
{
    public partial class MenuForm : Form
    {
        Usuario _usuario;

        public MenuForm(Usuario usuario)
        {
            InitializeComponent();

            _usuario = usuario;

        }

        private void menuClientes_Click(object sender, EventArgs e)
        {
            var form = new ListaClientesForm(this)
            {
                MdiParent = this,
            };
            form.Show();
        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ListaProdutosForm(this)
            {
                MdiParent = this,
            };
            form.Show();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            lblUsuarioLogado.Text = _usuario.Login;

        }

        private void grupoProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ListaGrupoProdutoForm(this)
            {
                MdiParent = this,
            };

            form.Show();

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ListaUsuariosForm(this)
            {
                MdiParent = this,
            };

            form.Show();
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ListaVendasForm()
            {
                MdiParent = this,
            };

            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new LoginForm();

            form.Show();

        }

        private void configuraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var emailBo = new EmailBO();

            var id = 1;
            var email = emailBo.Encontrar(id);

            var form = new ConfiguracaoForm(email);
            form.Show();
        }
    }
}
