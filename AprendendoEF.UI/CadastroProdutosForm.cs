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
    public partial class CadastroProdutosForm : Form
    {
        Produto _produto;

        ListaProdutosForm _lista;

        ProdutoBO bo;

        public CadastroProdutosForm()
        {
            InitializeComponent();

            bo = new ProdutoBO();
        }

        public CadastroProdutosForm(ListaProdutosForm lista) : this()
        {
            _lista = lista;
        }

        public CadastroProdutosForm(ListaProdutosForm lista, Produto produto) : this(lista)
        {
            _produto = produto;
        }

        public int ObterId()
        {
            return !string.IsNullOrEmpty(txtId.Text) ? Convert.ToInt32(txtId.Text) : 0;
        }

        public void LimparCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtValor.Text = "";

        }

        private void CadastroProdutosForm_Load(object sender, EventArgs e)
        {

            var grupoBO = new GrupoProdutoBO();
            var grupos = grupoBO.Listar();
            cmbGrupoProdutos.DataSource = grupos;

            if (_produto != null)
            {
                var grupo = grupos.FirstOrDefault(x=>x.Id == _produto.GrupoProduto_Id);
                var indice = grupos.IndexOf(grupo);

                txtId.Text = _produto.Id.ToString();
                txtNome.Text = _produto.Nome;
                cmbGrupoProdutos.SelectedIndex = indice;
                txtValor.Text = Convert.ToString(_produto.Valor);

                menuRemover.Visible = true;
            }
            else
                menuRemover.Visible = false;

        }

        private void menuGravar_Click(object sender, EventArgs e)
        {
            try
            {

                double valor = 0;
                double.TryParse(txtValor.Text, out valor);
                if (valor <= 0)
                    throw new ArgumentOutOfRangeException();

                var gruposelecionado = (GrupoProduto)cmbGrupoProdutos.SelectedItem;

                _produto = new Produto
                {
                    Id = ObterId(),
                    Nome = txtNome.Text,
                    GrupoProduto_Id = gruposelecionado.Id,
                    Valor = Convert.ToDouble(txtValor.Text)
                };

                bo.Salvar(_produto);

                MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (string.IsNullOrEmpty(txtId.Text))
                {
                    LimparCampos();
                    txtNome.Focus();
                    _lista.AtualizarGrid();

                }
                else
                {
                    Hide();
                    _lista.AtualizarGrid();
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Os campos em negrito sao obrigatórios", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("O Campo valor deve conter apenas número", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void menuRemover_Click_1(object sender, EventArgs e)
        {

            try
            {
                var id = ObterId();

                if (id > 0)
                {
                    var result = MessageBox.Show($"Você tem certeza que deseja remover {_produto.Nome}?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        bo.Remover(id);

                        LimparCampos();

                        _lista.AtualizarGrid();

                        Hide();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void menuCancelar_Click_1(object sender, EventArgs e)
        {
            Hide();
        }

    }
}







