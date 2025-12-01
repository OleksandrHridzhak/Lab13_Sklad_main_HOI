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
        public DataTable TabSklad = new DataTable();
        public DataView SkladView;
        public string FiltrCriteria;
        public string SortCriteria;
        public DataGridViewComboBoxColumn cGrupaCB;
        public DataTable DovGrupa = new DataTable();

        public TSklad()
        {
            DataColumn cNpp = new DataColumn("N_пп");
            DataColumn cNameGroup = new DataColumn("Група");
            DataColumn cNameProduct = new DataColumn("Назва");
            DataColumn cProduser = new DataColumn("Виробник");
            DataColumn cCount = new DataColumn("Кількість");
            DataColumn cPrise = new DataColumn("Ціна");
            DataColumn cVartist = new DataColumn("Вартість");

            cNpp.DataType = System.Type.GetType("System.Int32");
            cNameGroup.DataType = System.Type.GetType("System.String");
            cNameProduct.DataType = System.Type.GetType("System.String");
            cProduser.DataType = System.Type.GetType("System.String");
            cCount.DataType = System.Type.GetType("System.Int32");
            cPrise.DataType = System.Type.GetType("System.Decimal");
            cVartist.DataType = System.Type.GetType("System.Decimal");

            TabSklad.Columns.Add(cNpp);
            TabSklad.Columns.Add(cNameGroup);
            TabSklad.Columns.Add(cNameProduct);
            TabSklad.Columns.Add(cProduser);
            TabSklad.Columns.Add(cPrise);
            TabSklad.Columns.Add(cCount);
            TabSklad.Columns.Add(cVartist);

            SkladView = new DataView(TabSklad);
        }

        public void TSkladAddRow(string pNameGroup, string pNameProduct, string pProduser, int pCount, decimal pPrise)
        {
            DataRow rowSklad = TabSklad.NewRow();
            int npp = TabSklad.Rows.Count + 1;
            rowSklad["N_пп"] = npp;
            rowSklad["Група"] = pNameGroup;
            rowSklad["Назва"] = pNameProduct;
            rowSklad["Виробник"] = pProduser;
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
            DGV.Columns["Кількість"].HeaderText = "Кількість";
            DGV.Columns["Ціна"].HeaderText = "Ціна";
            DGV.Columns["Вартість"].HeaderText = "Вартість";
        }

        public void ZapTabFile()
        {
            string sNameFile, textRow;
            string sdir = Directory.GetCurrentDirectory();
            sNameFile = sdir + @"\FTabSklad.txt";
            try
            {
                if (File.Exists(sNameFile))
                {
                    File.Delete(sNameFile);
                }
                using (StreamWriter sw = new StreamWriter(sNameFile))
                {
          foreach (DataRow rr in TabSklad.Rows)
                    {
                        textRow = rr["Група"] + ";" + rr["Назва"] + ";" + rr["Виробник"] + ";" +
                        Convert.ToString(rr["Кількість"]) + ";" + Convert.ToString(rr["Ціна"]);
                        sw.WriteLine(textRow);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Таблиця не записана");
            }
        }

        public void ReadTabFile(DataGridView DGS)
        {
            string sNameFile, textRow;
            string pGrupa, pNazva, pVyrobnyk, sKilkist, sCina;
            int pKilkist;
            decimal PCina;
            int i, ip;

            TabSklad.Rows.Clear();
            string sdir = Directory.GetCurrentDirectory();
            sNameFile = sdir + @"\FTabSklad.txt";
            using (StreamReader sr = new StreamReader(sNameFile))
            {

        while (sr.Peek() >= 0)
                {
                    pGrupa = ""; pNazva = ""; pVyrobnyk = ""; sKilkist = ""; sCina = "";
                    textRow = sr.ReadLine();

          i = textRow.IndexOf(';') - 1;
                    for (int j = 0; j <= i; j++)
                    {
                        pGrupa = pGrupa + textRow[j];
                    }
                    ip = i + 2;
                    i = textRow.IndexOf(';', ip) - 1;
                    for (int j = ip; j <= i; j++)
                    {
                        pNazva = pNazva + textRow[j];
                    }
                    ip = i + 2;
                    i = textRow.IndexOf(';', ip) - 1;
                    for (int j = ip; j <= i; j++)
                    {
                        pVyrobnyk = pVyrobnyk + textRow[j];
                    }
                    ip = i + 2;
                    i = textRow.IndexOf(';', ip) - 1;
                    for (int j = ip; j <= i; j++)
                    {
                        sKilkist = sKilkist + textRow[j];
                    }
                    ip = i + 2;
                    for (int j = ip; j <= textRow.Length - 1; j++)
                    {
                        sCina = sCina + textRow[j];
                    }
                    pKilkist = Convert.ToInt32(sKilkist);
                    PCina = Convert.ToDecimal(sCina);
                    TSkladAddRow(pGrupa, pNazva, pVyrobnyk, pKilkist, PCina);
                }
            }
            SetSumy(DGS);
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
            int nn;
            nn = -5;
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

            DataRow rowSklad0 = DovGrupa.NewRow();
            rowSklad0[cNameGroup] = "Книги";
            DovGrupa.Rows.Add(rowSklad0);

            DataRow rowSklad1 = DovGrupa.NewRow();
            rowSklad1[cNameGroup] = "CD";
            DovGrupa.Rows.Add(rowSklad1);

            DataRow rowSklad2 = DovGrupa.NewRow();
            rowSklad2[cNameGroup] = "DVD";
            DovGrupa.Rows.Add(rowSklad2);

            DataRow rowSklad3 = DovGrupa.NewRow();
            rowSklad3[cNameGroup] = "Мобілки";
            DovGrupa.Rows.Add(rowSklad3);

            DataRow rowSklad4 = DovGrupa.NewRow();
            rowSklad4[cNameGroup] = "Плеєри";
            DovGrupa.Rows.Add(rowSklad4);

            DataRow rowSklad5 = DovGrupa.NewRow();
            rowSklad5[cNameGroup] = "Аксессуари";
            DovGrupa.Rows.Add(rowSklad5);

            DataRow rowSklad6 = DovGrupa.NewRow();
            rowSklad6[cNameGroup] = "Дисплеї";
            DovGrupa.Rows.Add(rowSklad6);

            DataRow rowSklad7 = DovGrupa.NewRow();
            rowSklad7[cNameGroup] = "Корпуси";
            DovGrupa.Rows.Add(rowSklad7);

            DataRow rowSklad8 = DovGrupa.NewRow();
            rowSklad8[cNameGroup] = "Блоки живлення";
            DovGrupa.Rows.Add(rowSklad8);

            DataRow rowSklad9 = DovGrupa.NewRow();
            rowSklad9[cNameGroup] = "Клавіатури";
            DovGrupa.Rows.Add(rowSklad9);

            int nn = DovGrupa.Rows.Count;
        }

        public void AddComboGrupa(DataGridView DGV)
        {
            DataGridViewComboBoxColumn cGrupaCB = new DataGridViewComboBoxColumn();
            cGrupaCB.DataPropertyName = "Група";
            cGrupaCB.Name = "cNameGroupComb";
            cGrupaCB.HeaderText = "Група";
            cGrupaCB.DropDownWidth = 200;
            cGrupaCB.Width = 120;
            cGrupaCB.MaxDropDownItems = 7;
            cGrupaCB.FlatStyle = FlatStyle.Flat;
            cGrupaCB.ValueType = System.Type.GetType("System.string");

            String s;
            Int32 n;
            n = DovGrupa.Rows.Count;

            foreach (DataRow r in DovGrupa.Rows)
            {
                s = (string)r["Група"];
                cGrupaCB.Items.AddRange(r["Група"]);
            }

            DGV.Columns.Add(cGrupaCB);

            String ss;
            foreach (DataGridViewRow rrr in DGV.Rows)
            {
                ss = (string)rrr.Cells["Група"].Value;
                rrr.Cells["cNameGroupComb"].Value = rrr.Cells["Група"].Value;
            }

            DGV.Columns.Remove("Група");
            DGV.Columns["cNameGroupComb"].Name = "Група";
            DGV.Columns["Група"].DisplayIndex = 1;
            DGV.Refresh();
        }
    }
}
