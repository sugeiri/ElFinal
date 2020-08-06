namespace Administrativo
{
    partial class receta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(receta));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tid = new System.Windows.Forms.TextBox();
            this.tdescr = new System.Windows.Forms.TextBox();
            this.TTipo = new System.Windows.Forms.TextBox();
            this.TDescr_T = new System.Windows.Forms.TextBox();
            this.cb_estado = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.PB_Foto = new System.Windows.Forms.PictureBox();
            this.TPorcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TDuracion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Foto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(198, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Receta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripcion:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(5, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Tipo Receta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(297, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Estado:";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Location = new System.Drawing.Point(525, 185);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 44);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Location = new System.Drawing.Point(573, 185);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(46, 44);
            this.button3.TabIndex = 6;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tid
            // 
            this.tid.Location = new System.Drawing.Point(142, 38);
            this.tid.Name = "tid";
            this.tid.Size = new System.Drawing.Size(100, 20);
            this.tid.TabIndex = 7;
            this.tid.TextChanged += new System.EventHandler(this.tid_TextChanged);
            this.tid.Leave += new System.EventHandler(this.tid_Leave);
            // 
            // tdescr
            // 
            this.tdescr.Location = new System.Drawing.Point(142, 70);
            this.tdescr.Name = "tdescr";
            this.tdescr.Size = new System.Drawing.Size(326, 20);
            this.tdescr.TabIndex = 8;
            // 
            // TTipo
            // 
            this.TTipo.Location = new System.Drawing.Point(142, 100);
            this.TTipo.Name = "TTipo";
            this.TTipo.Size = new System.Drawing.Size(58, 20);
            this.TTipo.TabIndex = 9;
            this.TTipo.Leave += new System.EventHandler(this.Tunidad_Leave);
            // 
            // TDescr_T
            // 
            this.TDescr_T.BackColor = System.Drawing.SystemColors.Info;
            this.TDescr_T.Location = new System.Drawing.Point(202, 100);
            this.TDescr_T.Name = "TDescr_T";
            this.TDescr_T.ReadOnly = true;
            this.TDescr_T.Size = new System.Drawing.Size(266, 20);
            this.TDescr_T.TabIndex = 10;
            // 
            // cb_estado
            // 
            this.cb_estado.FormattingEnabled = true;
            this.cb_estado.Location = new System.Drawing.Point(370, 38);
            this.cb_estado.Name = "cb_estado";
            this.cb_estado.Size = new System.Drawing.Size(98, 21);
            this.cb_estado.TabIndex = 11;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PB_Foto
            // 
            this.PB_Foto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PB_Foto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Foto.Location = new System.Drawing.Point(472, 6);
            this.PB_Foto.Name = "PB_Foto";
            this.PB_Foto.Size = new System.Drawing.Size(147, 159);
            this.PB_Foto.TabIndex = 19;
            this.PB_Foto.TabStop = false;
            this.PB_Foto.Click += new System.EventHandler(this.PB_Foto_Click);
            // 
            // TPorcion
            // 
            this.TPorcion.Location = new System.Drawing.Point(142, 130);
            this.TPorcion.Name = "TPorcion";
            this.TPorcion.Size = new System.Drawing.Size(58, 20);
            this.TPorcion.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Porcion Base:";
            // 
            // TDuracion
            // 
            this.TDuracion.Location = new System.Drawing.Point(142, 162);
            this.TDuracion.Name = "TDuracion";
            this.TDuracion.Size = new System.Drawing.Size(58, 20);
            this.TDuracion.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Duracion(Min):";
            // 
            // receta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 229);
            this.Controls.Add(this.TDuracion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TPorcion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PB_Foto);
            this.Controls.Add(this.cb_estado);
            this.Controls.Add(this.TDescr_T);
            this.Controls.Add(this.TTipo);
            this.Controls.Add(this.tdescr);
            this.Controls.Add(this.tid);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "receta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.receta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Foto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tid;
        private System.Windows.Forms.TextBox tdescr;
        private System.Windows.Forms.TextBox TTipo;
        private System.Windows.Forms.TextBox TDescr_T;
        private System.Windows.Forms.ComboBox cb_estado;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox PB_Foto;
        private System.Windows.Forms.TextBox TDuracion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TPorcion;
        private System.Windows.Forms.Label label5;
    }
}