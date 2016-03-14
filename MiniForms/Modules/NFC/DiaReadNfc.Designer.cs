namespace MiniForms.Modules.NFC
{
    partial class DiaReadNfc
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
            this.lStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(79, 108);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(116, 17);
            this.lStatus.TabIndex = 0;
            this.lStatus.Text = "Scan your card...";
            // 
            // DiaReadNfc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.lStatus);
            this.Name = "DiaReadNfc";
            this.Text = "DiaReadNfc";
            this.Shown += new System.EventHandler(this.DiaNfc_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lStatus;
    }
}