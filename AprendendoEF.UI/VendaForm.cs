using AprendendoEF.BLL;
using AprendendoEF.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AprendendoEF.UI
{
    public partial class VendaForm : Form
    {
        public Venda _venda;
        List<Produto> _produtosLista;
        VendaBO bo;
        ListaVendasForm _lista;
        public ItemVenda _item;

        EmailBO emailBo;

        Cliente _cliente;

        ClienteBO clienteBo;
        ProdutoBO produtoBo;

        public VendaForm()
        {
            InitializeComponent();

            bo = new VendaBO();
            txtData.Text = DateTime.Now.ToString();

            txtQtd.Text = Convert.ToString(1);

            emailBo = new EmailBO();

            _cliente = new Cliente();

            clienteBo = new ClienteBO();
            produtoBo = new ProdutoBO();

        }

        public VendaForm(ListaVendasForm lista) : this()
        {
            _lista = lista;

        }

        public VendaForm(ListaVendasForm lista, Venda venda) : this(lista)
        {
            _venda = venda;
        }

        private void NovaVenda()
        {
            _venda = new Venda
            {
                Data = DateTime.Now,
                Itens = new List<ItemVenda>()
            };
        }


        public void PreencherDadosVendaForm()
        {

            txtCodVenda.Text = _venda.Id.ToString();
            txtData.Text = _venda.Data.ToString();
        }

        private void FrmVenda_Load(object sender, EventArgs e)
        {

            if (_venda != null)
            {
                txtCodVenda.Text = _venda.Id.ToString();
                txtCodCli.Text = _venda.Cliente_Id.ToString();
                txtNomeCli.Text = _venda.Cliente.Nome;
                var produtobo = new ProdutoBO();
                _produtosLista = produtobo.Listar();

            }
            else
            {
                NovaVenda();

                AtualizarItens();

                PreencherDadosVendaForm();

            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            var form = new CadastroClientesForm();
            form.Show();
        }


        private void btnGravarItem_Click(object sender, EventArgs e)
        {

            if (txtNomeProd.Text != string.Empty)
            {

                var produto = produtoBo.Encontrar(Convert.ToInt32(txtCodProd.Text));
                _item = new ItemVenda
                {

                    Produto_Id = Convert.ToInt32(txtCodProd.Text),
                    Produto = produto,
                    Quantidade = Convert.ToDouble(txtQtd.Text),
                    ValorUnitario = Convert.ToDouble(txtValor.Text),
                    ValorTotal = Convert.ToDouble(txtValor.Text) * Convert.ToDouble(txtQtd.Text)
                };

                _venda.Itens.Add(_item);
                AtualizarItens();
                txtQtd.Text = "1";
                txtCodProd.Clear();
                txtNomeProd.Clear();
                txtValor.Clear();

            }

            else
            {
                MessageBox.Show("Informe o item", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }


        public void AtualizarItens()
        {
            for (int i = 0; i < _venda.Itens.Count; i++)
            {
                _venda.Itens[i].Ordem = i + 1;
            }

            txtTotalGeral.Text = _venda.Itens.Sum(x => x.ValorTotal).ToString("C");

            var bs = new BindingSource();
            bs.DataSource = _venda.Itens;
            dgvItensVenda.DataSource = bs;
        }

        private void btnRemoverItem_Click(object sender, EventArgs e)
        {
            var produto = new Produto();
            var item = new ItemVenda();

            var bs = new BindingSource();
            bs.DataSource = _venda.Itens;
            dgvItensVenda.DataSource = bs;

            AtualizarItens();
        }


        private void dgvItensVenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItensVenda.CurrentRow != null)
            {
                var ordem = Convert.ToInt32(dgvItensVenda.CurrentRow.Cells["Item"].Value);

                var item = _venda.Itens.FirstOrDefault(x => x.Ordem == ordem);

                var index = _produtosLista.FirstOrDefault(x => x.Id == item.Produto_Id);

                txtQtd.Text = item.Quantidade.ToString();

                _venda.Itens.Remove(item);

                AtualizarItens();

            }
        }

        private void dgvItensVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvItensVenda.CurrentRow != null)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    var ordem = Convert.ToInt32(dgvItensVenda.CurrentRow.Cells["Item"].Value);

                    var item = _venda.Itens.FirstOrDefault(x => x.Ordem == ordem);

                    _venda.Itens.Remove(item);

                    AtualizarItens();
                }
            }
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            if (_venda.Itens.Count == 0)
            {
                MessageBox.Show("A Venda não possui itens", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                var cliente = clienteBo.Encontrar(Convert.ToInt32(txtCodCli.Text));

                _venda.Cliente = cliente;
                _venda.Cliente_Id = Convert.ToInt32(txtCodCli.Text);
                _venda.Valor = _venda.Itens.Sum(x => x.ValorTotal);

                var lista = _venda.Itens.ToList();

                var item = new StringBuilder();

                foreach (var i in lista)
                {

                    item.Append("-" + $"{i.Produto}" + " R$: " + $"{i.ValorUnitario}" + "\n");
                    item.Append($"\n");
                }

                var listaPreenchida = item.ToString();

                bo.Salvar(_venda);

                ImprimirVenda();

                if (_cliente.Email != null)
                {
                    EnviarEmail(cliente.Email, "Venda teste ", cliente.Nome, listaPreenchida);

                    MessageBox.Show("Email com a venda enviado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


                this.Close();
                _lista.AtualizarGrid();
            }
        }

        public void EnviarEmail(string para, string assunto, string cliente, string itens)
        {
            try
            {
                var email = new MailMessage();
                var id = 1;
                var emailencontrado = emailBo.Encontrar(id);

                using (var enviar = new SmtpClient())
                {
                    enviar.Host = emailencontrado.Smtp;
                    email.From = new MailAddress(emailencontrado.Usuario);
                    enviar.Credentials = new System.Net.NetworkCredential(emailencontrado.Usuario, emailencontrado.Senha);
                    email.To.Add(new MailAddress(para));
                    email.Subject = assunto;
                    enviar.Port = emailencontrado.Porta;


                    var mensagem = "Prezado(a): " + cliente + "\n" + "Segue a compra realizada em nossa loja:\n\n" + itens + "\n" + "Total: " + string.Format("{0:C} ", _venda.Valor);
                    email.Body = mensagem;

                    enviar.Send(email);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_venda.Id != 0)
            {

                bo.Remover(_venda.Id = _venda.Id);
                MessageBox.Show("Venda removida com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
                _lista.AtualizarGrid();

            }
            else
            {
                MessageBox.Show("Selecione uma venda para ser removida", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AbrirFormularioConsultaCliente();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var form = new CadastroClientesForm();
            form.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImprimirVenda();

        }

        public void ImprimirVenda()
        {
            if (_venda.Id != 0)
            {
                var form = new RelatorioVendaForm(_venda);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Informe uma venda para ser impressa", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void AbrirFormularioConsultaCliente()
        {
            var form = new ConsultaClienteForm(this);
            form.ShowDialog();

        }

        //atalho F2 para buscar Cliente
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                AbrirFormularioConsultaCliente();

                return true;    // Indica que o pressionar desta tecla 
                                // foi gerenciado aqui.
            }

            // Propaga o evento para o método da classe base
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtCodCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.F2)
            {
                AbrirFormularioConsultaCliente();
            }

            if ((Keys)e.KeyChar == Keys.Enter)
            {

                try
                {
                    var clienteEncontrado = clienteBo.Encontrar(txtCodCli.Text);

                }
                catch (Exception)
                {

                    MessageBox.Show("Nenhum cliente localizado");
                }
            }
        }

        private void btnPesquisarProd_Click(object sender, EventArgs e)
        {
            AbrirFormularioConsultaProduto();
        }

        public void AbrirFormularioConsultaProduto()
        {
            var form = new ConsultaProdutoForm(this);
            form.ShowDialog();
        }
    }
}

