using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafologiaAC.Vista
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmEvaluar obj = new frmEvaluar();
            obj.MdiParent = this;
            obj.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);

        }

        private void configurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimiento obj = new frmMantenimiento();
            obj.MdiParent = this;
            obj.Show();
        }

        private void revisarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formevaluados obj = new Formevaluados();
            obj.MdiParent = this;
            obj.Show();
        }
    }
}
