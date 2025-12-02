using System;
using System.Data;
using System.Windows.Forms;

namespace Lab13_Sklad_main_HOI
{
    public partial class FEditDovGrupa : Form
    {
        private DataTable DovGrupa;

        public FEditDovGrupa(DataTable dovGrupa)
        {
            InitializeComponent();
            DovGrupa = dovGrupa;
        }

        private void FEditDovGrupa_Load(object sender, EventArgs e)
        {
            DGVDovGrupa.DataSource = DovGrupa;
            DGVDovGrupa.Columns["Група"].HeaderText = "Назва групи";
            DGVDovGrupa.Columns["Група"].Width = 200;
        }

        private void BAddGrupa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBNewGrupa.Text))
            {
                MessageBox.Show("Введіть назву нової групи!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Перевірка на унікальність
            foreach (DataRow row in DovGrupa.Rows)
            {
                if (row["Група"].ToString() == TBNewGrupa.Text.Trim())
                {
                    MessageBox.Show("Така група вже існує!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DataRow newRow = DovGrupa.NewRow();
            newRow["Група"] = TBNewGrupa.Text.Trim();
            DovGrupa.Rows.Add(newRow);
            TBNewGrupa.Clear();
            MessageBox.Show("Група успішно додана!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BDeleteGrupa_Click(object sender, EventArgs e)
        {
            if (DGVDovGrupa.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть групу для видалення!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DovGrupa.Rows.Count <= 1)
            {
                MessageBox.Show("Неможливо видалити останню групу!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Ви впевнені, що хочете видалити цю групу?", 
                "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int index = DGVDovGrupa.SelectedRows[0].Index;
                DovGrupa.Rows[index].Delete();
                MessageBox.Show("Група успішно видалена!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BEditGrupa_Click(object sender, EventArgs e)
        {
            if (DGVDovGrupa.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть групу для редагування!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TBNewGrupa.Text))
            {
                MessageBox.Show("Введіть нову назву групи!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Перевірка на унікальність (крім поточного рядка)
            int selectedIndex = DGVDovGrupa.SelectedRows[0].Index;
            for (int i = 0; i < DovGrupa.Rows.Count; i++)
            {
                if (i != selectedIndex && DovGrupa.Rows[i]["Група"].ToString() == TBNewGrupa.Text.Trim())
                {
                    MessageBox.Show("Така група вже існує!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DovGrupa.Rows[selectedIndex]["Група"] = TBNewGrupa.Text.Trim();
            TBNewGrupa.Clear();
            MessageBox.Show("Група успішно змінена!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGVDovGrupa_SelectionChanged(object sender, EventArgs e)
        {
            if (DGVDovGrupa.SelectedRows.Count > 0)
            {
                int index = DGVDovGrupa.SelectedRows[0].Index;
                if (index >= 0 && index < DovGrupa.Rows.Count)
                {
                    TBNewGrupa.Text = DovGrupa.Rows[index]["Група"].ToString();
                }
            }
        }
    }
}
