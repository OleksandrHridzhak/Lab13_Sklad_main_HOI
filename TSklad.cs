using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Lab13_Sklad_main_HOI
{
    public class TSklad
    {
        // Основна таблиця складу та її представлення
        public DataTable TabSklad = new DataTable();
        public DataView SkladView;

        public string FiltrCriteria;
        public string SortCriteria;
        //TODO
        public DataGridViewComboBoxColumn cGrupaCB;

        // Обєкти таблиць довідників, які зберігаються в оперативці
        public DataTable DovGrupa = new DataTable();
        public DataTable DovPostachalnyk = new DataTable();
        public DataTable DovOdVym = new DataTable();
        
        public string SkladName; 

        public TSklad()
        {   

            // Обєкти колонок які потім засунемо в TableData TabSklad
            DataColumn cNpp = new DataColumn("N_пп");
            DataColumn cNameGroup = new DataColumn("Група");
            DataColumn cNameProduct = new DataColumn("Назва");
            DataColumn cProduser = new DataColumn("Виробник");
            DataColumn cPostachalnyk = new DataColumn("Постачальник");
            DataColumn cOdVym = new DataColumn("Од_виміру");
            DataColumn cCount = new DataColumn("Кількість");
            DataColumn cPrise = new DataColumn("Ціна");
            DataColumn cVartist = new DataColumn("Вартість");
            

            // Визначаємо типи даних для колонок
            cNpp.DataType = System.Type.GetType("System.Int32");
            cNameGroup.DataType = System.Type.GetType("System.String");
            cNameProduct.DataType = System.Type.GetType("System.String");
            cProduser.DataType = System.Type.GetType("System.String");
            cPostachalnyk.DataType = System.Type.GetType("System.String");
            cOdVym.DataType = System.Type.GetType("System.String");
            cCount.DataType = System.Type.GetType("System.Decimal");
            cPrise.DataType = System.Type.GetType("System.Decimal");
            cVartist.DataType = System.Type.GetType("System.Decimal");
            
            // Додаємо колонки в таблицю TabSklad
            TabSklad.Columns.Add(cNpp);
            TabSklad.Columns.Add(cNameGroup);
            TabSklad.Columns.Add(cNameProduct);
            TabSklad.Columns.Add(cProduser);
            TabSklad.Columns.Add(cPostachalnyk);
            TabSklad.Columns.Add(cOdVym);
            TabSklad.Columns.Add(cCount);
            TabSklad.Columns.Add(cPrise);
            TabSklad.Columns.Add(cVartist);

            SkladView = new DataView(TabSklad);
            SkladName = "DefaultSklad"; // Значення за замовчуванням
        }

        // Метод для створення безпечного імені файлу зі назви складу
        private string GetSafeFileName()
        {
            string safeName = SkladName;
            // Замінюємо небезпечні символи для імені файлу
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                safeName = safeName.Replace(c, '_');
            }
            // Замінюємо пробіли на підкреслення
            safeName = safeName.Replace(' ', '_');
            return safeName;
        }

        public void TSkladAddRow(string pNameGroup, string pNameProduct, string pProduser, string pPostachalnyk, string pOdVym, decimal pCount, decimal pPrise)
        {
            DataRow rowSklad = TabSklad.NewRow();
            int npp = TabSklad.Rows.Count + 1;
            rowSklad["N_пп"] = npp;
            rowSklad["Група"] = pNameGroup;
            rowSklad["Назва"] = pNameProduct;
            rowSklad["Виробник"] = pProduser;
            rowSklad["Постачальник"] = pPostachalnyk;
            rowSklad["Од_виміру"] = pOdVym;
            rowSklad["Кількість"] = pCount;
            rowSklad["Ціна"] = pPrise;
            rowSklad["Вартість"] = pCount * pPrise;
            TabSklad.Rows.Add(rowSklad);
        }

        public void ColumnPropSet(DataGridView DGV)
        {
            DGV.Columns["N_пп"].HeaderText = "№ п/п";
            DGV.Columns["Група"].HeaderText = "Група";
            DGV.Columns["Назва"].HeaderText = "Назва";
            DGV.Columns["Виробник"].HeaderText = "Виробник";
            DGV.Columns["Постачальник"].HeaderText = "Постачальник";
            DGV.Columns["Од_виміру"].HeaderText = "Од. виміру";
            DGV.Columns["Кількість"].HeaderText = "Кількість";
            DGV.Columns["Ціна"].HeaderText = "Ціна";
            DGV.Columns["Вартість"].HeaderText = "Вартість";
        }

        public void ZapTabFile()
        {
            string sNameFile, textRow;
            string sdir = Directory.GetCurrentDirectory();
            // Створюємо унікальне ім'я файлу на основі назви складу
            string safeFileName = GetSafeFileName();
            sNameFile = sdir + @"\FTabSklad_" + safeFileName + ".txt";
            
            try
            {
                if (File.Exists(sNameFile))
                {
                    File.Delete(sNameFile);
                }
                using (StreamWriter sw = new StreamWriter(sNameFile, false, Encoding.UTF8))
                {
                    foreach (DataRow rr in TabSklad.Rows)
                    {
                        textRow = rr["Група"] + ";" + rr["Назва"] + ";" + rr["Виробник"] + ";" +
                        rr["Постачальник"] + ";" + rr["Од_виміру"] + ";" +
                        Convert.ToString(rr["Кількість"]) + ";" + Convert.ToString(rr["Ціна"]);
                        sw.WriteLine(textRow);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Таблиця не записана: " + e.Message);
            }
        }

        public void ReadTabFile(DataGridView DGS)
        {
            string sNameFile;
            string sdir = Directory.GetCurrentDirectory();
            // Використовуємо унікальне ім'я файлу на основі назви складу
            string safeFileName = GetSafeFileName();
            sNameFile = sdir + @"\FTabSklad_" + safeFileName + ".txt";

            if (!File.Exists(sNameFile))
            {
                // Файл не існує - це нормально для нового складу
                return;
            }

            TabSklad.Rows.Clear();
            
            try
            {
                using (StreamReader sr = new StreamReader(sNameFile, Encoding.UTF8))
                {
                    while (sr.Peek() >= 0)
                    {
                        string textRow = sr.ReadLine();
                        string[] parts = textRow.Split(';');
                        
                        if (parts.Length >= 7)
                        {
                            string pGrupa = parts[0];
                            string pNazva = parts[1];
                            string pVyrobnyk = parts[2];
                            string pPostachalnyk = parts[3];
                            string pOdVym = parts[4];
                            decimal pKilkist = Convert.ToDecimal(parts[5]);
                            decimal pCina = Convert.ToDecimal(parts[6]);
                            
                            TSkladAddRow(pGrupa, pNazva, pVyrobnyk, pPostachalnyk, pOdVym, pKilkist, pCina);
                        }
                    }
                }
                SetSumy(DGS);
            }
            catch (Exception e)
            {
                MessageBox.Show("Помилка при читанні файлу: " + e.Message);
            }
        }

        public void TSkladValFiltr(String PFilter, DataGridView DGV)
        {
            try
            {
                SkladView.RowFilter = PFilter;
                FiltrCriteria = PFilter;
                DGV.DataSource = SkladView;
            }
            catch
            {
                MessageBox.Show("Введений Вами Фільтр не правильний");
                return;
            }
        }

        public void TSkladValSort(String PSort, DataGridView DGV, DataGridView DGVSum)
        {
            try
            {
                SkladView.Sort = PSort;
                SortCriteria = PSort;
                DGV.DataSource = SkladView;
                DGV.Refresh();
            }
            catch
            {
                MessageBox.Show("Введений Вами критерій сортування не правильний");
                return;
            }
        }

        public void SeekNazva(string sNazva, DataGridView DGV)
        {
            int nn = -5;
            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                if ((string)DGV.Rows[i].Cells["Назва"].Value == sNazva)
                {
                    nn = i;
                    break;
                }
            }
            if (nn >= 0)
            {
                DGV.FirstDisplayedCell = DGV.Rows[nn].Cells["Назва"];
                DGV.Rows[nn].Selected = true;
                DGV.CurrentCell = DGV.Rows[nn].Cells["Назва"];
            }
            else
            {
                MessageBox.Show("Значення не знайдено");
            }
        }

        public void SetSumy(DataGridView DGV)
        {
            string sGrupa, ssort;
            decimal DSuma;
            int i;
            DataTable TabSkladSum = new DataTable();
            DataColumn cNameGroupS = new DataColumn("Група");
            DataColumn cVartistS = new DataColumn("Вартість");

            cNameGroupS.DataType = System.Type.GetType("System.String");
            cVartistS.DataType = System.Type.GetType("System.Decimal");

            TabSkladSum.Columns.Add(cNameGroupS);
            TabSkladSum.Columns.Add(cVartistS);

            ssort = SkladView.Sort;
            SkladView.Sort = "Група";
            i = 0;
            while (i < SkladView.Count)
            {
                sGrupa = (string)SkladView[i]["Група"];
                DSuma = 0.0M;
                while ((i < SkladView.Count) && (sGrupa == (string)SkladView[i]["Група"]))
                {
                    try
                    {
                        DSuma = DSuma + (decimal)SkladView[i]["Вартість"];
                    }
                    catch
                    {
                        SkladView[i]["Вартість"] = 0M;
                    }
                    i = i + 1;
                    if (i == SkladView.Count) { break; }
                }
                DataRow rowSkladSum = TabSkladSum.NewRow();
                rowSkladSum["Група"] = sGrupa;
                rowSkladSum["Вартість"] = DSuma;
                TabSkladSum.Rows.Add(rowSkladSum);
            }
            DGV.DataSource = TabSkladSum;
            SkladView.Sort = SortCriteria;
        }

        public void CreateDovGrupa()
        {
            DataColumn cNameGroup = new DataColumn("Група");
            cNameGroup.DataType = System.Type.GetType("System.String");
            DovGrupa.Columns.Add(cNameGroup);

            if (LoadDovGrupaFromFile())
            {
                return;
            }

            string[] groups = { "Книги", "CD", "DVD", "Мобілки", "Плеєри", "Аксессуари", "Дисплеї", "Корпуси", "Блоки живлення", "Клавіатури" };
            
            foreach (string groupName in groups)
            {
                DataRow row = DovGrupa.NewRow();
                row[cNameGroup] = groupName;
                DovGrupa.Rows.Add(row);
            }

            SaveDovGrupaToFile();
        }

        public void CreateDovPostachalnyk()
        {
            DataColumn cPostachalnyk = new DataColumn("Постачальник");
            cPostachalnyk.DataType = System.Type.GetType("System.String");
            DovPostachalnyk.Columns.Add(cPostachalnyk);

            if (LoadDovPostachalnykFromFile())
            {
                return;
            }

            string[] postachalnyky = { "ТОВ 'Техносвіт'", "ПП 'Електроніка Плюс'", "ТОВ 'КомпСервіс'", "ПрАТ 'Книжковий дім'", "ТОВ 'Медіа-Центр'", "ПП 'IT-Маркет'" };
            
            foreach (string post in postachalnyky)
            {
                DataRow row = DovPostachalnyk.NewRow();
                row[cPostachalnyk] = post;
                DovPostachalnyk.Rows.Add(row);
            }

            SaveDovPostachalnykToFile();
        }

        public void CreateDovOdVym()
        {
            DataColumn cOdVym = new DataColumn("Од_виміру");
            cOdVym.DataType = System.Type.GetType("System.String");
            DovOdVym.Columns.Add(cOdVym);

            if (LoadDovOdVymFromFile())
            {
                return;
            }

            string[] odvym = { "грн", "euro", "usd", "podorozniki" };
            
            foreach (string od in odvym)
            {
                DataRow row = DovOdVym.NewRow();
                row[cOdVym] = od;
                DovOdVym.Rows.Add(row);
            }

            SaveDovOdVymToFile();
        }

        public void SaveDovGrupaToFile()
        {
            string sNameFile;
            string sdir = Directory.GetCurrentDirectory();
            sNameFile = sdir + @"\FDovGrupa.txt";
            try
            {
                if (File.Exists(sNameFile))
                {
                    File.Delete(sNameFile);
                }
                using (StreamWriter sw = new StreamWriter(sNameFile, false, Encoding.UTF8))
                {
                    foreach (DataRow rr in DovGrupa.Rows)
                    {
                        sw.WriteLine(rr["Група"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Помилка при збереженні довідника груп: " + e.Message);
            }
        }

        public bool LoadDovGrupaFromFile()
        {
            string sNameFile;
            string sdir = Directory.GetCurrentDirectory();
            sNameFile = sdir + @"\FDovGrupa.txt";
            
            if (!File.Exists(sNameFile))
            {
                return false;
            }

            try
            {
                DovGrupa.Rows.Clear();
                using (StreamReader sr = new StreamReader(sNameFile, Encoding.UTF8))
                {
                    while (sr.Peek() >= 0)
                    {
                        string grupa = sr.ReadLine();
                        if (!string.IsNullOrWhiteSpace(grupa))
                        {
                            DataRow newRow = DovGrupa.NewRow();
                            newRow["Група"] = grupa;
                            DovGrupa.Rows.Add(newRow);
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Помилка при завантаженні довідника груп: " + e.Message);
                return false;
            }
        }

        public void SaveDovPostachalnykToFile()
        {
            string sNameFile;
            string sdir = Directory.GetCurrentDirectory();
            sNameFile = sdir + @"\FDovPostachalnyk.txt";
            try
            {
                if (File.Exists(sNameFile))
                {
                    File.Delete(sNameFile);
                }
                using (StreamWriter sw = new StreamWriter(sNameFile, false, Encoding.UTF8))
                {
                    foreach (DataRow rr in DovPostachalnyk.Rows)
                    {
                        sw.WriteLine(rr["Постачальник"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Помилка при збереженні довідника постачальників: " + e.Message);
            }
        }

        public bool LoadDovPostachalnykFromFile()
        {
            string sNameFile;
            string sdir = Directory.GetCurrentDirectory();
            sNameFile = sdir + @"\FDovPostachalnyk.txt";
            
            if (!File.Exists(sNameFile))
            {
                return false;
            }

            try
            {
                DovPostachalnyk.Rows.Clear();
                using (StreamReader sr = new StreamReader(sNameFile, Encoding.UTF8))
                {
                    while (sr.Peek() >= 0)
                    {
                        string post = sr.ReadLine();
                        if (!string.IsNullOrWhiteSpace(post))
                        {
                            DataRow newRow = DovPostachalnyk.NewRow();
                            newRow["Постачальник"] = post;
                            DovPostachalnyk.Rows.Add(newRow);
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Помилка при завантаженні довідника постачальників: " + e.Message);
                return false;
            }
        }

        public void SaveDovOdVymToFile()
        {
            string sNameFile;
            string sdir = Directory.GetCurrentDirectory();
            sNameFile = sdir + @"\FDovOdVym.txt";
            try
            {
                if (File.Exists(sNameFile))
                {
                    File.Delete(sNameFile);
                }
                using (StreamWriter sw = new StreamWriter(sNameFile, false, Encoding.UTF8))
                {
                    foreach (DataRow rr in DovOdVym.Rows)
                    {
                        sw.WriteLine(rr["Од_виміру"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Помилка при збереженні довідника одиниць виміру: " + e.Message);
            }
        }

        public bool LoadDovOdVymFromFile()
        {
            string sNameFile;
            string sdir = Directory.GetCurrentDirectory();
            sNameFile = sdir + @"\FDovOdVym.txt";
            
            if (!File.Exists(sNameFile))
            {
                return false;
            }

            try
            {
                DovOdVym.Rows.Clear();
                using (StreamReader sr = new StreamReader(sNameFile, Encoding.UTF8))
                {
                    while (sr.Peek() >= 0)
                    {
                        string odv = sr.ReadLine();
                        if (!string.IsNullOrWhiteSpace(odv))
                        {
                            DataRow newRow = DovOdVym.NewRow();
                            newRow["Од_виміру"] = odv;
                            DovOdVym.Rows.Add(newRow);
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Помилка при завантаженні довідника одиниць виміру: " + e.Message);
                return false;
            }
        }

        public void RefreshComboBoxGrupa(ComboBox cb)
        {
            cb.Items.Clear();
            foreach (DataRow r in DovGrupa.Rows)
            {
                cb.Items.Add(r["Група"]);
            }
        }

        public void RefreshComboBoxPostachalnyk(ComboBox cb)
        {
            cb.Items.Clear();
            foreach (DataRow r in DovPostachalnyk.Rows)
            {
                cb.Items.Add(r["Постачальник"]);
            }
        }

        public void RefreshComboBoxOdVym(ComboBox cb)
        {
            cb.Items.Clear();
            foreach (DataRow r in DovOdVym.Rows)
            {
                cb.Items.Add(r["Од_виміру"]);
            }
        }

        public void RefreshDataGridViewGrupa(DataGridView DGV)
        {
            if (DGV.Columns.Contains("Група"))
            {
                DGV.Columns.Remove("Група");
            }
            
            AddComboGrupa(DGV);
        }

        public void AddComboGrupa(DataGridView DGV)
        {
            DataGridViewComboBoxColumn cGrupaCB = new DataGridViewComboBoxColumn();
            cGrupaCB.DataPropertyName = "Група";
            cGrupaCB.Name = "cNameGroupComb";
            cGrupaCB.HeaderText = "Група";
            cGrupaCB.DropDownWidth = 200;
            cGrupaCB.Width = 120;
            cGrupaCB.MaxDropDownItems = 10;
            cGrupaCB.FlatStyle = FlatStyle.Flat;

            foreach (DataRow r in DovGrupa.Rows)
            {
                cGrupaCB.Items.Add(r["Група"]);
            }

            DGV.Columns.Add(cGrupaCB);

            foreach (DataGridViewRow rrr in DGV.Rows)
            {
                if (rrr.IsNewRow) continue;
                if (rrr.Cells["Група"] != null && rrr.Cells["Група"].Value != null)
                {
                    string ss = (string)rrr.Cells["Група"].Value;
                    rrr.Cells["cNameGroupComb"].Value = ss;
                }
            }

            if (DGV.Columns.Contains("Група"))
            {
                DGV.Columns.Remove("Група");
            }
            DGV.Columns["cNameGroupComb"].Name = "Група";
            DGV.Columns["Група"].DisplayIndex = 1;
            DGV.Refresh();
        }

        public void AddComboPostachalnyk(DataGridView DGV)
        {
            DataGridViewComboBoxColumn cPostCB = new DataGridViewComboBoxColumn();
            cPostCB.DataPropertyName = "Постачальник";
            cPostCB.Name = "cPostachalnykComb";
            cPostCB.HeaderText = "Постачальник";
            cPostCB.DropDownWidth = 200;
            cPostCB.Width = 150;
            cPostCB.MaxDropDownItems = 10;
            cPostCB.FlatStyle = FlatStyle.Flat;

            foreach (DataRow r in DovPostachalnyk.Rows)
            {
                cPostCB.Items.Add(r["Постачальник"]);
            }

            DGV.Columns.Add(cPostCB);

            foreach (DataGridViewRow rrr in DGV.Rows)
            {
                if (rrr.IsNewRow) continue;
                if (rrr.Cells["Постачальник"] != null && rrr.Cells["Постачальник"].Value != null)
                {
                    string ss = (string)rrr.Cells["Постачальник"].Value;
                    rrr.Cells["cPostachalnykComb"].Value = ss;
                }
            }

            if (DGV.Columns.Contains("Постачальник"))
            {
                DGV.Columns.Remove("Постачальник");
            }
            DGV.Columns["cPostachalnykComb"].Name = "Постачальник";
            DGV.Columns["Постачальник"].DisplayIndex = 4;
            DGV.Refresh();
        }

        public void AddComboOdVym(DataGridView DGV)
        {
            DataGridViewComboBoxColumn cOdVymCB = new DataGridViewComboBoxColumn();
            cOdVymCB.DataPropertyName = "Од_виміру";
            cOdVymCB.Name = "cOdVymComb";
            cOdVymCB.HeaderText = "Од. виміру";
            cOdVymCB.DropDownWidth = 150;
            cOdVymCB.Width = 100;
            cOdVymCB.MaxDropDownItems = 10;
            cOdVymCB.FlatStyle = FlatStyle.Flat;

            foreach (DataRow r in DovOdVym.Rows)
            {
                cOdVymCB.Items.Add(r["Од_виміру"]);
            }

            DGV.Columns.Add(cOdVymCB);

            foreach (DataGridViewRow rrr in DGV.Rows)
            {
                if (rrr.IsNewRow) continue;
                if (rrr.Cells["Од_виміру"] != null && rrr.Cells["Од_виміру"].Value != null)
                {
                    string ss = (string)rrr.Cells["Од_виміру"].Value;
                    rrr.Cells["cOdVymComb"].Value = ss;
                }
            }

            if (DGV.Columns.Contains("Од_виміру"))
            {
                DGV.Columns.Remove("Од_виміру");
            }
            DGV.Columns["cOdVymComb"].Name = "Од_виміру";
            DGV.Columns["Од_виміру"].DisplayIndex = 5;
            DGV.Refresh();
        }
    }
}
