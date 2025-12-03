using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab13_Sklad_main_HOI
{
    public partial class Form1 : Form
    {
        private TSklad MySklad;
        public static string GlStringParameter;
        private Dictionary<string, TSklad> Sklady;
        private string CurrentSkladName = "Головний склад";
        private PrintDocument printDocument;
        private DataGridView printGrid;

        public Form1()
        {
            InitializeComponent();
            Sklady = new Dictionary<string, TSklad>();
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Створюємо кілька складів
            CreateSklady();

            // Завантажуємо головний склад
            MySklad = Sklady[CurrentSkladName];
            DGSklad.DataSource = MySklad.SkladView;

            // Додаємо ComboBox стовпці до DataGridView
            MySklad.AddComboGrupa(DGSklad);
            MySklad.AddComboPostachalnyk(DGSklad);
            MySklad.AddComboOdVym(DGSklad);

            // Заповнюємо ComboBox-и на панелі введення
            RefreshAllComboBoxes();

            // Ініціалізуємо TreeView
            InitializeTreeView();
        }

        private void CreateSklady()
        {
            // Масив назв майбутніх складів
            string[] skladNames = { "Головний склад", "Склад № 2", "Склад № 3" };

            foreach (string name in skladNames)
            {
                TSklad sklad = new TSklad();
                sklad.SkladName = name;
                sklad.CreateDovGrupa();
                sklad.CreateDovPostachalnyk();
                sklad.CreateDovOdVym();
                Sklady[name] = sklad;
            }
        }

        private void InitializeTreeView()
        {
            treeViewSklady.Nodes.Clear();

            foreach (var skladPair in Sklady)
            {
                TreeNode skladNode = new TreeNode(skladPair.Key);
                skladNode.Tag = skladPair.Key;

                foreach (DataRow row in skladPair.Value.DovGrupa.Rows)
                {
                    TreeNode groupNode = new TreeNode(row["Група"].ToString());
                    groupNode.Tag = row["Група"].ToString();
                    skladNode.Nodes.Add(groupNode);
                }

                treeViewSklady.Nodes.Add(skladNode);
            }

            treeViewSklady.ExpandAll();
        }

        private void TreeViewSklady_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                string skladName = e.Node.Tag.ToString();
                if (Sklady.ContainsKey(skladName))
                {
                    CurrentSkladName = skladName;
                    MySklad = Sklady[skladName];
                    MySklad.TSkladValFiltr("", DGSklad);
                    RefreshAllComboBoxes();
                    MySklad.SetSumy(DGSkladSum);
                    this.Text = "Склад - " + skladName;
                }
            }
            else
            {
                // Вибрано групу - спочатку переключаємось на склад
                string skladName = e.Node.Parent.Tag.ToString();
                string groupName = e.Node.Tag.ToString();
                
                // Переключаємось на потрібний склад, якщо він не поточний
                if (CurrentSkladName != skladName && Sklady.ContainsKey(skladName))
                {
                    CurrentSkladName = skladName;
                    MySklad = Sklady[skladName];
                    RefreshAllComboBoxes();
                    this.Text = "Склад - " + skladName;
                }
                
                // Застосовуємо фільтр по групі
                string filterCriteria = $"Група = '{groupName}'";
                MySklad.TSkladValFiltr(filterCriteria, DGSklad);
                MySklad.SetSumy(DGSkladSum);
            }
        }

        private void RefreshAllComboBoxes()
        {
            CBGrupa.Items.Clear();
            foreach (DataRow r in MySklad.DovGrupa.Rows)
            {
                CBGrupa.Items.Add(r["Група"]);
            }

            CBPostachalnyk.Items.Clear();
            foreach (DataRow r in MySklad.DovPostachalnyk.Rows)
            {
                CBPostachalnyk.Items.Add(r["Постачальник"]);
            }

            CBOdVym.Items.Clear();
            foreach (DataRow r in MySklad.DovOdVym.Rows)
            {
                CBOdVym.Items.Add(r["Од_виміру"]);
            }
        }

        private void BAddRowToTable_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CBGrupa.Text) ||
                string.IsNullOrWhiteSpace(TBNazva.Text) ||
                string.IsNullOrWhiteSpace(TBVyrobnyk.Text) ||
                string.IsNullOrWhiteSpace(CBPostachalnyk.Text) ||
                string.IsNullOrWhiteSpace(CBOdVym.Text) ||
                string.IsNullOrWhiteSpace(TBKilkist.Text) ||
                string.IsNullOrWhiteSpace(TBCina.Text))
            {
                MessageBox.Show("Заповніть всі обов'язкові поля!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal pKilkist;
            decimal pPcina;
            try
            {
                pKilkist = Convert.ToDecimal(TBKilkist.Text);
                pPcina = Convert.ToDecimal(TBCina.Text);
            }
            catch
            {
                MessageBox.Show("Введіть коректні числові значення для кількості та ціни");
                return;
            }

            MySklad.TSkladAddRow(CBGrupa.Text, TBNazva.Text, TBVyrobnyk.Text,
                                CBPostachalnyk.Text, CBOdVym.Text, pKilkist, pPcina);
            MySklad.SetSumy(DGSkladSum);

            TBNazva.Clear();
            TBVyrobnyk.Clear();
            TBKilkist.Clear();
            TBCina.Clear();
        }

        private void DGSklad_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i, j;
            decimal vart, kilk, cin;
            i = e.RowIndex;
            j = e.ColumnIndex;
            if (i < 0) return;
            if (j < 0) return;
            if ((DGSklad.Columns[j].Name == "Кількість") || (DGSklad.Columns[j].Name == "Ціна"))
            {
                try
                {
                    cin = (decimal)DGSklad.Rows[i].Cells["Ціна"].Value;
                    kilk = Convert.ToDecimal(DGSklad.Rows[i].Cells["Кількість"].Value);
                    vart = kilk * cin;
                    DGSklad.Rows[i].Cells["Вартість"].Value = vart;
                }
                catch { }
            }
            MySklad.SetSumy(DGSkladSum);
        }

        private void DGSklad_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal cin;
            decimal kilk;
            if (DGSklad.Columns[e.ColumnIndex].Name == "Ціна")
            {
                if (DGSklad.Rows[e.RowIndex].IsNewRow)
                {
                    return;
                }
                if (!decimal.TryParse(e.FormattedValue.ToString(), out cin))
                {
                    MessageBox.Show("Введіть, будь ласка, числове значення у поле ціни.");
                    e.Cancel = true;
                }
            }
            if (DGSklad.Columns[e.ColumnIndex].Name == "Кількість")
            {
                if (DGSklad.Rows[e.RowIndex].IsNewRow) { return; }
                if (!decimal.TryParse(e.FormattedValue.ToString(), out kilk))
                {
                    MessageBox.Show("Введіть, будь ласка, числове значення у поле кількості.");
                    e.Cancel = true;
                }
            }
        }

        private void SaveTableMenuItem_Click(object sender, EventArgs e)
        {
            MySklad.ZapTabFile();
            MessageBox.Show("Таблиця записана");
        }

        private void LoadTableMenuItem_Click(object sender, EventArgs e)
        {
            MySklad.ReadTabFile(DGSkladSum);
        }

        private void SetFilterMenuItem_Click(object sender, EventArgs e)
        {
            Form FiltrDialog = new FServ();
            FiltrDialog.Text = "Введіть критерій фільтруванна - наприклад: Група = 'Книги' & Ціна < 70";
            GlStringParameter = MySklad.FiltrCriteria;
            FiltrDialog.ShowDialog();
            MySklad.TSkladValFiltr(GlStringParameter, DGSklad);
        }

        private void ClearFilterMenuItem_Click(object sender, EventArgs e)
        {
            GlStringParameter = "";
            MySklad.TSkladValFiltr(GlStringParameter, DGSklad);
        }

        private void SetSortCriteriaMenuItem_Click(object sender, EventArgs e)
        {
            Form SortDialog = new FServ();
            SortDialog.Text = "Введіть критерій сортування - наприклад: Виробник, Ціна Desc";
            GlStringParameter = MySklad.SortCriteria;
            SortDialog.ShowDialog();
            MySklad.TSkladValSort(GlStringParameter, DGSklad, DGSkladSum);
        }

        private void SortByGroupMenuItem_Click(object sender, EventArgs e)
        {
            GlStringParameter = "Група, Назва";
            MySklad.TSkladValSort(GlStringParameter, DGSklad, DGSkladSum);
        }

        private void SearchByNameMenuItem_Click(object sender, EventArgs e)
        {
            Form SeekDialog = new FServ();
            SeekDialog.Text = "Введіть назву:";
            SeekDialog.ShowDialog();
            MySklad.SeekNazva(GlStringParameter, DGSklad);
        }

        private void EditGroupsMenuItem_Click(object sender, EventArgs e)
        {
            MySklad.SaveDovGrupaToFile();
            
            FEditDovGrupa editForm = new FEditDovGrupa(MySklad.DovGrupa);
            editForm.ShowDialog();
            
            MySklad.SaveDovGrupaToFile();
            
            RefreshAllComboBoxes();
            MySklad.RefreshDataGridViewGrupa(DGSklad);
            InitializeTreeView();
            MySklad.SetSumy(DGSkladSum);
            
            MessageBox.Show("Довідник груп оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditPostachalnykyMenuItem_Click(object sender, EventArgs e)
        {
            MySklad.SaveDovPostachalnykToFile();
            
            FEditDovPostachalnyk editForm = new FEditDovPostachalnyk(MySklad.DovPostachalnyk);
            editForm.ShowDialog();
            
            MySklad.SaveDovPostachalnykToFile();
            
            RefreshAllComboBoxes();
            
            MessageBox.Show("Довідник постачальників оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditOdVymMenuItem_Click(object sender, EventArgs e)
        {
            MySklad.SaveDovOdVymToFile();
            
            FEditDovOdVym editForm = new FEditDovOdVym(MySklad.DovOdVym);
            editForm.ShowDialog();
            
            MySklad.SaveDovOdVymToFile();
            
            RefreshAllComboBoxes();
            
            MessageBox.Show("Довідник одиниць виміру оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PrintMenuItem_Click(object sender, EventArgs e)
        {
            printGrid = DGSklad;
            
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDocument;
            previewDialog.ShowDialog();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Заголовок документу
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            Font cellFont = new Font("Arial", 9);

            string title = $"Звіт по складу: {CurrentSkladName}";
            SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
            float x = (e.PageBounds.Width - titleSize.Width) / 2;
            e.Graphics.DrawString(title, titleFont, Brushes.Black, x, 50);

            string date = $"Дата: {DateTime.Now.ToString("dd.MM.yyyy HH:mm")}";
            e.Graphics.DrawString(date, cellFont, Brushes.Black, 100, 100);

            // Малюємо таблицю
            float yPos = 150;
            float leftMargin = 50;
            float cellHeight = 25;
            float cellWidth = 100;

            // Заголовки стовпців
            float xPos = leftMargin;
            for (int i = 0; i < printGrid.Columns.Count; i++)
            {
                if (printGrid.Columns[i].Visible)
                {
                    e.Graphics.DrawString(printGrid.Columns[i].HeaderText, headerFont, Brushes.Black, xPos, yPos);
                    xPos += cellWidth;
                }
            }

            yPos += cellHeight;

            // Дані
            int maxRows = (int)((e.PageBounds.Height - 200) / cellHeight);
            int rowCount = Math.Min(printGrid.Rows.Count, maxRows);

            for (int i = 0; i < rowCount; i++)
            {
                if (!printGrid.Rows[i].IsNewRow)
                {
                    xPos = leftMargin;
                    for (int j = 0; j < printGrid.Columns.Count; j++)
                    {
                        if (printGrid.Columns[j].Visible)
                        {
                            string cellValue = printGrid.Rows[i].Cells[j].Value?.ToString() ?? "";
                            e.Graphics.DrawString(cellValue, cellFont, Brushes.Black, xPos, yPos);
                            xPos += cellWidth;
                        }
                    }
                    yPos += cellHeight;
                }
            }
        }

        private void StatByGroupMenuItem_Click(object sender, EventArgs e)
        {
            MySklad.SetSumy(DGSkladSum);
            
            Form statForm = new Form();
            statForm.Text = "Статистика по групам";
            statForm.Size = new Size(600, 400);
            
            DataGridView dgvStat = new DataGridView();
            dgvStat.Dock = DockStyle.Fill;
            dgvStat.DataSource = ((DataTable)DGSkladSum.DataSource).Copy();
            dgvStat.ReadOnly = true;
            
            statForm.Controls.Add(dgvStat);
            statForm.ShowDialog();
        }

        private void StatBySupplierMenuItem_Click(object sender, EventArgs e)
        {
            DataTable statTable = new DataTable();
            statTable.Columns.Add("Постачальник", typeof(string));
            statTable.Columns.Add("Кількість товарів", typeof(int));
            statTable.Columns.Add("Загальна вартість", typeof(decimal));

            Dictionary<string, StatData> stats = new Dictionary<string, StatData>();

            foreach (DataRowView rowView in MySklad.SkladView)
            {
                if (rowView["Постачальник"] == null || rowView["Постачальник"] == DBNull.Value)
                    continue;
                
                if (rowView["Вартість"] == null || rowView["Вартість"] == DBNull.Value)
                    continue;

                string supplier = rowView["Постачальник"].ToString();
                decimal value = Convert.ToDecimal(rowView["Вартість"]);

                if (!stats.ContainsKey(supplier))
                {
                    stats[supplier] = new StatData();
                }
                stats[supplier].Count++;
                stats[supplier].TotalValue += value;
            }

            foreach (var kvp in stats)
            {
                DataRow row = statTable.NewRow();
                row["Постачальник"] = kvp.Key;
                row["Кількість товарів"] = kvp.Value.Count;
                row["Загальна вартість"] = kvp.Value.TotalValue;
                statTable.Rows.Add(row);
            }

            Form statForm = new Form();
            statForm.Text = "Статистика по постачальникам";
            statForm.Size = new Size(700, 400);
            
            DataGridView dgvStat = new DataGridView();
            dgvStat.Dock = DockStyle.Fill;
            dgvStat.ReadOnly = true;
            
            statForm.Controls.Add(dgvStat);  
            dgvStat.DataSource = statTable;
            dgvStat.Columns["Загальна вартість"].DefaultCellStyle.Format = "F2";
            
            statForm.Controls.Add(dgvStat);
            statForm.ShowDialog();
        }

        private void StatTotalMenuItem_Click(object sender, EventArgs e)
        {
            int totalCount = 0;
            decimal totalValue = 0;
            decimal totalQuantity = 0;
            Dictionary<string, int> groupCount = new Dictionary<string, int>();

            foreach (DataRowView rowView in MySklad.SkladView)
            {
                if (rowView["Група"] == null || rowView["Група"] == DBNull.Value)
                    continue;
                
                totalCount++;

                if (rowView["Вартість"] != null && rowView["Вартість"] != DBNull.Value)
                {
                    totalValue += Convert.ToDecimal(rowView["Вартість"]);
                }
                
                if (rowView["Кількість"] != null && rowView["Кількість"] != DBNull.Value)
                {
                    totalQuantity += Convert.ToDecimal(rowView["Кількість"]);
                }

                string group = rowView["Група"].ToString();
                if (!groupCount.ContainsKey(group))
                    groupCount[group] = 0;
                groupCount[group]++;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== ЗАГАЛЬНА СТАТИСТИКА ===");
            sb.AppendLine();
            sb.AppendLine($"Склад: {CurrentSkladName}");
            sb.AppendLine($"Дата формування: {DateTime.Now.ToString("dd.MM.yyyy HH:mm")}");
            sb.AppendLine();
            sb.AppendLine($"Всього найменувань товарів: {totalCount}");
            sb.AppendLine($"Загальна кількість одиниць: {totalQuantity:F2}");
            sb.AppendLine($"Загальна вартість: {totalValue:F2} грн");
            sb.AppendLine();
            sb.AppendLine("Розподіл по групам:");
            foreach (var kvp in groupCount)
            {
                sb.AppendLine($"  {kvp.Key}: {kvp.Value} найменувань");
            }

            MessageBox.Show(sb.ToString(), "Загальна статистика", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private class StatData
        {
            public int Count { get; set; }
            public decimal TotalValue { get; set; }
        }
    }
}
