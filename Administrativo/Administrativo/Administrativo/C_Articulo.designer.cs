namespace Administrativo
{
    partial class C_Articulo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DG_Datos = new System.Windows.Forms.DataGridView();
            this.TDescrArt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Estado_Paciente = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BCrear = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.TDescrCat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TdescrGrupo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TCat = new System.Windows.Forms.TextBox();
            this.TGrupo = new System.Windows.Forms.TextBox();
            this.TTipo = new System.Windows.Forms.TextBox();
            this.TDescrTipo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aseguradora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descrasec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescrPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodTip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aplica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Datos)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_Datos
            // 
            this.DG_Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Datos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nombre,
            this.Estado,
            this.Aseguradora,
            this.descrasec,
            this.DescrPlan,
            this.Plan,
            this.CodTip,
            this.Tipo,
            this.Aplica});
            this.DG_Datos.Location = new System.Drawing.Point(15, 151);
            this.DG_Datos.Name = "DG_Datos";
            this.DG_Datos.Size = new System.Drawing.Size(719, 284);
            this.DG_Datos.TabIndex = 30;
            this.DG_Datos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_Datos_CellDoubleClick);
            this.DG_Datos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DG_Datos_CellMouseDoubleClick);
            this.DG_Datos.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DG_Datos_PreviewKeyDown);
            // 
            // TDescrArt
            // 
            this.TDescrArt.Location = new System.Drawing.Point(121, 46);
            this.TDescrArt.Name = "TDescrArt";
            this.TDescrArt.Size = new System.Drawing.Size(471, 20);
            this.TDescrArt.TabIndex = 36;
            this.TDescrArt.TextChanged += new System.EventHandler(this.TNombreTercero_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "Descripcion";
            // 
            // TCodigo
            // 
            this.TCodigo.Location = new System.Drawing.Point(121, 16);
            this.TCodigo.Name = "TCodigo";
            this.TCodigo.Size = new System.Drawing.Size(196, 20);
            this.TCodigo.TabIndex = 44;
            this.TCodigo.TextChanged += new System.EventHandler(this.TCodigo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 45;
            this.label1.Text = "Articulo";
            // 
            // CB_Estado_Paciente
            // 
            this.CB_Estado_Paciente.FormattingEnabled = true;
            this.CB_Estado_Paciente.Items.AddRange(new object[] {
            "",
            "Activo",
            "Inactivo"});
            this.CB_Estado_Paciente.Location = new System.Drawing.Point(506, 12);
            this.CB_Estado_Paciente.Name = "CB_Estado_Paciente";
            this.CB_Estado_Paciente.Size = new System.Drawing.Size(86, 21);
            this.CB_Estado_Paciente.TabIndex = 49;
            this.CB_Estado_Paciente.SelectedIndexChanged += new System.EventHandler(this.CB_Estado_Paciente_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(443, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 48;
            this.label9.Text = "Estado:";
            // 
            // BCrear
            // 
            this.BCrear.BackColor = System.Drawing.Color.Transparent;
            this.BCrear.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.BCrear.FlatAppearance.BorderSize = 2;
            this.BCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCrear.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.BCrear.Location = new System.Drawing.Point(609, 49);
            this.BCrear.Name = "BCrear";
            this.BCrear.Size = new System.Drawing.Size(172, 36);
            this.BCrear.TabIndex = 59;
            this.BCrear.Text = "&CREAR";
            this.BCrear.UseVisualStyleBackColor = false;
            this.BCrear.Click += new System.EventHandler(this.BCrear_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(609, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 36);
            this.button2.TabIndex = 58;
            this.button2.Text = "&LIMPIAR FILTRO";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(609, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 36);
            this.button1.TabIndex = 57;
            this.button1.Text = "&CONSULTAR";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // TDescrCat
            // 
            this.TDescrCat.Location = new System.Drawing.Point(217, 73);
            this.TDescrCat.Name = "TDescrCat";
            this.TDescrCat.Size = new System.Drawing.Size(375, 20);
            this.TDescrCat.TabIndex = 61;
            this.TDescrCat.TextChanged += new System.EventHandler(this.TDdescrAsec_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 60;
            this.label2.Text = "Categoria";
            // 
            // TdescrGrupo
            // 
            this.TdescrGrupo.Location = new System.Drawing.Point(217, 97);
            this.TdescrGrupo.Name = "TdescrGrupo";
            this.TdescrGrupo.Size = new System.Drawing.Size(375, 20);
            this.TdescrGrupo.TabIndex = 63;
            this.TdescrGrupo.TextChanged += new System.EventHandler(this.TdescrPlan_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 62;
            this.label4.Text = "Grupo";
            // 
            // TCat
            // 
            this.TCat.Location = new System.Drawing.Point(121, 73);
            this.TCat.Name = "TCat";
            this.TCat.Size = new System.Drawing.Size(90, 20);
            this.TCat.TabIndex = 64;
            this.TCat.TextChanged += new System.EventHandler(this.TAseg_TextChanged);
            // 
            // TGrupo
            // 
            this.TGrupo.Location = new System.Drawing.Point(121, 98);
            this.TGrupo.Name = "TGrupo";
            this.TGrupo.Size = new System.Drawing.Size(90, 20);
            this.TGrupo.TabIndex = 65;
            this.TGrupo.TextChanged += new System.EventHandler(this.TPlan_TextChanged);
            // 
            // TTipo
            // 
            this.TTipo.Location = new System.Drawing.Point(121, 124);
            this.TTipo.Name = "TTipo";
            this.TTipo.Size = new System.Drawing.Size(90, 20);
            this.TTipo.TabIndex = 68;
            this.TTipo.TextChanged += new System.EventHandler(this.TTipo_TextChanged);
            // 
            // TDescrTipo
            // 
            this.TDescrTipo.Location = new System.Drawing.Point(217, 123);
            this.TDescrTipo.Name = "TDescrTipo";
            this.TDescrTipo.Size = new System.Drawing.Size(375, 20);
            this.TDescrTipo.TabIndex = 67;
            this.TDescrTipo.TextChanged += new System.EventHandler(this.TDescrTipo_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(75, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 66;
            this.label5.Text = "Tipo";
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 60;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Descripcion";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 150;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 50;
            // 
            // Aseguradora
            // 
            this.Aseguradora.HeaderText = "CodCat";
            this.Aseguradora.Name = "Aseguradora";
            this.Aseguradora.ReadOnly = true;
            this.Aseguradora.Visible = false;
            // 
            // descrasec
            // 
            this.descrasec.HeaderText = "Categoria";
            this.descrasec.Name = "descrasec";
            this.descrasec.ReadOnly = true;
            this.descrasec.Width = 110;
            // 
            // DescrPlan
            // 
            this.DescrPlan.HeaderText = "CodGrup";
            this.DescrPlan.Name = "DescrPlan";
            this.DescrPlan.ReadOnly = true;
            this.DescrPlan.Visible = false;
            // 
            // Plan
            // 
            this.Plan.HeaderText = "Grupo";
            this.Plan.Name = "Plan";
            this.Plan.ReadOnly = true;
            this.Plan.Width = 110;
            // 
            // CodTip
            // 
            this.CodTip.HeaderText = "CodTipo";
            this.CodTip.Name = "CodTip";
            this.CodTip.Visible = false;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.Width = 110;
            // 
            // Aplica
            // 
            this.Aplica.HeaderText = "Aplica Inv";
            this.Aplica.Name = "Aplica";
            this.Aplica.Width = 80;
            // 
            // C_Articulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 447);
            this.Controls.Add(this.TTipo);
            this.Controls.Add(this.TDescrTipo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TGrupo);
            this.Controls.Add(this.TCat);
            this.Controls.Add(this.TdescrGrupo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TDescrCat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BCrear);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CB_Estado_Paciente);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TCodigo);
            this.Controls.Add(this.TDescrArt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DG_Datos);
            this.Name = "C_Articulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C_Articulo";
            this.Load += new System.EventHandler(this.C_Articulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_Datos;
        private System.Windows.Forms.TextBox TDescrArt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_Estado_Paciente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BCrear;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TDescrCat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TdescrGrupo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TCat;
        private System.Windows.Forms.TextBox TGrupo;
        private System.Windows.Forms.TextBox TTipo;
        private System.Windows.Forms.TextBox TDescrTipo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aseguradora;
        private System.Windows.Forms.DataGridViewTextBoxColumn descrasec;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescrPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plan;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aplica;
    }
}