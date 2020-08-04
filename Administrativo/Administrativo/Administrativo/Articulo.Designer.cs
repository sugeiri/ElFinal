namespace Administrativo
{
    partial class Articulo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Articulo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BCat = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.BSeguir = new System.Windows.Forms.Button();
            this.tid = new System.Windows.Forms.TextBox();
            this.tdescr = new System.Windows.Forms.TextBox();
            this.Tcat = new System.Windows.Forms.TextBox();
            this.TDescr_Cat = new System.Windows.Forms.TextBox();
            this.CB_Estado = new System.Windows.Forms.ComboBox();
            this.Tdescr_Grupo = new System.Windows.Forms.TextBox();
            this.TGrupo = new System.Windows.Forms.TextBox();
            this.BGrupo = new System.Windows.Forms.Button();
            this.Tdescr_Tipo = new System.Windows.Forms.TextBox();
            this.TTipo = new System.Windows.Forms.TextBox();
            this.BTipo = new System.Windows.Forms.Button();
            this.PB_Foto = new System.Windows.Forms.PictureBox();
            this.CB_AplicaInv = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Foto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(235, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Articulo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripcion:";
            // 
            // BCat
            // 
            this.BCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCat.Location = new System.Drawing.Point(1, 90);
            this.BCat.Name = "BCat";
            this.BCat.Size = new System.Drawing.Size(133, 23);
            this.BCat.TabIndex = 3;
            this.BCat.Text = "Categoria";
            this.BCat.UseVisualStyleBackColor = true;
            this.BCat.Click += new System.EventHandler(this.BCat_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(292, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Estado:";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Location = new System.Drawing.Point(506, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 44);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // BSeguir
            // 
            this.BSeguir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BSeguir.BackgroundImage")));
            this.BSeguir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BSeguir.Location = new System.Drawing.Point(554, 197);
            this.BSeguir.Name = "BSeguir";
            this.BSeguir.Size = new System.Drawing.Size(46, 44);
            this.BSeguir.TabIndex = 6;
            this.BSeguir.UseVisualStyleBackColor = true;
            this.BSeguir.Click += new System.EventHandler(this.BSeguir_Click);
            // 
            // tid
            // 
            this.tid.Location = new System.Drawing.Point(137, 33);
            this.tid.Name = "tid";
            this.tid.Size = new System.Drawing.Size(100, 20);
            this.tid.TabIndex = 7;
            this.tid.TextChanged += new System.EventHandler(this.TId_TextChanged);
            this.tid.Leave += new System.EventHandler(this.TId_Leave);
            // 
            // tdescr
            // 
            this.tdescr.Location = new System.Drawing.Point(137, 65);
            this.tdescr.Name = "tdescr";
            this.tdescr.Size = new System.Drawing.Size(326, 20);
            this.tdescr.TabIndex = 8;
            // 
            // Tcat
            // 
            this.Tcat.Location = new System.Drawing.Point(137, 92);
            this.Tcat.Name = "Tcat";
            this.Tcat.Size = new System.Drawing.Size(58, 20);
            this.Tcat.TabIndex = 9;
            this.Tcat.Leave += new System.EventHandler(this.Tcat_Leave);
            // 
            // TDescr_Cat
            // 
            this.TDescr_Cat.BackColor = System.Drawing.SystemColors.Info;
            this.TDescr_Cat.Location = new System.Drawing.Point(197, 92);
            this.TDescr_Cat.Name = "TDescr_Cat";
            this.TDescr_Cat.ReadOnly = true;
            this.TDescr_Cat.Size = new System.Drawing.Size(266, 20);
            this.TDescr_Cat.TabIndex = 10;
            // 
            // CB_Estado
            // 
            this.CB_Estado.FormattingEnabled = true;
            this.CB_Estado.Location = new System.Drawing.Point(365, 33);
            this.CB_Estado.Name = "CB_Estado";
            this.CB_Estado.Size = new System.Drawing.Size(98, 21);
            this.CB_Estado.TabIndex = 11;
            // 
            // Tdescr_Grupo
            // 
            this.Tdescr_Grupo.BackColor = System.Drawing.SystemColors.Info;
            this.Tdescr_Grupo.Location = new System.Drawing.Point(197, 118);
            this.Tdescr_Grupo.Name = "Tdescr_Grupo";
            this.Tdescr_Grupo.ReadOnly = true;
            this.Tdescr_Grupo.Size = new System.Drawing.Size(266, 20);
            this.Tdescr_Grupo.TabIndex = 14;
            // 
            // TGrupo
            // 
            this.TGrupo.Location = new System.Drawing.Point(137, 118);
            this.TGrupo.Name = "TGrupo";
            this.TGrupo.Size = new System.Drawing.Size(58, 20);
            this.TGrupo.TabIndex = 13;
            this.TGrupo.Leave += new System.EventHandler(this.TGrupo_Leave);
            // 
            // BGrupo
            // 
            this.BGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGrupo.Location = new System.Drawing.Point(1, 116);
            this.BGrupo.Name = "BGrupo";
            this.BGrupo.Size = new System.Drawing.Size(133, 23);
            this.BGrupo.TabIndex = 12;
            this.BGrupo.Text = "Grupo";
            this.BGrupo.UseVisualStyleBackColor = true;
            this.BGrupo.Click += new System.EventHandler(this.BGrupo_Click);
            // 
            // Tdescr_Tipo
            // 
            this.Tdescr_Tipo.BackColor = System.Drawing.SystemColors.Info;
            this.Tdescr_Tipo.Location = new System.Drawing.Point(197, 144);
            this.Tdescr_Tipo.Name = "Tdescr_Tipo";
            this.Tdescr_Tipo.ReadOnly = true;
            this.Tdescr_Tipo.Size = new System.Drawing.Size(266, 20);
            this.Tdescr_Tipo.TabIndex = 17;
            // 
            // TTipo
            // 
            this.TTipo.Location = new System.Drawing.Point(137, 144);
            this.TTipo.Name = "TTipo";
            this.TTipo.Size = new System.Drawing.Size(58, 20);
            this.TTipo.TabIndex = 16;
            this.TTipo.Leave += new System.EventHandler(this.TTipo_Leave);
            // 
            // BTipo
            // 
            this.BTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTipo.Location = new System.Drawing.Point(1, 142);
            this.BTipo.Name = "BTipo";
            this.BTipo.Size = new System.Drawing.Size(133, 23);
            this.BTipo.TabIndex = 15;
            this.BTipo.Text = "Tipo";
            this.BTipo.UseVisualStyleBackColor = true;
            this.BTipo.Click += new System.EventHandler(this.BTipo_Click);
            // 
            // PB_Foto
            // 
            this.PB_Foto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PB_Foto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Foto.Location = new System.Drawing.Point(469, 12);
            this.PB_Foto.Name = "PB_Foto";
            this.PB_Foto.Size = new System.Drawing.Size(131, 152);
            this.PB_Foto.TabIndex = 18;
            this.PB_Foto.TabStop = false;
            this.PB_Foto.Click += new System.EventHandler(this.PB_Foto_Click);
            // 
            // CB_AplicaInv
            // 
            this.CB_AplicaInv.AutoSize = true;
            this.CB_AplicaInv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CB_AplicaInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_AplicaInv.Location = new System.Drawing.Point(332, 170);
            this.CB_AplicaInv.Name = "CB_AplicaInv";
            this.CB_AplicaInv.Size = new System.Drawing.Size(131, 21);
            this.CB_AplicaInv.TabIndex = 19;
            this.CB_AplicaInv.Text = "Aplica Inventario";
            this.CB_AplicaInv.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Articulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 256);
            this.Controls.Add(this.CB_AplicaInv);
            this.Controls.Add(this.PB_Foto);
            this.Controls.Add(this.Tdescr_Tipo);
            this.Controls.Add(this.TTipo);
            this.Controls.Add(this.BTipo);
            this.Controls.Add(this.Tdescr_Grupo);
            this.Controls.Add(this.TGrupo);
            this.Controls.Add(this.BGrupo);
            this.Controls.Add(this.CB_Estado);
            this.Controls.Add(this.TDescr_Cat);
            this.Controls.Add(this.Tcat);
            this.Controls.Add(this.tdescr);
            this.Controls.Add(this.tid);
            this.Controls.Add(this.BSeguir);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BCat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Articulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Articulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Foto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BCat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BSeguir;
        private System.Windows.Forms.TextBox tid;
        private System.Windows.Forms.TextBox tdescr;
        private System.Windows.Forms.TextBox Tcat;
        private System.Windows.Forms.TextBox TDescr_Cat;
        private System.Windows.Forms.ComboBox CB_Estado;
        private System.Windows.Forms.TextBox Tdescr_Grupo;
        private System.Windows.Forms.TextBox TGrupo;
        private System.Windows.Forms.Button BGrupo;
        private System.Windows.Forms.TextBox Tdescr_Tipo;
        private System.Windows.Forms.TextBox TTipo;
        private System.Windows.Forms.Button BTipo;
        private System.Windows.Forms.PictureBox PB_Foto;
        private System.Windows.Forms.CheckBox CB_AplicaInv;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}