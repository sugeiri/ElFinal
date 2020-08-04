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
    public partial class C_Articulo : Form
    {

        public string Id = "";
        string aa_modo = "";

        string aa_Ultima_Descr_filtro = "";
        Object fila_buscada = new object();

        public C_Articulo(string ii_modo)
        {
            InitializeComponent();
            aa_modo = ii_modo;

        }

        int Fila_Actual()
        {
            return DG_Datos.CurrentRow.Index;
        }
        private void DG_Datos_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (aa_modo.Trim().ToUpper() == "E")
                {
                    int i = Fila_Actual();
                    Id = DG_Datos.Rows[i].Cells[0].Value.ToString().Trim();
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                }
                else
                {
                    Modificar();
                }
                return;

            }
        }

        private void DG_Datos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (aa_modo.Trim().ToUpper() == "E")
            {
                int i = Fila_Actual();
                Id = DG_Datos.Rows[i].Cells[0].Value.ToString().Trim();
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
            else
            {
                Modificar();
            }
            return;
        }

        private void DG_Datos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (aa_modo.Trim().ToUpper() == "E")
            {
                int i = Fila_Actual();
                Id = DG_Datos.Rows[i].Cells[0].Value.ToString().Trim();
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
            else
            {
                Modificar();
            }
            return;
        }

        void Modificar()
        {
            int i = Fila_Actual();
            if (DG_Datos.Rows[i].Cells[0].Value != null)
            {
                Id = DG_Datos.Rows[i].Cells[0].Value.ToString().Trim();
                Articulo cs = new Articulo("m", Id);
                cs.ShowDialog();
                if (cs.DialogResult == DialogResult.OK)
                    Lee_Datos();
            }


        }
        private void C_Articulo_Load(object sender, EventArgs e)
        {
            Lee_Datos();
        }
        void Lee_Datos()
        {
            DG_Datos.Rows.Clear();
            string Error = "";
            string sql = " select ARTICULO.*,descr_cat_articulo,descr_g_articulo,descr_t_articulo " +
                            " from ARTICULO,CATEGORIA_ARTICULO,GRUPO_ARTICULO,TIPO_ARTICULO" +
                            " where ARTICULO.id_cat_articulo = CATEGORIA_ARTICULO.id_cat_articulo and" +
                                  " ARTICULO.id_gart_articulo = GRUPO_ARTICULO.id_g_articulo AND" +
                                  " ARTICULO.id_tart_articulo = TIPO_ARTICULO.id_t_articulo";
            DataSet DS = funciones.EjecutaSQL(sql, ref Error);
            int Count = DS.Tables.Count;
            if (Count > 0)
            {
                Count = DS.Tables[0].Rows.Count;
                for (int i = 0; i < Count; i++)
                {
                    DataGridViewRow ii_row = new DataGridViewRow();
                    ii_row.CreateCells(DG_Datos);
                    ii_row.Cells[0].Value = DS.Tables[0].Rows[i]["id_articulo"].ToString().Trim();
                    ii_row.Cells[1].Value = DS.Tables[0].Rows[i]["descr_articulo"].ToString().Trim();
                    ii_row.Cells[2].Value = DS.Tables[0].Rows[i]["estado_articulo"].ToString().Trim();
                    ii_row.Cells[3].Value = DS.Tables[0].Rows[i]["id_cat_articulo"].ToString().Trim();
                    ii_row.Cells[4].Value = DS.Tables[0].Rows[i]["descr_cat_articulo"].ToString().Trim();
                    ii_row.Cells[5].Value = DS.Tables[0].Rows[i]["id_gart_articulo"].ToString().Trim();
                    ii_row.Cells[6].Value = DS.Tables[0].Rows[i]["descr_g_articulo"].ToString().Trim();
                    ii_row.Cells[7].Value = DS.Tables[0].Rows[i]["id_tart_articulo"].ToString().Trim();
                    ii_row.Cells[8].Value = DS.Tables[0].Rows[i]["descr_t_articulo"].ToString().Trim();
                    ii_row.Cells[9].Value = DS.Tables[0].Rows[i]["aplica_inv_articulo"].ToString().Trim();
                    DG_Datos.Rows.Add(ii_row);
                }
            }
            else
            {
                MessageBox.Show("NO ENCONTRO DATO DE LA BUSQUEDA");
            }

        }
        void Muestra_Filas()
        {

            foreach (DataGridViewRow dr in DG_Datos.Rows)
            {
                dr.Visible = true;

            }

            EventArgs e = new EventArgs();
            Object ob = new Object();
            if (!string.IsNullOrWhiteSpace(TCodigo.Text.ToString().Trim()) && fila_buscada != TCodigo)
                TCodigo_TextChanged(ob, e);

            if (!string.IsNullOrWhiteSpace(TDescrArt.Text.ToString().Trim()) && fila_buscada != TDescrArt)
                TNombreTercero_TextChanged(ob, e);

            if (!string.IsNullOrWhiteSpace(TCat.Text.ToString().Trim()) && fila_buscada != TCat)
                TAseg_TextChanged(ob, e);

            if (!string.IsNullOrWhiteSpace(TDescrCat.Text.ToString().Trim()) && fila_buscada != TDescrCat)
                TDdescrAsec_TextChanged(ob, e);

            if (!string.IsNullOrWhiteSpace(TGrupo.Text.ToString().Trim()) && fila_buscada != TGrupo)
                TPlan_TextChanged(ob, e);

            if (!string.IsNullOrWhiteSpace(TdescrGrupo.Text.ToString().Trim()) && fila_buscada != TdescrGrupo)
                TdescrPlan_TextChanged(ob, e);
            
            if (!string.IsNullOrWhiteSpace(TTipo.Text.ToString().Trim()) && fila_buscada != TTipo)
                TTipo_TextChanged(ob, e);

            if (!string.IsNullOrWhiteSpace(TDescrTipo.Text.ToString().Trim()) && fila_buscada != TDescrTipo)
                TDescrTipo_TextChanged(ob, e);

           
            if (CB_Estado_Paciente.SelectedIndex > 0 && fila_buscada != CB_Estado_Paciente)
                CB_Estado_Paciente_SelectedIndexChanged(ob, e);

        }
        void Muestra_Filas_SoloCB()
        {

            foreach (DataGridViewRow dr in DG_Datos.Rows)
            {
                dr.Visible = true;

            }

            EventArgs e = new EventArgs();
            Object ob = new Object();
            string estado = "";
            if (CB_Estado_Paciente.SelectedIndex > 0)
            {
                estado = CB_Estado_Paciente.SelectedItem.ToString().Trim().Substring(0, 1).Trim();
                Filtra(2, estado, false);
            }
           
        }
        void Muestra_Filas_SinCB()
        {

            foreach (DataGridViewRow dr in DG_Datos.Rows)
            {
                dr.Visible = true;

            }

            EventArgs e = new EventArgs();
            Object ob = new Object();
            if (!string.IsNullOrWhiteSpace(TCodigo.Text.ToString().Trim()))
                TCodigo_TextChanged(ob, e);

            if (!string.IsNullOrWhiteSpace(TDescrArt.Text.ToString().Trim()))
                TNombreTercero_TextChanged(ob, e);

            if (!string.IsNullOrWhiteSpace(TGrupo.Text.ToString().Trim()))
                TPlan_TextChanged(ob, e);

            if (!string.IsNullOrWhiteSpace(TdescrGrupo.Text.ToString().Trim()))
                TdescrPlan_TextChanged(ob, e);


            if (!string.IsNullOrWhiteSpace(TdescrGrupo.Text.ToString().Trim()))
                TdescrPlan_TextChanged(ob, e);

            if (!string.IsNullOrWhiteSpace(TDescrCat.Text.ToString().Trim()))
                TDdescrAsec_TextChanged(ob, e);

            if (!string.IsNullOrWhiteSpace(TTipo.Text.ToString().Trim()) && fila_buscada != TTipo)
                TTipo_TextChanged(ob, e);

            if (!string.IsNullOrWhiteSpace(TDescrTipo.Text.ToString().Trim()) && fila_buscada != TDescrTipo)
                TDescrTipo_TextChanged(ob, e);


            Muestra_Filas_SoloCB();


        }

        void Filtra(int fila, string dato, bool codigo)
        {
            bool tiene_filtro = false;
            if (DG_Datos.Rows.Count > DG_Datos.Rows.GetRowCount(DataGridViewElementStates.Visible))
            {
                tiene_filtro = true;
            }

            foreach (DataGridViewRow dr in DG_Datos.Rows)
            {
                if (tiene_filtro && dr.Visible == false)
                {
                    continue;
                }
                else
                {


                    if (dr.Cells[fila].Value != null)
                    {
                        string cod = "";
                        if (codigo)
                            cod = int.Parse(dr.Cells[fila].Value.ToString().Trim()).ToString().Trim();
                        else
                            cod = dr.Cells[fila].Value.ToString().Trim();
                        if ((cod.ToLower()).IndexOf(dato.ToLower()) >= 0)
                        {
                            dr.Visible = true;
                        }
                        else
                        {
                            dr.Visible = false;
                        }
                    }
                }

            }
        }

        private void TCodigo_TextChanged(object sender, EventArgs e)
        {
            string id = TCodigo.Text.ToString().Trim();
            if (!string.IsNullOrWhiteSpace(id))
            {
                fila_buscada = sender;
                Filtra(0, id, true);
            }
            else
            {
                Muestra_Filas();
            }
        }

        private void TNombreTercero_TextChanged(object sender, EventArgs e)
        {
            bool muestra = false;
            string nombre = TDescrArt.Text.ToString().Trim().ToUpper();
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                fila_buscada = sender;
                if (nombre.Length < aa_Ultima_Descr_filtro.Length)
                {
                    muestra = true;
                }
                aa_Ultima_Descr_filtro = nombre;
                if (muestra)
                    Muestra_Filas();

                Filtra(1, nombre, false);

            }
            else
            {
                Muestra_Filas();
            }
        }
        private void CB_Estado_Paciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CB_Estado_Paciente.SelectedItem.ToString().Trim()) && CB_Estado_Paciente.SelectedIndex != 0)
            {
                fila_buscada = sender;
                string estado = CB_Estado_Paciente.SelectedItem.ToString().Trim().Substring(0, 1).Trim();
                Muestra_Filas_SinCB();
                Filtra(2, estado, false);

            }
            else
            {
                Muestra_Filas();
            }
        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            TCodigo.Text = "";
            TDescrArt.Text = "";
            CB_Estado_Paciente.SelectedIndex = 0;
            TCat.Text = "";
            TDescrCat.Text = "";
            TGrupo.Text = "";
            TdescrGrupo.Text = "";
            TTipo.Text = "";
            TDescrTipo.Text = "";
            foreach (DataGridViewRow dr in DG_Datos.Rows)
            {
                dr.Visible = true;

            }
        }
        private void TAseg_TextChanged(object sender, EventArgs e)
        {
            bool muestra = false;
            string nombre = TCat.Text.ToString().Trim().ToUpper();
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                fila_buscada = sender;
                if (nombre.Length < aa_Ultima_Descr_filtro.Length)
                {
                    muestra = true;
                }
                aa_Ultima_Descr_filtro = nombre;
                if (muestra)
                    Muestra_Filas();

                Filtra(3, nombre, true);

            }
            else
            {
                Muestra_Filas();
            }
        }

        private void TDdescrAsec_TextChanged(object sender, EventArgs e)
        {
            bool muestra = false;
            string nombre = TDescrCat.Text.ToString().Trim().ToUpper();
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                fila_buscada = sender;
                if (nombre.Length < aa_Ultima_Descr_filtro.Length)
                {
                    muestra = true;
                }
                aa_Ultima_Descr_filtro = nombre;
                if (muestra)
                    Muestra_Filas();

                Filtra(4, nombre, false);

            }
            else
            {
                Muestra_Filas();
            }
        }

        private void TPlan_TextChanged(object sender, EventArgs e)
        {
            bool muestra = false;
            string nombre = TGrupo.Text.ToString().Trim().ToUpper();
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                fila_buscada = sender;
                if (nombre.Length < aa_Ultima_Descr_filtro.Length)
                {
                    muestra = true;
                }
                aa_Ultima_Descr_filtro = nombre;
                if (muestra)
                    Muestra_Filas();

                Filtra(5, nombre, true);

            }
            else
            {
                Muestra_Filas();
            }
        }

        private void TdescrPlan_TextChanged(object sender, EventArgs e)
        {
            bool muestra = false;
            string nombre = TdescrGrupo.Text.ToString().Trim().ToUpper();
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                fila_buscada = sender;
                if (nombre.Length < aa_Ultima_Descr_filtro.Length)
                {
                    muestra = true;
                }
                aa_Ultima_Descr_filtro = nombre;
                if (muestra)
                    Muestra_Filas();

                Filtra(6, nombre, false);

            }
            else
            {
                Muestra_Filas();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                try
                {
                    if (item is TextBox)
                    {
                        item.Text = "";

                    }
                }
                catch { }
            }
            CB_Estado_Paciente.SelectedIndex = 0;
         
        }

        private void BCrear_Click(object sender, EventArgs e)
        {
            Articulo form = new Articulo("a","");
            form.ShowDialog();
        }

        private void TTipo_TextChanged(object sender, EventArgs e)
        {
            bool muestra = false;
            string nombre = TTipo.Text.ToString().Trim().ToUpper();
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                fila_buscada = sender;
                if (nombre.Length < aa_Ultima_Descr_filtro.Length)
                {
                    muestra = true;
                }
                aa_Ultima_Descr_filtro = nombre;
                if (muestra)
                    Muestra_Filas();

                Filtra(7, nombre, true);

            }
            else
            {
                Muestra_Filas();
            }
        }

        private void TDescrTipo_TextChanged(object sender, EventArgs e)
        {
            bool muestra = false;
            string nombre = TDescrTipo.Text.ToString().Trim().ToUpper();
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                fila_buscada = sender;
                if (nombre.Length < aa_Ultima_Descr_filtro.Length)
                {
                    muestra = true;
                }
                aa_Ultima_Descr_filtro = nombre;
                if (muestra)
                    Muestra_Filas();

                Filtra(8, nombre, false);

            }
            else
            {
                Muestra_Filas();
            }
        }
    }
}
