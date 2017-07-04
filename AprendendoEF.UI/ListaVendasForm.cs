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
    public partial class ListaVendasForm : Form
    {
        MenuForm _menu;
        VendaBO bo;




        public ListaVendasForm()
        {
            InitializeComponent();
            bo = new VendaBO();

        }

        public void AtualizarGrid()
        {
            var vendas = bo.Listar();
            dgvVendas.DataSource = vendas;

        }

        public ListaVendasForm(MenuForm menu) : this()
        {
            _menu = menu;

        }

        private void menuNovo_Click(object sender, EventArgs e)
        {

            var form = new VendaForm(this)
            {
                MdiParent = _menu
            };

            form.Show();
        }

        private void ListaVendasForm_Load(object sender, EventArgs e)
        {
            var vendas = bo.Listar();

            dgvVendas.DataSource = vendas;




        }

        private void dgvVendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                var id = Convert.ToInt32(dgvVendas.Rows[e.RowIndex].Cells["Id"].Value.ToString());

                try
                {
                    var venda = bo.Encontrar(id);

                    if (venda == null)
                    {
                        MessageBox.Show("Nenhuma venda foi encontrada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var form = new VendaForm(this, venda)
                        {
                            MdiParent = _menu


                        };
                        form.Show();
                        form.AtualizarItens();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
