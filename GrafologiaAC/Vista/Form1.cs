using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrafologiaAC.Controlador;
namespace GrafologiaAC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ClsLogin objcontrol = new ClsLogin();
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btn_ingresar.Size = new Size(80, 80);
            //btningreso.BackgroundImage = Properties.Resources.btn_ingresar2_log1;
            btn_ingresar.BackgroundImage = Properties.Resources.botonesnu;
        }

        private void btn_ingresar_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void btn_ingresar_MouseHover(object sender, EventArgs e)
        {
            //btningreso.Size = new Size(70, 65);
            btn_ingresar.Size = new Size(82, 82);
            //btningreso.BackgroundImage = Properties.Resources.btn_ingresar2_log1;
            btn_ingresar.BackgroundImage = Properties.Resources.botonesnu2;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text != "" && txtpassword.Text != "")
            {
                if (objcontrol.validar(txtusuario.Text, txtpassword.Text)==1)
                {

                    Vista.Menu ob = new Vista.Menu();
                    ob.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o Password incorrectos", "◄ AVISO ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                }
            }
            else
            {
                MessageBox.Show("Completar los Campos", "◄ AVISO ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desea Salir", "◄ AVISO ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
