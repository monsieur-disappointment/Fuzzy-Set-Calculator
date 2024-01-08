using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzySetCalc
{
    public partial class Form1 : Form
    {
        private FuzzySet setA;
        private FuzzySet setB;
        private FuzzySet setC;
        bool tmp;

        public Form1()
        {
            InitializeComponent();
            FuzzySetA.Rows.Add(2);
            FuzzySetB.Rows.Add(2);
            FuzzySetA.Rows[0].Cells[0].Value = "0";
            FuzzySetA.Rows[1].Cells[0].Value = "1";
            FuzzySetB.Rows[0].Cells[0].Value = "0";
            FuzzySetB.Rows[1].Cells[0].Value = "1";
        }

        private FuzzySet CreateSet(DataGridView dg) {
            //List<List<double>> set = new List<List<double>>();
            List<double> set0 = new List<double>();
            List<double> set1 = new List<double>();
            List<double> set2 = new List<double>();

            for (int i = 0; i < dg.Rows.Count - 1; i++) {
                if (dg.Rows[i].Cells[0].Value != null) set0.Add(Convert.ToDouble(dg.Rows[i].Cells[0].Value.ToString()));
                if (dg.Rows[i].Cells[1].Value != null) set1.Add(Convert.ToDouble(dg.Rows[i].Cells[1].Value.ToString()));
                if (dg.Rows[i].Cells[2].Value != null) set2.Add(Convert.ToDouble(dg.Rows[i].Cells[2].Value.ToString()));
            }

            return new FuzzySet(set0, set1, set2);
        }

        private void DrawGraph() {
            List<List<double>> tmp = setA.ToList();

            for (int i = 0; i < tmp[0].Count; i++)
                Graph.Series[0].Points.AddXY(tmp[1][i], tmp[0][i]);
            for (int i = tmp[0].Count - 1; i >= 0; i--)
                Graph.Series[0].Points.AddXY(tmp[2][i], tmp[0][i]);
            tmp = setB.ToList();
            for (int i = 0; i < tmp[0].Count; i++)
                Graph.Series[1].Points.AddXY(tmp[1][i], tmp[0][i]);
            for (int i = tmp[0].Count - 1; i >= 0; i--)
                Graph.Series[1].Points.AddXY(tmp[2][i], tmp[0][i]);
            tmp = setC.ToList();
            if (tmp == null) return;
            for (int i = 0; i < tmp[0].Count; i++)
                Graph.Series[2].Points.AddXY(tmp[1][i], tmp[0][i]);
            for (int i = tmp[0].Count - 1; i >= 0; i--)
                Graph.Series[2].Points.AddXY(tmp[2][i], tmp[0][i]);
        }
        private string Compare() {
            string msg = "";
            if (setA == setB) msg = "A equal to B";
            if (setA >= setB) msg = "A not less then B";
            if (setA > setB) msg = "A greater then B";
            if (setA <= setB) msg = "A not greater then B";
            if (setA < setB) msg = "A less then B";

            return msg;
        }
        private void SetOutput() {
            List<List<double>> tmp = setC.ToList();
            for (int i = 0; i < tmp[0].Count; i++)
                FuzzySetC.Rows.Add();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < tmp[i].Count; j++)
                    FuzzySetC.Rows[j].Cells[i].Value = tmp[i][j].ToString();
            FuzzySetC.Sort(FuzzySetC.Columns[0], ListSortDirection.Ascending);
        }
        private bool Validation(DataGridView dg) {

            dg.Sort(dg.Columns[0], ListSortDirection.Ascending);

            for (int i = 1; i < dg.Rows.Count - 1; i++) {

                if ((String)dg.Rows[i - 1].Cells[0].Value == null || (String)dg.Rows[i - 1].Cells[1].Value == null || (String)dg.Rows[i - 1].Cells[2].Value == null) return false;
                if ((String)dg.Rows[i].Cells[0].Value == null || (String)dg.Rows[i].Cells[1].Value == null || (String)dg.Rows[i].Cells[2].Value == null) return false;

                if (Convert.ToDouble(dg.Rows[i-1].Cells[0].Value.ToString()) < 0 && Convert.ToDouble(dg.Rows[i].Cells[0].Value.ToString()) < 0) return false;
                if (Convert.ToDouble(dg.Rows[i-1].Cells[0].Value.ToString()) > 1 && Convert.ToDouble(dg.Rows[i].Cells[0].Value.ToString()) > 1) return false;

                if (Convert.ToDouble(dg.Rows[i-1].Cells[1].Value.ToString()) > Convert.ToDouble(dg.Rows[i].Cells[1].Value.ToString())) return false;

                if (Convert.ToDouble(dg.Rows[i-1].Cells[2].Value.ToString()) < Convert.ToDouble(dg.Rows[i].Cells[2].Value.ToString())) return false;
            }
            return true;
        }
        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (Validation(FuzzySetA)) setA = CreateSet(FuzzySetA);
            else setA = new FuzzySet(new List<double> { 0, 0.5, 1 }, new List<double> { 1, 2, 3 }, new List<double> { 10, 9, 4 });

            if (Validation(FuzzySetB)) setB = CreateSet(FuzzySetB);
            else setB = new FuzzySet(new List<double> { 0, 0.2, 0.5, 1}, new List<double> { 1, 2, 3, 4 }, new List<double> { 9, 7, 6, 5 });

            switch (operationSelector.SelectedIndex) {
                case 0: setC = setA + setB; SetOutput(); DrawGraph(); break;
                case 1: setC = setA - setB; SetOutput(); DrawGraph(); break;
                case 2: setC = setA * setB; SetOutput(); DrawGraph(); break;
                case 3: setC = setA / setB; SetOutput(); DrawGraph(); break;
                case 4: MessageBox.Show(Compare()); DrawGraph(); break;
                default: MessageBox.Show("Pick the operation"); break;
            }
        }
    }
}
