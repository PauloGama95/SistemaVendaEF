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
    public partial class CadastroGrupoProdutoForm : Form
    {
        GrupoProduto _grupo;

        ListaGrupoProdutoForm _lista;

        GrupoProdutoBO bo;

        public CadastroGrupoProdutoForm()
        {
            InitializeComponent();

            bo = new GrupoProdutoBO();

        }

        public CadastroGrupoProdutoForm(ListaGrupoProdutoForm lista) : this()
        {
            _lista = lista;
        }

        public CadastroGrupoProdutoForm(ListaGrupoProdutoForm lista, GrupoProduto grupo) : this(lista)
        {
            _grupo = grupo;
        }

        public int ObterId()
        {
            return !string.IsNullOrEmpty(txtId.Text) ? Convert.ToInt32(txtId.Text) : 0;
        }

        public void LimparCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
        }
        private void CadastroGrupoProdutoForm_Load(object sender, EventArgs e)
        {
            if (_grupo != null)
            {
                txtId.Text = _grupo.Id.ToString();
                txtNome.Text = _grupo.Nome;

                menuRemover.Visible = true;
            }
            else
                menuRemover.Visible = false;
        }
        private void menuGravar_Click(object sender, EventArgs e)
        {

            try
            {
                _grupo = new GrupoProduto()
                {
                    Id = ObterId(),
                    Nome = txtNome.Text,

                };

                bo.Salvar(_grupo);

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

        private void menuRemover_Click(object sender, EventArgs e)
        {

            try
            {
                var id = ObterId();

                if (id > 0)
                {
                    var result = MessageBox.Show($"Você tem certeza que deseja remover {_grupo.Nome}?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
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

        private void menuCancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}

