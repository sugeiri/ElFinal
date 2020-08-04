using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administrativo
{
    public partial class Articulo : Form
    {
        Clases.EArticulo aa_Articulo = new Clases.EArticulo();
        string aa_Id = "";
        string aa_modo = "";
        string FileName = "";
        public Articulo(string ii_modo, string ii_articulo)
        {
            InitializeComponent();
            aa_modo = ii_modo;
            aa_Id = ii_articulo;
        }

        private void BCat_Click(object sender, EventArgs e)
        {
            C_Pant_Gen CP = new C_Pant_Gen("e", "Categoria_ARticulo", "CATEGORIA ARTICULO");
            CP.ShowDialog();
            string id = CP.Id.ToString().Trim();
            string descr = CP.aa_Descr.ToString().Trim();
            if (id.Trim() != "0")
            {
                Tcat.Text = id;
                if (string.IsNullOrWhiteSpace(descr.Trim()))
                {
                    MessageBox.Show("No Existe este Dato en la Base de Datos");
                    return;
                }

                TDescr_Cat.Text = descr.ToString().Trim().ToUpper();
            }
        }

        private void BGrupo_Click(object sender, EventArgs e)
        {
            C_Pant_Gen CP = new C_Pant_Gen("e", "Grupo_ARticulo", "GRUPO ARTICULO");
            CP.ShowDialog();
            string id = CP.Id.ToString().Trim();
            string descr = CP.aa_Descr.ToString().Trim();
            if (id.Trim() != "0")
            {
                TGrupo.Text = id;
                if (string.IsNullOrWhiteSpace(descr.Trim()))
                {
                    MessageBox.Show("No Existe este Dato en la Base de Datos");
                    return;
                }

                Tdescr_Grupo.Text = descr.ToString().Trim().ToUpper();
            }
        }

        private void BTipo_Click(object sender, EventArgs e)
        {
            C_TipoArticulo CP = new C_TipoArticulo("e");
            CP.ShowDialog();
            string id = CP.Id.ToString().Trim();
            string descr = CP.Descr.ToString().Trim();
            if (id.Trim() != "0")
            {
                TTipo.Text = id;
                if (string.IsNullOrWhiteSpace(descr.Trim()))
                {
                    MessageBox.Show("No Existe este Dato en la Base de Datos");
                    return;
                }

                Tdescr_Tipo.Text = descr.ToString().Trim().ToUpper();
            }
        }

        private void Tcat_Leave(object sender, EventArgs e)
        {
            if (Tcat.Text.ToString().Trim() != "")
            {
                string descr = funciones.Lee_Descr_Gen(Tcat.Text.ToString().Trim(), "Categoria_Articulo");
                if (descr.ToString().Trim() == "")
                {
                    MessageBox.Show("No se encontro este dato en la base de datos");
                }
                TDescr_Cat.Text = descr;
            }
        }

        private void TGrupo_Leave(object sender, EventArgs e)
        {
            if (TGrupo.Text.ToString().Trim() != "")
            {
                string descr = funciones.Lee_Descr_Gen(TGrupo.Text.ToString().Trim(), "Grupo_Articulo");
                if (descr.ToString().Trim() == "")
                {
                    MessageBox.Show("No se encontro este dato en la base de datos");
                }
                Tdescr_Grupo.Text = descr;
            }
        }

        private void TTipo_Leave(object sender, EventArgs e)
        {
            if (TTipo.Text.ToString().Trim() != "")
            {
                string descr = funciones.Lee_Descr_Tipo_Articulo(TTipo.Text.ToString().Trim());
                if (descr.ToString().Trim() == "")
                {
                    MessageBox.Show("No se encontro este dato en la base de datos");
                }
                Tdescr_Tipo.Text = descr;
            }
        }

        private void TId_TextChanged(object sender, EventArgs e)
        {
            if (tid.Text.ToString().IndexOf("*") < 0 && tid.Text.ToString().Trim() != "")
                Valida_codigo();
        }
        bool Valida_codigo()
        {
            int id = 0;
            if (!int.TryParse(tid.Text.ToString(), out id))
            {
                MessageBox.Show("SOLO VALORES NUMERICOS");
                return false;
            }
            return true;

        }

        private void TId_Leave(object sender, EventArgs e)
        {
            if (tid.Text.ToString().Trim() != "")
            {
                if (tid.Text.ToString().Trim() == "*")
                {

                    tid.Text = funciones.Prox_Codigo("ARTICULO").ToString("######");
                }
                else
                {
                    Llena_Datos();
                }
            }
        }
        void Llena_Datos()
        {
            aa_Articulo = funciones.Lee_Articulo(tid.Text.ToString().Trim());
            Byte[] ImageByte;

            if (aa_Articulo != null)
            {
                aa_modo = "m";
                tdescr.Text = aa_Articulo.descr_articulo;
                if (aa_Articulo.estado_articulo.ToUpper() == "A")
                    CB_Estado.SelectedIndex = 0;
                else
                    CB_Estado.SelectedIndex = 1;
                Tcat.Text = aa_Articulo.id_cat_articulo;
                TGrupo.Text = aa_Articulo.id_gart_articulo;
                TTipo.Text = aa_Articulo.id_tart_articulo;
                if (aa_Articulo.aplica_inv_articulo.ToString().Trim() != "")
                    CB_AplicaInv.Checked = true;

                PB_Foto.SizeMode = PictureBoxSizeMode.Zoom;
                if (aa_Articulo.foto_articulo!=null)
                {
                    byte[] image = aa_Articulo.foto_articulo;
                    MemoryStream ms = new MemoryStream(image);
                    Image img = Image.FromStream(ms);
                    PB_Foto.Image = img;
                }


            }
            else
            {
                Valida_codigo();
            }
        }
        void Pasa_Datos()
        {
            aa_Articulo = new Clases.EArticulo();
            aa_Articulo.id_articulo = tid.Text;
            aa_Articulo.descr_articulo = tdescr.Text;
            aa_Articulo.estado_articulo = CB_Estado.SelectedItem.ToString().Trim().ToUpper().Substring(0, 1);
            aa_Articulo.id_cat_articulo = Tcat.Text;
            aa_Articulo.id_gart_articulo = TGrupo.Text;
            aa_Articulo.id_tart_articulo = TTipo.Text;
            if (CB_AplicaInv.Checked)
                aa_Articulo.aplica_inv_articulo = "X";
            else
                aa_Articulo.aplica_inv_articulo = "";

        }
        private void BSeguir_Click(object sender, EventArgs e)
        {
            string sql = "";
            string Error = "";
            errorProvider1.Clear();
            string mensaje = "ESTE CAMPO NO PUEDE ESTAR EN BLANCO";
            if (string.IsNullOrWhiteSpace(tid.Text.ToString().Trim()))
            {
                MessageBox.Show(mensaje);
                errorProvider1.SetError(tid, mensaje);
                tid.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(tdescr.Text.ToString().Trim()))
            {
                MessageBox.Show(mensaje);
                errorProvider1.SetError(tdescr, mensaje);
                tdescr.Focus();
            }
            if (string.IsNullOrWhiteSpace(Tcat.Text.ToString().Trim()))
            {
                MessageBox.Show(mensaje);
                errorProvider1.SetError(Tcat, mensaje);
                Tcat.Focus();
            }
            if (string.IsNullOrWhiteSpace(TGrupo.Text.ToString().Trim()))
            {
                MessageBox.Show(mensaje);
                errorProvider1.SetError(TGrupo, mensaje);
                TGrupo.Focus();
            }
            if (string.IsNullOrWhiteSpace(TTipo.Text.ToString().Trim()))
            {
                MessageBox.Show(mensaje);
                errorProvider1.SetError(TTipo, mensaje);
                TTipo.Focus();
            }
            Pasa_Datos();
            if (aa_modo.ToUpper().Trim() == "A")
            {
                if (CB_Estado.SelectedIndex != 0)
                {
                    MessageBox.Show("NO PUEDE REGISTRAR CON ESTADO DIFERENTE DE ACTIVO");
                    return;

                }

            }

            if (!funciones.Inserta_Articulo(aa_modo, aa_Articulo, FileName, ref Error))
            {
                MessageBox.Show(Error);
                return;
            }
            if (aa_modo.Trim().ToLower() == "a")
            {
                Limpia();

            }
            else
            {
                this.DialogResult = DialogResult.OK;

            }
        }
        void Limpia()
        {
            tid.Text = "";
            tdescr.Text = "";
            CB_Estado.SelectedIndex = 0;
            Tcat.Text = "";
            TDescr_Cat.Text = "";
            TGrupo.Text = "";
            Tdescr_Grupo.Text = "";
            TTipo.Text = "";
            Tdescr_Tipo.Text = "";
            CB_AplicaInv.Checked = false;
        }

        private void Articulo_Load(object sender, EventArgs e)
        {
            CB_Estado.Items.Add("A");
            CB_Estado.Items.Add("I");
            CB_Estado.SelectedIndex = 0;
            if (aa_modo.ToString().Trim().ToUpper() == "M")
            {
                tid.ReadOnly = true;
                tid.Text = aa_Id;
                Llena_Datos();
            }
        }

        private void PB_Foto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image files(*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    PB_Foto.SizeMode = PictureBoxSizeMode.Zoom;
                    PB_Foto.Image = Image.FromFile(openFileDialog1.FileName);
                    FileName = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
