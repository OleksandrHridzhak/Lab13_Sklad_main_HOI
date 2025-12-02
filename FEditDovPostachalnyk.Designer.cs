namespace Lab13_Sklad_main_HOI
{
    partial class FEditDovPostachalnyk
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.DGVDovPostachalnyk = new System.Windows.Forms.DataGridView();
            this.TBNewPostachalnyk = new System.Windows.Forms.TextBox();
            this.BAddPostachalnyk = new System.Windows.Forms.Button();
            this.BEditPostachalnyk = new System.Windows.Forms.Button();
            this.BDeletePostachalnyk = new System.Windows.Forms.Button();
            this.BClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDovPostachalnyk)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVDovPostachalnyk
            // 
            this.DGVDovPostachalnyk.AllowUserToAddRows = false;
            this.DGVDovPostachalnyk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDovPostachalnyk.Location = new System.Drawing.Point(12, 12);
            this.DGVDovPostachalnyk.MultiSelect = false;
            this.DGVDovPostachalnyk.Name = "DGVDovPostachalnyk";
            this.DGVDovPostachalnyk.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVDovPostachalnyk.Size = new System.Drawing.Size(500, 300);
            this.DGVDovPostachalnyk.TabIndex = 0;
            this.DGVDovPostachalnyk.SelectionChanged += new System.EventHandler(this.DGVDovPostachalnyk_SelectionChanged);
            // 
            // TBNewPostachalnyk
            // 
            this.TBNewPostachalnyk.Location = new System.Drawing.Point(15, 35);
            this.TBNewPostachalnyk.Name = "TBNewPostachalnyk";
            this.TBNewPostachalnyk.Size = new System.Drawing.Size(450, 20);
            this.TBNewPostachalnyk.TabIndex = 1;
            // 
            // BAddPostachalnyk
            // 
            this.BAddPostachalnyk.Location = new System.Drawing.Point(15, 70);
            this.BAddPostachalnyk.Name = "BAddPostachalnyk";
            this.BAddPostachalnyk.Size = new System.Drawing.Size(110, 30);
            this.BAddPostachalnyk.TabIndex = 2;
            this.BAddPostachalnyk.Text = "Додати";
            this.BAddPostachalnyk.UseVisualStyleBackColor = true;
            this.BAddPostachalnyk.Click += new System.EventHandler(this.BAddPostachalnyk_Click);
            // 
            // BEditPostachalnyk
            // 
            this.BEditPostachalnyk.Location = new System.Drawing.Point(135, 70);
            this.BEditPostachalnyk.Name = "BEditPostachalnyk";
            this.BEditPostachalnyk.Size = new System.Drawing.Size(110, 30);
            this.BEditPostachalnyk.TabIndex = 3;
            this.BEditPostachalnyk.Text = "Змінити";
            this.BEditPostachalnyk.UseVisualStyleBackColor = true;
            this.BEditPostachalnyk.Click += new System.EventHandler(this.BEditPostachalnyk_Click);
            // 
            // BDeletePostachalnyk
            // 
            this.BDeletePostachalnyk.Location = new System.Drawing.Point(255, 70);
            this.BDeletePostachalnyk.Name = "BDeletePostachalnyk";
            this.BDeletePostachalnyk.Size = new System.Drawing.Size(110, 30);
            this.BDeletePostachalnyk.TabIndex = 4;
            this.BDeletePostachalnyk.Text = "Видалити";
            this.BDeletePostachalnyk.UseVisualStyleBackColor = true;
            this.BDeletePostachalnyk.Click += new System.EventHandler(this.BDeletePostachalnyk_Click);
            // 
            // BClose
            // 
            this.BClose.Location = new System.Drawing.Point(185, 115);
            this.BClose.Name = "BClose";
            this.BClose.Size = new System.Drawing.Size(110, 30);
            this.BClose.TabIndex = 5;
            this.BClose.Text = "Закрити";
            this.BClose.UseVisualStyleBackColor = true;
            this.BClose.Click += new System.EventHandler(this.BClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Назва постачальника:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TBNewPostachalnyk);
            this.panel1.Controls.Add(this.BClose);
            this.panel1.Controls.Add(this.BAddPostachalnyk);
            this.panel1.Controls.Add(this.BDeletePostachalnyk);
            this.panel1.Controls.Add(this.BEditPostachalnyk);
            this.panel1.Location = new System.Drawing.Point(12, 320);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 160);
            this.panel1.TabIndex = 7;
            // 
            // FEditDovPostachalnyk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 491);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DGVDovPostachalnyk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FEditDovPostachalnyk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редагування довідника постачальників";
            this.Load += new System.EventHandler(this.FEditDovPostachalnyk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDovPostachalnyk)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVDovPostachalnyk;
        private System.Windows.Forms.TextBox TBNewPostachalnyk;
        private System.Windows.Forms.Button BAddPostachalnyk;
        private System.Windows.Forms.Button BEditPostachalnyk;
        private System.Windows.Forms.Button BDeletePostachalnyk;
        private System.Windows.Forms.Button BClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}
