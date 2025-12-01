namespace Lab13_Sklad_main_HOI
{
  partial class Form1
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
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.DGSklad = new System.Windows.Forms.DataGridView();
      this.panel1 = new System.Windows.Forms.Panel();
      this.BAddRowToTable = new System.Windows.Forms.Button();
      this.TBKilkist = new System.Windows.Forms.TextBox();
      this.TBCina = new System.Windows.Forms.TextBox();
      this.TBVyrobnyk = new System.Windows.Forms.TextBox();
      this.TBNazva = new System.Windows.Forms.TextBox();
      this.CBGrupa = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.DGSkladSum = new System.Windows.Forms.DataGridView();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.loadTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.setFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.clearFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.setSortCriteriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sortByGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.searchByNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DGSklad)).BeginInit();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DGSkladSum)).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 48);
      this.splitContainer1.Margin = new System.Windows.Forms.Padding(6);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.DGSklad);
      this.splitContainer1.Panel1.Controls.Add(this.panel1);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.DGSkladSum);
      this.splitContainer1.Size = new System.Drawing.Size(1968, 1031);
      this.splitContainer1.SplitterDistance = 767;
      this.splitContainer1.SplitterWidth = 8;
      this.splitContainer1.TabIndex = 0;
      // 
      // DGSklad
      // 
      this.DGSklad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DGSklad.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DGSklad.Location = new System.Drawing.Point(0, 192);
      this.DGSklad.Margin = new System.Windows.Forms.Padding(6);
      this.DGSklad.Name = "DGSklad";
      this.DGSklad.RowHeadersWidth = 82;
      this.DGSklad.Size = new System.Drawing.Size(1968, 575);
      this.DGSklad.TabIndex = 1;
      this.DGSklad.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGSklad_CellValidating);
      this.DGSklad.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGSklad_CellValueChanged);
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.LightBlue;
      this.panel1.Controls.Add(this.BAddRowToTable);
      this.panel1.Controls.Add(this.TBKilkist);
      this.panel1.Controls.Add(this.TBCina);
      this.panel1.Controls.Add(this.TBVyrobnyk);
      this.panel1.Controls.Add(this.TBNazva);
      this.panel1.Controls.Add(this.CBGrupa);
      this.panel1.Controls.Add(this.label6);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Margin = new System.Windows.Forms.Padding(6);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1968, 192);
      this.panel1.TabIndex = 0;
      // 
      // BAddRowToTable
      // 
      this.BAddRowToTable.Location = new System.Drawing.Point(1400, 87);
      this.BAddRowToTable.Margin = new System.Windows.Forms.Padding(6);
      this.BAddRowToTable.Name = "BAddRowToTable";
      this.BAddRowToTable.Size = new System.Drawing.Size(300, 58);
      this.BAddRowToTable.TabIndex = 11;
      this.BAddRowToTable.Text = "Додати рядок до таблиці Склад";
      this.BAddRowToTable.UseVisualStyleBackColor = true;
      this.BAddRowToTable.Click += new System.EventHandler(this.BAddRowToTable_Click);
      // 
      // TBKilkist
      // 
      this.TBKilkist.Location = new System.Drawing.Point(1200, 107);
      this.TBKilkist.Margin = new System.Windows.Forms.Padding(6);
      this.TBKilkist.Name = "TBKilkist";
      this.TBKilkist.Size = new System.Drawing.Size(156, 31);
      this.TBKilkist.TabIndex = 10;
      // 
      // TBCina
      // 
      this.TBCina.Location = new System.Drawing.Point(1000, 107);
      this.TBCina.Margin = new System.Windows.Forms.Padding(6);
      this.TBCina.Name = "TBCina";
      this.TBCina.Size = new System.Drawing.Size(156, 31);
      this.TBCina.TabIndex = 9;
      // 
      // TBVyrobnyk
      // 
      this.TBVyrobnyk.Location = new System.Drawing.Point(700, 107);
      this.TBVyrobnyk.Margin = new System.Windows.Forms.Padding(6);
      this.TBVyrobnyk.Name = "TBVyrobnyk";
      this.TBVyrobnyk.Size = new System.Drawing.Size(256, 31);
      this.TBVyrobnyk.TabIndex = 8;
      // 
      // TBNazva
      // 
      this.TBNazva.Location = new System.Drawing.Point(360, 107);
      this.TBNazva.Margin = new System.Windows.Forms.Padding(6);
      this.TBNazva.Name = "TBNazva";
      this.TBNazva.Size = new System.Drawing.Size(296, 31);
      this.TBNazva.TabIndex = 7;
      // 
      // CBGrupa
      // 
      this.CBGrupa.FormattingEnabled = true;
      this.CBGrupa.Location = new System.Drawing.Point(40, 107);
      this.CBGrupa.Margin = new System.Windows.Forms.Padding(6);
      this.CBGrupa.Name = "CBGrupa";
      this.CBGrupa.Size = new System.Drawing.Size(276, 33);
      this.CBGrupa.TabIndex = 6;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(1200, 58);
      this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(102, 25);
      this.label6.TabIndex = 5;
      this.label6.Text = "Кількість";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(1000, 58);
      this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(57, 25);
      this.label5.TabIndex = 4;
      this.label5.Text = "Ціна";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(700, 58);
      this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(109, 25);
      this.label4.TabIndex = 3;
      this.label4.Text = "Виробник";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(360, 58);
      this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(73, 25);
      this.label3.TabIndex = 2;
      this.label3.Text = "Назва";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(40, 58);
      this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(71, 25);
      this.label2.TabIndex = 1;
      this.label2.Text = "Група";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(712, 0);
      this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(444, 29);
      this.label1.TabIndex = 0;
      this.label1.Text = "Введіть нові дані у таблицю Склад";
      // 
      // DGSkladSum
      // 
      this.DGSkladSum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DGSkladSum.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DGSkladSum.Location = new System.Drawing.Point(0, 0);
      this.DGSkladSum.Margin = new System.Windows.Forms.Padding(6);
      this.DGSkladSum.Name = "DGSkladSum";
      this.DGSkladSum.RowHeadersWidth = 82;
      this.DGSkladSum.Size = new System.Drawing.Size(1968, 256);
      this.DGSkladSum.TabIndex = 0;
      // 
      // menuStrip1
      // 
      this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.sortToolStripMenuItem,
            this.searchToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1968, 48);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // файлToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveTableToolStripMenuItem,
            this.loadTableToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(90, 36);
      this.fileToolStripMenuItem.Text = "Файл";
      // 
      // записатиТаблицюToolStripMenuItem
      // 
      this.saveTableToolStripMenuItem.Name = "saveTableToolStripMenuItem";
      this.saveTableToolStripMenuItem.Size = new System.Drawing.Size(351, 44);
      this.saveTableToolStripMenuItem.Text = "Записати таблицю";
      this.saveTableToolStripMenuItem.Click += new System.EventHandler(this.SaveTableMenuItem_Click);
      // 
      // зчитатиТаблицюToolStripМеню
      // 
      this.loadTableToolStripMenuItem.Name = "loadTableToolStripMenuItem";
      this.loadTableToolStripMenuItem.Size = new System.Drawing.Size(351, 44);
      this.loadTableToolStripMenuItem.Text = "Зчитати таблицю";
      this.loadTableToolStripMenuItem.Click += new System.EventHandler(this.LoadTableMenuItem_Click);
      // 
      // фільтруватиToolStripМеню
      // 
      this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setFilterToolStripMenuItem,
            this.clearFilterToolStripMenuItem});
      this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
      this.filterToolStripMenuItem.Size = new System.Drawing.Size(167, 36);
      this.filterToolStripMenuItem.Text = "Фільтрувати";
      // 
      // встановитиФільтрToolStripМеню
      // 
      this.setFilterToolStripMenuItem.Name = "setFilterToolStripMenuItem";
      this.setFilterToolStripMenuItem.Size = new System.Drawing.Size(351, 44);
      this.setFilterToolStripMenuItem.Text = "Встановити фільтр";
      this.setFilterToolStripMenuItem.Click += new System.EventHandler(this.SetFilterMenuItem_Click);
      // 
      // знятиФільтрToolStripМеню
      // 
      this.clearFilterToolStripMenuItem.Name = "clearFilterToolStripMenuItem";
      this.clearFilterToolStripMenuItem.Size = new System.Drawing.Size(351, 44);
      this.clearFilterToolStripMenuItem.Text = "Зняти фільтр";
      this.clearFilterToolStripMenuItem.Click += new System.EventHandler(this.ClearFilterMenuItem_Click);
      // 
      // сортуватиToolStripМеню
      // 
      this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setSortCriteriaToolStripMenuItem,
            this.sortByGroupToolStripMenuItem});
      this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
      this.sortToolStripMenuItem.Size = new System.Drawing.Size(148, 36);
      this.sortToolStripMenuItem.Text = "Сортувати";
      // 
      // встановитиКритерійСортуванняToolStripМеню
      // 
      this.setSortCriteriaToolStripMenuItem.Name = "setSortCriteriaToolStripMenuItem";
      this.setSortCriteriaToolStripMenuItem.Size = new System.Drawing.Size(510, 44);
      this.setSortCriteriaToolStripMenuItem.Text = "Встановити критерій сортування";
      this.setSortCriteriaToolStripMenuItem.Click += new System.EventHandler(this.SetSortCriteriaMenuItem_Click);
      // 
      // сортуватиПоГрупіToolStripМеню
      // 
      this.sortByGroupToolStripMenuItem.Name = "sortByGroupToolStripMenuItem";
      this.sortByGroupToolStripMenuItem.Size = new System.Drawing.Size(510, 44);
      this.sortByGroupToolStripMenuItem.Text = "Сортувати по групі";
      this.sortByGroupToolStripMenuItem.Click += new System.EventHandler(this.SortByGroupMenuItem_Click);
      // 
      // пошукToolStripМеню
      // 
      this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchByNameToolStripMenuItem});
      this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
      this.searchToolStripMenuItem.Size = new System.Drawing.Size(108, 36);
      this.searchToolStripMenuItem.Text = "Пошук";
      // 
      // пошукПоНазвіToolStripМеню
      // 
      this.searchByNameToolStripMenuItem.Name = "searchByNameToolStripMenuItem";
      this.searchByNameToolStripMenuItem.Size = new System.Drawing.Size(319, 44);
      this.searchByNameToolStripMenuItem.Text = "Пошук по назві";
      this.searchByNameToolStripMenuItem.Click += new System.EventHandler(this.SearchByNameMenuItem_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1968, 1079);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Margin = new System.Windows.Forms.Padding(6);
      this.Name = "Form1";
      this.Text = "Склад";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.DGSklad)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DGSkladSum)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.DataGridView DGSklad;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.DataGridView DGSkladSum;
    private System.Windows.Forms.Button BAddRowToTable;
    private System.Windows.Forms.TextBox TBKilkist;
    private System.Windows.Forms.TextBox TBCina;
    private System.Windows.Forms.TextBox TBVyrobnyk;
    private System.Windows.Forms.TextBox TBNazva;
    private System.Windows.Forms.ComboBox CBGrupa;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveTableToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem loadTableToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem setFilterToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem clearFilterToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem setSortCriteriaToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem sortByGroupToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem searchByNameToolStripMenuItem;
  }
}

