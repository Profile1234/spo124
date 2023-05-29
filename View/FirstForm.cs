using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class FirstForm : Form
    {
        public List<Elements> list = new List<Elements>();

        public FirstForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            new SecondForm { Owner = this }.ShowDialog();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            new ThirdForm { Owner = this }.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.SelectedRows[0].Index;
                list.RemoveAt(index);
                dataGridView1.Rows.RemoveAt(index);
            }
            catch (Exception)
            {
                MessageBox.Show("Выбрана пустая строка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFrom_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Файлы программы (*.elem)|*.elem|Все файлы (*.*)|*.*";

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream file = File.OpenRead(openFileDialog1.FileName);
                    List<Elements> list1 = new BinaryFormatter().Deserialize(file) as List<Elements>;

                    list.Clear();
                    dataGridView1.Rows.Clear();
                    string name = "";

                    if (list1 != null)
                        foreach (var item in list1)
                        {
                            if (item.GetType() == typeof(Resistor))
                                name = "Резистор";
                            else if (item.GetType() == typeof(Capacitor))
                                name = "Конденсатор";
                            else if (item.GetType() == typeof(Inductance))
                                name = "Катушка";
                            dataGridView1.Rows.Add(name, item.Characteristic(), item.ComplexResistance());
                            list.Add(item);
                        }

                    file.Close();
                }
            }
            catch (Exception expStr)
            {
                MessageBox.Show(expStr.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonIn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Файлы программы (*.elem)|*.elem|Все файлы (*.*)|*.*";

            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog1.FilterIndex == 2)
                    {
                        FileStream file = File.Create($"{saveFileDialog1.FileName}.elem");
                        new BinaryFormatter().Serialize(file, list);
                        file.Close();
                    }
                    else
                    {
                        FileStream file = File.Create($"{saveFileDialog1.FileName}");
                        new BinaryFormatter().Serialize(file, list);
                        file.Close();
                    }
                }
            }
            catch (Exception expStr)
            {
                MessageBox.Show(expStr.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
