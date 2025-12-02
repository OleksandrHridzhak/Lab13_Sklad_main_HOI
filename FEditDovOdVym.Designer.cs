namespace Lab13_Sklad_main_HOI
{
    partial class FEditDovOdVym
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
            this.DGVDovOdVym = new System.Windows.Forms.DataGridView();
            this.TBNewOdVym = new System.Windows.Forms.TextBox();
            this.BAddOdVym = new System.Windows.Forms.Button();
            this.BEditOdVym = new System.Windows.Forms.Button();
            this.BDeleteOdVym = new System.Windows.Forms.Button();
            this.BClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDovOdVym)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVDovOdVym
            // 
            this.DGVDovOdVym.AllowUserToAddRows = false;
            this.DGVDovOdVym.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDovOdVym.Location = new System.Drawing.Point(12, 12);
            this.DGVDovOdVym.MultiSelect = false;
            this.DGVDovOdVym.Name = "DGVDovOdVym";
            this.DGVDovOdVym.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVDovOdVym.Size = new System.Drawing.Size(400, 300);
            this.DGVDovOdVym.TabIndex = 0;
            this.DGVDovOdVym.SelectionChanged += new System.EventHandler(this.DGVDovOdVym_SelectionChanged);
            // 
            // TBNewOdVym
            // 
            this.TBNewOdVym.Location = new System.Drawing.Point(15, 35);
            this.TBNewOdVym.Name = "TBNewOdVym";
            this.TBNewOdVym.Size = new System.Drawing.Size(350, 20);
            this.TBNewOdVym.TabIndex = 1;
            // 
            // BAddOdVym
            // 
            this.BAddOdVym.Location = new System.Drawing.Point(15, 70);
            this.BAddOdVym.Name = "BAddOdVym";
            this.BAddOdVym.Size = new System.Drawing.Size(110, 30);
            this.BAddOdVym.TabIndex = 2;
            this.BAddOdVym.Text = "Додати";
            this.BAddOdVym.UseVisualStyleBackColor = true;
            this.BAddOdVym.Click += new System.EventHandler(this.BAddOdVym_Click);
            // 
            // BEditOdVym
            // 
            this.BEditOdVym.Location = new System.Drawing.Point(135, 70);
            this.BEditOdVym.Name = "BEditOdVym";
            this.BEditOdVym.Size = new System.Drawing.Size(110, 30);
            this.BEditOdVym.TabIndex = 3;
            this.BEditOdVym.Text = "Змінити";
            this.BEditOdVym.UseVisualStyleBackColor = true;
            this.BEditOdVym.Click += new System.EventHandler(this.BEditOdVym_Click);
            // 
            // BDeleteOdVym
            // 
            this.BDeleteOdVym.Location = new System.Drawing.Point(255, 70);
            this.BDeleteOdVym.Name = "BDeleteOdVym";
            this.BDeleteOdVym.Size = new System.Drawing.Size(110, 30);
            this.BDeleteOdVym.TabIndex = 4;
            this.BDeleteOdVym.Text = "Видалити";
            this.BDeleteOdVym.UseVisualStyleBackColor = true;
            this.BDeleteOdVym.Click += new System.EventHandler(this.BDeleteOdVym_Click);
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
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Одиниця виміру:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TBNewOdVym);
            this.panel1.Controls.Add(this.BClose);
            this.panel1.Controls.Add(this.BAddOdVym);
            this.panel1.Controls.Add(this.BDeleteOdVym);
            this.panel1.Controls.Add(this.BEditOdVym);
            this.panel1.Location = new System.Drawing.Point(12, 320);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 160);
            this.panel1.TabIndex = 7;
            // 
            // FEditDovOdVym
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 491);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DGVDovOdVym);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FEditDovOdVym";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редагування довідника одиниць виміру";
            this.Load += new System.EventHandler(this.FEditDovOdVym_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDovOdVym)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVDovOdVym;
        private System.Windows.Forms.TextBox TBNewOdVym;
        private System.Windows.Forms.Button BAddOdVym;
        private System.Windows.Forms.Button BEditOdVym;
        private System.Windows.Forms.Button BDeleteOdVym;
        private System.Windows.Forms.Button BClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}
