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


namespace GrafologiaAC.Vista
{
    public partial class frmMantenimiento : Form
    {
        ClsMantenimiento obj = new ClsMantenimiento();
        public frmMantenimiento()
        {
            InitializeComponent();
        }
        System.Drawing.Image img1;
        private void frmMantenimiento_Load(object sender, EventArgs e)
        {
            cbletra.DataSource = obj.llenarcombo();
            cbletra.DisplayMember = "nombre";
            cbletra.ValueMember = "id";

          cbbuscar.DataSource = obj.llenarcombo();
            cbbuscar.DisplayMember = "nombre";
            cbbuscar.ValueMember = "id";
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            try
            {
                //localhost.Service1 lo = new localhost.Service1();

                //label2.Text = lo.algoritmo(,);

                OpenFileDialog open = new OpenFileDialog();
                open.Title = "Abrir archivo";
                open.Filter = "Jpg files (*.jpg)|*.jpg|Gif files (*.gif)|*.gif|Bitmap files (*.Bmp)|*.bmp|PNG files (*.png)|*.png*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    string strfilename = open.FileName;
                    Bitmap Picture = new Bitmap(strfilename);
                    img1 = (System.Drawing.Image)Picture;
                    imagen.Image = (System.Drawing.Image)Picture;
                    String NombreImg = open.SafeFileName;

                                    }
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image=ByteToImage( imageToByteArray(imagen.Image));
            if (obj.insertar(Convert.ToInt32(cbletra.SelectedValue.ToString()), txtreferencia.Text, obj.imageToByteArray(imagen.Image), Convert.ToInt32(txtpeso.Text)))
            {
                MessageBox.Show("Variante ingresada", "◄ AVISO ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
            //label7.Text = cbletra.SelectedValue.ToString();
        }
        
        //public static Bitmap ByteToImage(byte[] blob)
        //{
        //    MemoryStream mStream = new MemoryStream();
        //    byte[] pData = blob;
        //    mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
        //    Bitmap bm = new Bitmap(mStream, false);
        //    mStream.Dispose();
        //    return bm;
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            if (obj.eliminarvariante(Convert.ToInt32( txtid.Text)))
            {
                MessageBox.Show("Variante eliminada", "◄ AVISO ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (obj.actualizar(Convert.ToInt32( txtid.Text) ,Convert.ToInt32(cbletra.SelectedValue.ToString()), txtreferencia.Text, obj.imageToByteArray(imagen.Image), Convert.ToInt32(txtpeso.Text)))
            {
                MessageBox.Show("Variante modificada", "◄ AVISO ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = obj.llenardatagrid(Convert.ToInt32(cbbuscar.SelectedValue.ToString()), txtbuscar.Text);
            dataGridView1.DataMember = "letra";
         
        }
    }
}
