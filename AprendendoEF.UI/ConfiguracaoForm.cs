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
    public partial class ConfiguracaoForm : Form
    {
        Email _email;
        EmailBO emailBo;
        public ConfiguracaoForm(Email email)
        {
            InitializeComponent();

            emailBo = new EmailBO();

            _email = email;

        }

        private void menuGravar_Click(object sender, EventArgs e)
        {
            try
            {

                if (_email != null)
                {
                    _email.Id = 1;
                    _email.Smtp = txtSmtp.Text;
                    _email.Usuario = txtUsuario.Text;
                    _email.Senha = txtSenha.Text;
                    _email.Porta = Convert.ToInt32(txtPorta.Text);
                    _email.Ssl = chkSsl.Checked;
                }
                else
                {
                    _email = new Email
                    {
                        Porta = Convert.ToInt32(txtPorta.Text),
                        Smtp = txtSmtp.Text,
                        Senha = txtSenha.Text,
                        Usuario = txtUsuario.Text,
                        Ssl = chkSsl.Checked
                    };
                }

                emailBo.Salvar(_email);
                MessageBox.Show("Configurações realizada com sucesso");
                this.Close();

            }

            catch (FormatException)
            {

                MessageBox.Show("Verifique os campos vazios ");
            }

            catch (ArgumentNullException)
            {

                MessageBox.Show("Verifique os campos vazios ");
            }


        }

        private void ConfiguracaoForm_Load(object sender, EventArgs e)
        {

            txtPorta.Text = _email.Porta.ToString();
            txtSenha.Text = _email.Senha;
            txtSmtp.Text = _email.Smtp;
            txtUsuario.Text = _email.Usuario;
            chkSsl.Checked = _email.Ssl;

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
