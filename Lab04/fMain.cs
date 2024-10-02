using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void Lab04_Load(object sender, EventArgs e)
        {

            gvProcessor.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "name";
            column.Name = "Назва";
            gvProcessor.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "manufacturer";
            column.Name = "Виробник";
            gvProcessor.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "core";
            column.Name = "Кількість ядер";
            gvProcessor.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "frequency";
            column.Name = "Частота";
            gvProcessor.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "tdp";
            column.Name = "Тепловіділення";
            gvProcessor.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "performancePerCore";
            column.Name = "Продуктивність";
            gvProcessor.Columns.Add(column);


            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "multiPrecision";
            column.Name = "Багатопоточність";
            column.Width = 100;
            gvProcessor.Columns.Add(column);


            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "energySaving";
            column.Name = "Режим енергозбереження";
            column.Width = 120;
            gvProcessor.Columns.Add(column);


            bindSrcProcessor.Add(new Processor("Inter Core  і5","Inter", 4, 3, 65, 250, true, true));
            EventArgs args = new EventArgs(); OnResize(args);

        }


        private void fMain_Resize(object sender, EventArgs e)
        {
            int buttonsSize = 5 * btnAdd.Width + 2 * tsSeparator1.Width + 30;
            btnExit.Margin = new Padding(Width - buttonsSize, 0, 0, 0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Processor processor = new Processor();

            fProcessor ft = new fProcessor(processor);
            if (ft.ShowDialog() == DialogResult.OK)
            {
                bindSrcProcessor.Add(processor);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Processor processor = (Processor)bindSrcProcessor.List[bindSrcProcessor.Position];

            fProcessor ft = new fProcessor(processor);
            if (ft.ShowDialog() == DialogResult.OK)
            {
                bindSrcProcessor.List[bindSrcProcessor.Position] = processor;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Видалити поточний запис?", "Видалення запису",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bindSrcProcessor.RemoveCurrent();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Очистити таблицю?\n\nВсі дані будуть втрачені", "Очищення даних",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bindSrcProcessor.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Закрити застосунок?", "Вихід з програми", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
