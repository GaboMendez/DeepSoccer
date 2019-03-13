namespace SoccerVisual
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.F32 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TiTle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // F32
            // 
            this.F32.BackColor = System.Drawing.Color.Transparent;
            this.F32.BackgroundImage = global::SoccerVisual.Properties.Resources.Rey;
            this.F32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.F32.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.F32.FlatAppearance.BorderSize = 0;
            this.F32.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.F32.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.F32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.F32.Font = new System.Drawing.Font("Bell MT", 18F);
            this.F32.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.F32.Location = new System.Drawing.Point(87, 12);
            this.F32.Name = "F32";
            this.F32.Size = new System.Drawing.Size(143, 182);
            this.F32.TabIndex = 16;
            this.F32.UseVisualStyleBackColor = false;
            this.F32.Click += new System.EventHandler(this.F32_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(1, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 209);
            this.label1.TabIndex = 17;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TiTle
            // 
            this.TiTle.BackColor = System.Drawing.Color.Transparent;
            this.TiTle.BackgroundImage = global::SoccerVisual.Properties.Resources._003006_simple_red_glossy_icon_media_a_media31_back;
            this.TiTle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TiTle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.TiTle.FlatAppearance.BorderSize = 0;
            this.TiTle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.TiTle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.TiTle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TiTle.Font = new System.Drawing.Font("Bell MT", 18F);
            this.TiTle.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.TiTle.Location = new System.Drawing.Point(5, 436);
            this.TiTle.Name = "TiTle";
            this.TiTle.Size = new System.Drawing.Size(72, 77);
            this.TiTle.TabIndex = 21;
            this.TiTle.UseVisualStyleBackColor = false;
            this.TiTle.Click += new System.EventHandler(this.TiTle_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SoccerVisual.Properties.Resources.fondo_negro;
            this.ClientSize = new System.Drawing.Size(335, 513);
            this.Controls.Add(this.TiTle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.F32);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button F32;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TiTle;
    }
}