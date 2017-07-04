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
    public partial class RelatorioClientesForm : Form
    {

        ClienteBO bo;


        public RelatorioClientesForm()
        {
            InitializeComponent();

            bo = new ClienteBO();



        }

        private void RelatorioClientesForm_Load(object sender, EventArgs e)
        {

            var clientes = new List<Cliente>();

            clientes = bo.Listar();
            ClienteBindingSource.DataSource = clientes;

            this.reportViewer1.RefreshReport();
        }
    }
}
