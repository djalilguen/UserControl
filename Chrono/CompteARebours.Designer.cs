namespace Chrono
{
    partial class CompteARebours
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panDigital = new System.Windows.Forms.Panel();
            this.lHours = new System.Windows.Forms.Label();
            this.lMinutes = new System.Windows.Forms.Label();
            this.lSeconds = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panAnalog = new System.Windows.Forms.Panel();
            this.panDigital.SuspendLayout();
            this.SuspendLayout();
            // 
            // panDigital
            // 
            this.panDigital.BackColor = System.Drawing.SystemColors.WindowText;
            this.panDigital.Controls.Add(this.lHours);
            this.panDigital.Controls.Add(this.lMinutes);
            this.panDigital.Controls.Add(this.lSeconds);
            this.panDigital.Controls.Add(this.label2);
            this.panDigital.Controls.Add(this.label3);
            this.panDigital.ForeColor = System.Drawing.Color.Red;
            this.panDigital.Location = new System.Drawing.Point(3, 157);
            this.panDigital.Name = "panDigital";
            this.panDigital.Size = new System.Drawing.Size(201, 55);
            this.panDigital.TabIndex = 6;
            this.panDigital.DoubleClick += new System.EventHandler(this.panDigital_DoubleClick);
            // 
            // lHours
            // 
            this.lHours.AutoSize = true;
            this.lHours.BackColor = System.Drawing.Color.Transparent;
            this.lHours.Font = new System.Drawing.Font("DS-Digital", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHours.ForeColor = System.Drawing.Color.Red;
            this.lHours.Location = new System.Drawing.Point(3, 7);
            this.lHours.Name = "lHours";
            this.lHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lHours.Size = new System.Drawing.Size(70, 47);
            this.lHours.TabIndex = 8;
            this.lHours.Text = "00";
            this.lHours.DoubleClick += new System.EventHandler(this.lHours_DoubleClick);
            // 
            // lMinutes
            // 
            this.lMinutes.AutoSize = true;
            this.lMinutes.BackColor = System.Drawing.Color.Transparent;
            this.lMinutes.Font = new System.Drawing.Font("DS-Digital", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMinutes.ForeColor = System.Drawing.Color.Red;
            this.lMinutes.Location = new System.Drawing.Point(69, 7);
            this.lMinutes.Name = "lMinutes";
            this.lMinutes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lMinutes.Size = new System.Drawing.Size(70, 47);
            this.lMinutes.TabIndex = 7;
            this.lMinutes.Text = "00";
            this.lMinutes.DoubleClick += new System.EventHandler(this.lMinutes_DoubleClick);
            // 
            // lSeconds
            // 
            this.lSeconds.AutoSize = true;
            this.lSeconds.BackColor = System.Drawing.Color.Transparent;
            this.lSeconds.Font = new System.Drawing.Font("DS-Digital", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSeconds.ForeColor = System.Drawing.Color.Red;
            this.lSeconds.Location = new System.Drawing.Point(138, 7);
            this.lSeconds.Name = "lSeconds";
            this.lSeconds.Size = new System.Drawing.Size(70, 47);
            this.lSeconds.TabIndex = 6;
            this.lSeconds.Text = "00";
            this.lSeconds.DoubleClick += new System.EventHandler(this.lSeconds_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("HP Simplified", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(52, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 43);
            this.label2.TabIndex = 9;
            this.label2.Text = ":";
            this.label2.DoubleClick += new System.EventHandler(this.label2_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("HP Simplified", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(118, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 43);
            this.label3.TabIndex = 10;
            this.label3.Text = ":";
            this.label3.DoubleClick += new System.EventHandler(this.label3_DoubleClick);
            // 
            // panAnalog
            // 
            this.panAnalog.Location = new System.Drawing.Point(20, 3);
            this.panAnalog.Name = "panAnalog";
            this.panAnalog.Size = new System.Drawing.Size(150, 150);
            this.panAnalog.TabIndex = 8;
            this.panAnalog.Visible = false;
            this.panAnalog.Paint += new System.Windows.Forms.PaintEventHandler(this.panAnalog_Paint);
            this.panAnalog.DoubleClick += new System.EventHandler(this.panAnalog_DoubleClick);
            // 
            // CompteARebours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panDigital);
            this.Controls.Add(this.panAnalog);
            this.Name = "CompteARebours";
            this.Size = new System.Drawing.Size(217, 226);
            this.Load += new System.EventHandler(this.CompteARebours_Load);
            this.panDigital.ResumeLayout(false);
            this.panDigital.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panDigital;
        private System.Windows.Forms.Label lHours;
        private System.Windows.Forms.Label lMinutes;
        private System.Windows.Forms.Label lSeconds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panAnalog;
    }
}
