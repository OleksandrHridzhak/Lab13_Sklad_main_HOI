using System;
using System.Data;
using System.Windows.Forms;

namespace Lab13_Sklad_main_HOI
{
    public partial class FEditDovPostachalnyk : Form
    {
        private DataTable DovPostachalnyk;

        public FEditDovPostachalnyk(DataTable dovPostachalnyk)
        {
            InitializeComponent();
            DovPostachalnyk = dovPostachalnyk;
        }

        private void FEditDovPostachalnyk_Load(object sender, EventArgs e)
        {
            DGVDovPostachalnyk.DataSource = DovPostachalnyk;
            DGVDovPostachalnyk.Columns["Постачальник"].HeaderText = "Назва постачальника";
            DGVDovPostachalnyk.Columns["Постачальник"].Width = 300;
        }

        private void BAddPostachalnyk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBNewPostachalnyk.Text))
            {
                MessageBox.Show("Введіть назву постачальника!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataRow row in DovPostachalnyk.Rows)
            {
                if (row["Постачальник"].ToString() == TBNewPostachalnyk.Text.Trim())
                {
                    MessageBox.Show("Такий постачальник вже існує!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DataRow newRow = DovPostachalnyk.NewRow();
            newRow["Постачальник"] = TBNewPostachalnyk.Text.Trim();
            DovPostachalnyk.Rows.Add(newRow);
            TBNewPostachalnyk.Clear();
            MessageBox.Show("Постачальник успішно додан!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BDeletePostachalnyk_Click(object sender, EventArgs e)
        {
            if (DGVDovPostachalnyk.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть постачальника для видалення!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DovPostachalnyk.Rows.Count <= 1)
            {
                MessageBox.Show("Неможливо видалити останнього постачальника!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Ви впевнені, що хочете видалити цього постачальника?", 
                "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int index = DGVDovPostachalnyk.SelectedRows[0].Index;
                DovPostachalnyk.Rows[index].Delete();
                MessageBox.Show("Постачальник успішно видалений!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BEditPostachalnyk_Click(object sender, EventArgs e)
        {
            if (DGVDovPostachalnyk.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть постачальника для редагування!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TBNewPostachalnyk.Text))
            {
                MessageBox.Show("Введіть нову назву постачальника!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = DGVDovPostachalnyk.SelectedRows[0].Index;
            for (int i = 0; i < DovPostachalnyk.Rows.Count; i++)
            {
                if (i != selectedIndex && DovPostachalnyk.Rows[i]["Постачальник"].ToString() == TBNewPostachalnyk.Text.Trim())
                {
                    MessageBox.Show("Такий постачальник вже існує!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DovPostachalnyk.Rows[selectedIndex]["Постачальник"] = TBNewPostachalnyk.Text.Trim();
            TBNewPostachalnyk.Clear();
            MessageBox.Show("Постачальник успішно змінений!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGVDovPostachalnyk_SelectionChanged(object sender, EventArgs e)
        {
            if (DGVDovPostachalnyk.SelectedRows.Count > 0)
            {
                int index = DGVDovPostachalnyk.SelectedRows[0].Index;
                if (index >= 0 && index < DovPostachalnyk.Rows.Count)
                {
                    TBNewPostachalnyk.Text = DovPostachalnyk.Rows[index]["Постачальник"].ToString();
                }
            }
        }
    }
}
