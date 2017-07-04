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
    public partial class ListaGrupoProdutoForm : Form
    {

        GrupoProdutoBO bo;

        MenuForm _menu;
        public ListaGrupoProdutoForm()
        {
            InitializeComponent();

            bo = new GrupoProdutoBO();
        }

        public ListaGrupoProdutoForm(MenuForm menu) : this()
        {
            _menu = menu;

        }


        public void AtualizarGrid()
        {
            var produtos = bo.Listar();
            dgvGrupoProdutos.DataSource = produtos;
        }

        private void ListaGrupoProdutoForm_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void dgvGrupoProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var id = Convert.ToInt32(dgvGrupoProdutos.Rows[e.RowIndex].Cells["Column1"].Value.ToString());

                try
                {
                    var grupoproduto = bo.Encontrar(id);

                    if (grupoproduto == null)
                    {
                        MessageBox.Show("Nenhum produto foi encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var form = new CadastroGrupoProdutoForm(this, grupoproduto)
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

        private void menuNovo_Click(object sender, EventArgs e)
        {
            var form = new CadastroGrupoProdutoForm(this)
            {
                MdiParent = _menu
            };

            form.Show();
        }
    }
}
