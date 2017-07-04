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

namespace AprendendoEF.UI
{
    public partial class ListaUsuariosForm : Form
    {
        UsuarioBO bo;

        MenuForm _menu;

        public ListaUsuariosForm()
        {
            InitializeComponent();

            bo = new UsuarioBO();
        }

        public ListaUsuariosForm(MenuForm menu) : this()
        {
            _menu = menu;
        }

        private void ListaUsuariosForm_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }


        public void AtualizarGrid()
        {
            var usuarios = bo.Listar();
            dgvUsuarios.DataSource = usuarios;
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var id = Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells["Column1"].Value.ToString());

                try
                {
                    var usuario = bo.Encontrar(id);

                    if (usuario == null)
                    {
                        MessageBox.Show("Nenhum usuario foi encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var form = new CadastroUsuariosForm(this, usuario)
                        {
                            MdiParent = _menu
                        };

                        form.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuNovo_Click(object sender, EventArgs e)
        {
            var form = new CadastroUsuariosForm(this)
            {
                MdiParent = _menu
            };

            form.Show();
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


