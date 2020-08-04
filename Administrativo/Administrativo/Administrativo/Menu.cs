using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administrativo
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            C_Pant_Gen CP = new C_Pant_Gen("c", "Categoria_ARticulo", "CATEGORIA ARTICULO");
            CP.ShowDialog();
        }

        private void crearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Pant_Gen CP = new Pant_Gen("a", "Categoria_ARticulo", "CATEGORIA ARTICULO");
            CP.ShowDialog();
        }

        private void consultarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            C_Pant_Gen CP = new C_Pant_Gen("c", "grupo_ARticulo", "GRUPO ARTICULO");
            CP.ShowDialog();
        }

        private void crearToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Pant_Gen CP = new Pant_Gen("a", "grupo_ARticulo", "GRUPO ARTICULO");
            CP.ShowDialog();
        }

        private void consultarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            C_TipoArticulo CP = new C_TipoArticulo("c");
            CP.ShowDialog();

        }

        private void crearToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            TipoArticulo CP = new TipoArticulo("a","");
            CP.ShowDialog();

        }

        private void consultarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            C_Pant_Gen CP = new C_Pant_Gen("c", "Unidad_Medida", "UNIDAD MEDIDA");
            CP.ShowDialog();
        }

        private void crearToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Pant_Gen CP = new Pant_Gen("a", "Unidad_Medida", "UNIDAD MEDIDA");
            CP.ShowDialog();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C_Articulo CP = new C_Articulo("c");
            CP.ShowDialog();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Articulo CP = new Articulo("a","");
            CP.ShowDialog();
        }

        private void consultarToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            C_Pant_Gen CP = new C_Pant_Gen("c", "Tipo_receta", "TIPO RECETA");
            CP.ShowDialog();
        }

        private void crearToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Pant_Gen CP = new Pant_Gen("a", "Tipo_receta", "TIPO RECETA");
            CP.ShowDialog();
        }

        private void consultarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            C_Receta CP = new C_Receta("c");
            CP.ShowDialog();
        }

        private void crearToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            receta CP = new receta("a", "");
            CP.ShowDialog();
        }

        private void consultarToolStripMenuItem7_Click(object sender, EventArgs e)
        {

        }

        private void crearToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Formula CP = new Formula("a", "");
            CP.ShowDialog();
        }
    }
}
