namespace MiniForms.Modules.QRcode
{
    partial class DiaQRcode
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
            this.lbURL = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pbQRcode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRcode)).BeginInit();
            this.SuspendLayout();
            // 
            // lbURL
            // 
            this.lbURL.AutoSize = true;
            this.lbURL.Location = new System.Drawing.Point(13, 13);
            this.lbURL.Name = "lbURL";
            this.lbURL.Size = new System.Drawing.Size(32, 13);
            this.lbURL.TabIndex = 0;
            this.lbURL.Text = "URL:";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(51, 10);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(313, 20);
            this.txtURL.TabIndex = 1;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(16, 36);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(169, 23);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(191, 36);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(173, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pbQRcode
            // 
            this.pbQRcode.Location = new System.Drawing.Point(16, 65);
            this.pbQRcode.Name = "pbQRcode";
            this.pbQRcode.Size = new System.Drawing.Size(353, 242);
            this.pbQRcode.TabIndex = 4;
            this.pbQRcode.TabStop = false;
            // 
            // DiaQRcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 319);
            this.Controls.Add(this.pbQRcode);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.lbURL);
            this.Name = "DiaQRcode";
            this.Text = "QRcode Module";
            
            ((System.ComponentModel.ISupportInitialize)(this.pbQRcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbURL;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.PictureBox pbQRcode;
    }
}