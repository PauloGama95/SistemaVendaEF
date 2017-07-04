using AprendendoEF;
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
    public partial class ConsultaProdutoForm : Form
    {
        ProdutoBO bo;
        Produto _produto;
        VendaForm _vendaForm;
        ItemVenda _itemVenda;

        public ConsultaProdutoForm()
        {
            InitializeComponent();

            bo = new ProdutoBO();
            txtPesquisar.Select();
        }

        public ConsultaProdutoForm(VendaForm vendaForm) : this()
        {
            _vendaForm = vendaForm;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dgvProdutos.DataSource = bo.Encontrar(txtPesquisar.Text);
        }

        private void ConsultaProdutoForm_Load(object sender, EventArgs e)
        {

        }


        public void SelecionarProduto(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var id = Convert.ToInt32(dgvProdutos.Rows[e.RowIndex].Cells["Id"].Value.ToString());

                try
                {
                    _produto = bo.Encontrar(id);

                    if (_produto == null)
                    {
                        MessageBox.Show("Nenhum produto foi encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        _vendaForm.txtCodProd.Text = _produto.Id.ToString();
                        _vendaForm.txtValor.Text = _produto.Valor.ToString();
                        _vendaForm.txtNomeProd.Text = _produto.Nome;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void dgvProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelecionarProduto(sender, e);
        }
    }
}
