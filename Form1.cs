using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab13_Sklad_main_HOI
{
    public partial class Form1 : Form
    {
        private TSklad MySklad;
        public static string GlStringParameter;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySklad = new TSklad();
            DGSklad.DataSource = MySklad.SkladView;

            MySklad.CreateDovGrupa();
            MySklad.AddComboGrupa(DGSklad);

            foreach (DataRow r in MySklad.DovGrupa.Rows)
            {
                string s = (string)r["Група"];
                CBGrupa.Items.Add(r["Група"]);
            }
        }

        private void BAddRowToTable_Click(object sender, EventArgs e)
        {
            int pKilkist;
            decimal pPcina;
            try
            {
                pKilkist = Convert.ToInt32(TBKilkist.Text);
                pPcina = Convert.ToDecimal(TBCina.Text);
            }
            catch
            {
                MessageBox.Show("Введіть коректні числові значення для кількості та ціни");
                return;
            }

            MySklad.TSkladAddRow(CBGrupa.Text, TBNazva.Text, TBVyrobnyk.Text, pKilkist, pPcina);
            MySklad.SetSumy(DGSkladSum);
        }

        private void DGSklad_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i, j;
            decimal vart, kilk, cin;
            i = e.RowIndex;
            j = e.ColumnIndex;
            if (i < 0) return;
            if (j < 0) return;
            if ((DGSklad.Columns[j].Name == "Кількість") ^ (DGSklad.Columns[j].Name == "Ціна"))
            {
                try
                {
                    cin = (decimal)DGSklad.Rows[i].Cells["Ціна"].Value;
                    kilk = Convert.ToDecimal((Int32)DGSklad.Rows[i].Cells["Кількість"].Value);
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
            Int32 kilk;
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
                if (!Int32.TryParse(e.FormattedValue.ToString(), out kilk))
                {
                    MessageBox.Show("Введіть, будь ласка, цілочислове значення у поле кількості.");
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
            string sNazva;
            Form SeekDialog = new FServ();
            SeekDialog.Text = "Введіть назву:";
            SeekDialog.ShowDialog();
            MySklad.SeekNazva(GlStringParameter, DGSklad);
        }
    }
}
