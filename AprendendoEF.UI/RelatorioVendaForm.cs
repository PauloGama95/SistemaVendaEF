using Microsoft.Reporting.WinForms;
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
    public partial class RelatorioVendaForm : Form
    {
        Venda _venda;

        public RelatorioVendaForm(Venda venda)
        {
            InitializeComponent();

            _venda = venda;
        }

        private void RelatorioVendaForm_Load(object sender, EventArgs e)
        {
            var vendas = new List<Venda>();
            vendas.Add(_venda);

            VendaBindingSource.DataSource = vendas;

            reportViewer1.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;

            this.reportViewer1.RefreshReport();
        }

        private void LocalReport_SubreportProcessing(object sender, Microsoft.Reporting.WinForms.SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("DsItens", _venda.Itens));
        }
    }
}
