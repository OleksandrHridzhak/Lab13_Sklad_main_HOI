using System;
using System.Data;
using System.Windows.Forms;

namespace Lab13_Sklad_main_HOI
{
    public partial class FEditDovOdVym : Form
    {
        private DataTable DovOdVym;

        public FEditDovOdVym(DataTable dovOdVym)
        {
            InitializeComponent();
            DovOdVym = dovOdVym;
        }

        private void FEditDovOdVym_Load(object sender, EventArgs e)
        {
            DGVDovOdVym.DataSource = DovOdVym;
            DGVDovOdVym.Columns["Од_виміру"].HeaderText = "Одиниця виміру";
            DGVDovOdVym.Columns["Од_виміру"].Width = 200;
        }

        private void BAddOdVym_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBNewOdVym.Text))
            {
                MessageBox.Show("Введіть одиницю виміру!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataRow row in DovOdVym.Rows)
            {
                if (row["Од_виміру"].ToString() == TBNewOdVym.Text.Trim())
                {
                    MessageBox.Show("Така одиниця виміру вже існує!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DataRow newRow = DovOdVym.NewRow();
            newRow["Од_виміру"] = TBNewOdVym.Text.Trim();
            DovOdVym.Rows.Add(newRow);
            TBNewOdVym.Clear();
            MessageBox.Show("Одиниця виміру успішно додана!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BDeleteOdVym_Click(object sender, EventArgs e)
        {
            if (DGVDovOdVym.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть одиницю виміру для видалення!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DovOdVym.Rows.Count <= 1)
            {
                MessageBox.Show("Неможливо видалити останню одиницю виміру!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Ви впевнені, що хочете видалити цю одиницю виміру?", 
                "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int index = DGVDovOdVym.SelectedRows[0].Index;
                DovOdVym.Rows[index].Delete();
                MessageBox.Show("Одиниця виміру успішно видалена!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BEditOdVym_Click(object sender, EventArgs e)
        {
            if (DGVDovOdVym.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть одиницю виміру для редагування!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TBNewOdVym.Text))
            {
                MessageBox.Show("Введіть нову одиницю виміру!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = DGVDovOdVym.SelectedRows[0].Index;
            for (int i = 0; i < DovOdVym.Rows.Count; i++)
            {
                if (i != selectedIndex && DovOdVym.Rows[i]["Од_виміру"].ToString() == TBNewOdVym.Text.Trim())
                {
                    MessageBox.Show("Така одиниця виміру вже існує!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DovOdVym.Rows[selectedIndex]["Од_виміру"] = TBNewOdVym.Text.Trim();
            TBNewOdVym.Clear();
            MessageBox.Show("Одиниця виміру успішно змінена!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGVDovOdVym_SelectionChanged(object sender, EventArgs e)
        {
            if (DGVDovOdVym.SelectedRows.Count > 0)
            {
                int index = DGVDovOdVym.SelectedRows[0].Index;
                if (index >= 0 && index < DovOdVym.Rows.Count)
                {
                    TBNewOdVym.Text = DovOdVym.Rows[index]["Од_виміру"].ToString();
                }
            }
        }
    }
}
