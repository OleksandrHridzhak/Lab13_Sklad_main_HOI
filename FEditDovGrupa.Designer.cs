namespace Lab13_Sklad_main_HOI
{
    partial class FEditDovGrupa
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
            this.DGVDovGrupa = new System.Windows.Forms.DataGridView();
            this.TBNewGrupa = new System.Windows.Forms.TextBox();
            this.BAddGrupa = new System.Windows.Forms.Button();
            this.BEditGrupa = new System.Windows.Forms.Button();
            this.BDeleteGrupa = new System.Windows.Forms.Button();
            this.BClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDovGrupa)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVDovGrupa
            // 
            this.DGVDovGrupa.AllowUserToAddRows = false;
            this.DGVDovGrupa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDovGrupa.Location = new System.Drawing.Point(12, 12);
            this.DGVDovGrupa.MultiSelect = false;
            this.DGVDovGrupa.Name = "DGVDovGrupa";
            this.DGVDovGrupa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVDovGrupa.Size = new System.Drawing.Size(400, 300);
            this.DGVDovGrupa.TabIndex = 0;
            this.DGVDovGrupa.SelectionChanged += new System.EventHandler(this.DGVDovGrupa_SelectionChanged);
            // 
            // TBNewGrupa
            // 
            this.TBNewGrupa.Location = new System.Drawing.Point(15, 35);
            this.TBNewGrupa.Name = "TBNewGrupa";
            this.TBNewGrupa.Size = new System.Drawing.Size(350, 20);
            this.TBNewGrupa.TabIndex = 1;
            // 
            // BAddGrupa
            // 
            this.BAddGrupa.Location = new System.Drawing.Point(15, 70);
            this.BAddGrupa.Name = "BAddGrupa";
            this.BAddGrupa.Size = new System.Drawing.Size(110, 30);
            this.BAddGrupa.TabIndex = 2;
            this.BAddGrupa.Text = "Додати";
            this.BAddGrupa.UseVisualStyleBackColor = true;
            this.BAddGrupa.Click += new System.EventHandler(this.BAddGrupa_Click);
            // 
            // BEditGrupa
            // 
            this.BEditGrupa.Location = new System.Drawing.Point(135, 70);
            this.BEditGrupa.Name = "BEditGrupa";
            this.BEditGrupa.Size = new System.Drawing.Size(110, 30);
            this.BEditGrupa.TabIndex = 3;
            this.BEditGrupa.Text = "Змінити";
            this.BEditGrupa.UseVisualStyleBackColor = true;
            this.BEditGrupa.Click += new System.EventHandler(this.BEditGrupa_Click);
            // 
            // BDeleteGrupa
            // 
            this.BDeleteGrupa.Location = new System.Drawing.Point(255, 70);
            this.BDeleteGrupa.Name = "BDeleteGrupa";
            this.BDeleteGrupa.Size = new System.Drawing.Size(110, 30);
            this.BDeleteGrupa.TabIndex = 4;
            this.BDeleteGrupa.Text = "Видалити";
            this.BDeleteGrupa.UseVisualStyleBackColor = true;
            this.BDeleteGrupa.Click += new System.EventHandler(this.BDeleteGrupa_Click);
            // 
            // BClose
            // 
            this.BClose.Location = new System.Drawing.Point(135, 115);
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
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Назва групи:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TBNewGrupa);
            this.panel1.Controls.Add(this.BClose);
            this.panel1.Controls.Add(this.BAddGrupa);
            this.panel1.Controls.Add(this.BDeleteGrupa);
            this.panel1.Controls.Add(this.BEditGrupa);
            this.panel1.Location = new System.Drawing.Point(12, 320);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 160);
            this.panel1.TabIndex = 7;
            // 
            // FEditDovGrupa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 491);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DGVDovGrupa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FEditDovGrupa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редагування довідника груп товарів";
            this.Load += new System.EventHandler(this.FEditDovGrupa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDovGrupa)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVDovGrupa;
        private System.Windows.Forms.TextBox TBNewGrupa;
        private System.Windows.Forms.Button BAddGrupa;
        private System.Windows.Forms.Button BEditGrupa;
        private System.Windows.Forms.Button BDeleteGrupa;
        private System.Windows.Forms.Button BClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}
