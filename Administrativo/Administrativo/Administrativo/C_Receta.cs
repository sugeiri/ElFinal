﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administrativo
{
    public partial class C_Receta : Form
    {
        public string Id = "";
        public string Descr = "";
        public string aa_Tipo_r = "";
        string aa_modo = "a";
        public C_Receta(string ii_modo)
        {
            InitializeComponent();
            CB_Filtro.Items.Add(" ");
            CB_Filtro.Items.Add("Codigo");
            CB_Filtro.Items.Add("Descripcion");
            CB_Filtro.Items.Add("Tipo Receta");
            aa_modo = ii_modo;

        }

        private void TFiltro_TextChanged(object sender, EventArgs e)
        {
            int fila = 0;
            if (!string.IsNullOrWhiteSpace(TFiltro.Text))
            {

                foreach (DataGridViewRow dr in DG_Datos.Rows)
                {
                    fila = CB_Filtro.SelectedIndex;
                    if(dr.Cells[fila-1].Value!=null)
                    {
                        if ((dr.Cells[fila-1].Value.ToString().ToUpper()).IndexOf(TFiltro.Text.ToUpper()) == 0)
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
            else
            {
                foreach (DataGridViewRow dr in DG_Datos.Rows)
                {
                    dr.Visible = true;

                }
            }
        }
        int Fila_Actual()
        {
            return DG_Datos.CurrentRow.Index;
        }
        void Modificar()
        {
            int i = Fila_Actual();
            Id = DG_Datos.Rows[i].Cells[0].Value.ToString().Trim();
            receta form = new receta("m",Id);
            if (form.ShowDialog() == DialogResult.OK)
                Lee_Datos();

        }
        private void DG_Datos_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (aa_modo.ToUpper() == "E")
                {

                    int i = Fila_Actual();
                    Id = DG_Datos.Rows[i].Cells[0].Value.ToString().Trim();
                    Descr = DG_Datos.Rows[i].Cells[1].Value.ToString().Trim();
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                    return;
                }
                else
                {
                    Modificar();
                }

            }
        }

        private void DG_Datos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (aa_modo.ToUpper() == "E")
            {

                int i = Fila_Actual();
                Id = DG_Datos.Rows[i].Cells[0].Value.ToString().Trim();
                Descr = DG_Datos.Rows[i].Cells[1].Value.ToString().Trim();
                this.DialogResult = DialogResult.OK;
                this.Dispose();
                return;
            }
            else
            {
                Modificar();
            }

        }

        private void DG_Datos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (aa_modo.ToUpper() == "E")
            {

                int i = Fila_Actual();
                Id = DG_Datos.Rows[i].Cells[0].Value.ToString().Trim();
                Descr = DG_Datos.Rows[i].Cells[1].Value.ToString().Trim();
                this.DialogResult = DialogResult.OK;
                this.Dispose();
                return;
            }
            else
            {
                Modificar();
            }

        }

        private void C_Receta_Load(object sender, EventArgs e)
        {
            Lee_Datos();
        }
        void Lee_Datos()
        {
            DG_Datos.Rows.Clear();
            string Error = "";
            string sql = "";
            if (aa_Tipo_r.ToString().Trim() != "")
            {
                sql = " Select id_receta, descr_receta, id_tipo_receta, descr_t_receta " +
                    "from receta,tipo_receta " +
                     " where  estado_receta = 'A' and id_tipo_receta ='" + aa_Tipo_r + "'" +
                     " and id_tipo_receta = id_t_receta";
            }
            else
            {
                sql = " Select id_receta, descr_receta, id_tipo_receta, descr_t_receta " +
                    "from receta,tipo_receta " +
                   " where  estado_receta = 'A' and id_tipo_receta = id_t_receta";

            }
            DataSet DS = funciones.EjecutaSQL(sql, ref Error);
            int Count = DS.Tables[0].Rows.Count;
            if (Count > 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    DataGridViewRow ii_row = new DataGridViewRow();
                    ii_row.CreateCells(DG_Datos);
                    ii_row.Cells[0].Value = DS.Tables[0].Rows[i]["id_receta"].ToString().Trim();
                    ii_row.Cells[1].Value = DS.Tables[0].Rows[i]["descr_receta"].ToString().Trim();
                    ii_row.Cells[2].Value = DS.Tables[0].Rows[i]["descr_t_receta"].ToString().Trim();
                    DG_Datos.Rows.Add(ii_row);
                }
            }
            else
            {
                MessageBox.Show("NO ENCONTRO DATO DE LA BUSQUEDA");
            }

        }

        private void BCrear_Click(object sender, EventArgs e)
        {
            receta form = new receta("a","");
            form.ShowDialog();
            Lee_Datos();
        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lee_Datos();
        }
    }
}
