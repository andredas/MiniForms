namespace MiniForms
{
    partial class MainForm
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
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.lbSteps = new System.Windows.Forms.ListBox();
            this.lstbModule = new System.Windows.Forms.ListBox();
            this.plSteps = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(108, 35);
            this.btnUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(56, 25);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(108, 65);
            this.btnDown.Margin = new System.Windows.Forms.Padding(2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(56, 25);
            this.btnDown.TabIndex = 1;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(108, 94);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(56, 25);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(599, 379);
            this.btnRun.Margin = new System.Windows.Forms.Padding(2);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(56, 19);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lbSteps
            // 
            this.lbSteps.FormattingEnabled = true;
            this.lbSteps.Location = new System.Drawing.Point(11, 35);
            this.lbSteps.Margin = new System.Windows.Forms.Padding(2);
            this.lbSteps.Name = "lbSteps";
            this.lbSteps.Size = new System.Drawing.Size(93, 368);
            this.lbSteps.TabIndex = 2;
            this.lbSteps.SelectedIndexChanged += new System.EventHandler(this.lbSteps_SelectedIndexChanged);
            this.lbSteps.DoubleClick += new System.EventHandler(this.lbSteps_DoubleClick);
            // 
            // lstbModule
            // 
            this.lstbModule.FormattingEnabled = true;
            this.lstbModule.Location = new System.Drawing.Point(559, 35);
            this.lstbModule.Name = "lstbModule";
            this.lstbModule.Size = new System.Drawing.Size(120, 95);
            this.lstbModule.TabIndex = 3;
            this.lstbModule.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstbModule_MouseDown);
            // 
            // plSteps
            // 
            this.plSteps.AllowDrop = true;
            this.plSteps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(159)))), ((int)(((byte)(161)))));
            this.plSteps.Location = new System.Drawing.Point(169, 35);
            this.plSteps.Name = "plSteps";
            this.plSteps.Size = new System.Drawing.Size(384, 363);
            this.plSteps.TabIndex = 4;
            this.plSteps.DragDrop += new System.Windows.Forms.DragEventHandler(this.plSteps_DragDrop);
            this.plSteps.DragEnter += new System.Windows.Forms.DragEventHandler(this.plSteps_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Process";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 409);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.plSteps);
            this.Controls.Add(this.lstbModule);
            this.Controls.Add(this.lbSteps);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ListBox lbSteps;
        private System.Windows.Forms.ListBox lstbModule;
        private System.Windows.Forms.Panel plSteps;
        private System.Windows.Forms.Label label1;
    }
}

