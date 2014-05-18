namespace VTLight
{
    partial class OptionsForm
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
            this.cbAddToExplorator = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbAddToExplorator
            // 
            this.cbAddToExplorator.AutoSize = true;
            this.cbAddToExplorator.Location = new System.Drawing.Point(12, 12);
            this.cbAddToExplorator.Name = "cbAddToExplorator";
            this.cbAddToExplorator.Size = new System.Drawing.Size(127, 17);
            this.cbAddToExplorator.TabIndex = 0;
            this.cbAddToExplorator.Text = "Ajouter à l\'explorateur";
            this.cbAddToExplorator.UseVisualStyleBackColor = true;
            this.cbAddToExplorator.CheckedChanged += new System.EventHandler(this.cbAddToExplorator_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Fermer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 157);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbAddToExplorator);
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbAddToExplorator;
        private System.Windows.Forms.Button button1;
    }
}