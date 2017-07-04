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

    public partial class ConsultaClienteForm : Form
    {

        ClienteBO bo;

        Cliente _cliente;


        VendaForm _vendaForm;

        public ConsultaClienteForm()
        {
            InitializeComponent();
            bo = new ClienteBO();
        }


        public ConsultaClienteForm(VendaForm vendaForm) : this()
        {
            _vendaForm = vendaForm;
        }



        private void ConsultaClienteForm_Load(object sender, EventArgs e)
        {
            txtPesquisar.Select();

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();

        }

        public void Pesquisar()
        {
            var pesquisa = bo.Encontrar(txtPesquisar.Text);

            dgvClintes.DataSource = pesquisa;
            dgvClintes.Select();
        }

        private void ConsultaClienteForm_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((Keys)e.KeyChar == Keys.Escape)
            {
                this.Close();
            }
        }



        private void dgvClintes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            SelecionarCliente(sender, e);
        }


        public void SelecionarCliente(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var id = Convert.ToInt32(dgvClintes.Rows[e.RowIndex].Cells["Id"].Value.ToString());

                try
                {
                    _cliente = bo.Encontrar(id);

                    if (_cliente == null)
                    {
                        MessageBox.Show("Nenhum usuario foi encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        _vendaForm.txtCodCli.Text = _cliente.Id.ToString();
                        _vendaForm.txtNomeCli.Text = _cliente.Nome;
                        this.Close();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.F2)
            {
                txtPesquisar.Clear();
                txtPesquisar.Select();

                return true;    // Indica que o pressionar desta tecla 
                                // foi gerenciado aqui.

            }
            // Propaga o evento para o método da classe base
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtPesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                Pesquisar();
            }

        }


    }
}
