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
    public partial class CadastroUsuariosForm : Form
    {
        Usuario _usuario;

        ListaUsuariosForm _lista;

        UsuarioBO bo;

        public CadastroUsuariosForm()
        {
            InitializeComponent();

            bo = new UsuarioBO();


        }


        public CadastroUsuariosForm(ListaUsuariosForm lista) : this()
        {
            _lista = lista;
        }


        public CadastroUsuariosForm(ListaUsuariosForm lista, Usuario usuario) : this(lista)
        {
            _usuario = usuario;

        }

        public int ObterId()
        {
            return !string.IsNullOrEmpty(txtId.Text) ? Convert.ToInt32(txtId.Text) : 0;
        }

        public void LimparCampos()
        {
            txtId.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtSenhaConfirmacao.Text = "";
        }

        private void CadastroUsuariosForm_Load(object sender, EventArgs e)
        {

            if (_usuario != null)
            {
                txtId.Text = _usuario.Id.ToString();
                txtLogin.Text = _usuario.Login;
                txtSenha.Text = _usuario.Senha;

                menuRemover.Visible = true;
            }
            else
                menuRemover.Visible = false;
        }

        private void menuGravar_Click(object sender, EventArgs e)
        {
            try
            {
                _usuario = new Usuario
                {
                    Id = ObterId(),
                    Login = txtLogin.Text,
                    Senha = txtSenha.Text,
                };

                if (txtSenha.Text.Equals(txtSenhaConfirmacao.Text))
                {
                    bo.Salvar(_usuario);

                    MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(txtId.Text))
                    {
                        LimparCampos();
                        txtLogin.Focus();
                        _lista.AtualizarGrid();
                    }
                    else
                    {
                        Hide();
                        _lista.AtualizarGrid();
                    }

                }

                else
                {
                    MessageBox.Show("Senha e confirmação não confere!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Os campos em negrito sao obrigatórios", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    var result = MessageBox.Show($"Você tem certeza que deseja remover {_usuario.Login}?", "Atenção", MessageBoxButtons.YesNo,

                        MessageBoxIcon.Exclamation);

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

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
