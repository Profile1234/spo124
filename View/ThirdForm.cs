using System;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class ThirdForm : Form 
    {
        int index = 0;

        public ThirdForm()
        {
            InitializeComponent();
        }

        private void radioButtonR_CheckedChanged(object sender, EventArgs e)
        {
            FirstForm form = (FirstForm)Owner;
            form.dataGridView1.Rows.Clear();
            label5.Visible = label6.Visible = false;
            foreach (var item in form.list)
            {
                if (item.GetType() == typeof(Resistor))
                {
                    form.dataGridView1.Rows.Add("Резистор", item.Characteristic(), item.ComplexResistance());
                }
            }
            index = 1;
        }

        private void radioButtonC_CheckedChanged(object sender, EventArgs e)
        {
            FirstForm form = (FirstForm)Owner;
            form.dataGridView1.Rows.Clear();
            label5.Visible = label6.Visible = true;
            foreach (var item in form.list)
            {
                if (item.GetType() == typeof(Capacitor))
                {
                    form.dataGridView1.Rows.Add("Конденсатор", item.Characteristic(), item.ComplexResistance());
                }
            }
            index = 2;
        }

        private void radioButtonI_CheckedChanged(object sender, EventArgs e)
        {
            FirstForm form = (FirstForm)Owner;
            form.dataGridView1.Rows.Clear();
            label5.Visible = label6.Visible = true;
            foreach (var item in form.list)
            {
                if (item.GetType() == typeof(Inductance))
                {
                    form.dataGridView1.Rows.Add("Катушка", item.Characteristic(), item.ComplexResistance());
                }
            }
            index = 3;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            FirstForm form = (FirstForm)Owner;
            form.dataGridView1.Rows.Clear();
            string name = "";
            foreach (var item in form.list)
            {
                if (item.GetType() == typeof(Resistor))
                    name = "Резистор";
                else if (item.GetType() == typeof(Capacitor))
                    name = "Конденсатор";
                else if (item.GetType() == typeof(Inductance))
                    name = "Катушка";
                form.dataGridView1.Rows.Add(name, item.Characteristic(), item.ComplexResistance());
            }
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            FirstForm form = (FirstForm)Owner;
            form.dataGridView1.Rows.Clear();
            Type type;

            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                    throw new Exception("Значения не заданы");
                float d1, d2;
                d1 = float.Parse(textBox1.Text);
                d2 = float.Parse(textBox2.Text);
                string name = "";
                switch (index)
                {
                    case 1:
                        type = typeof(Resistor);
                        name = "Резистор";
                        break;
                    case 2:
                        type = typeof(Capacitor);
                        name = "Конденсатор";
                        break;
                    case 3:
                        type = typeof(Inductance);
                        name = "Катушка";
                        break;
                    default:
                        throw new Exception("Не выбран элемент");
                }
                foreach (var item in form.list)
                {
                    if (item.GetType() == type)
                    {
                        float Z = item.ComplexResistanceFloat();
                        if (Z >= d1 && Z <= d2)
                            form.dataGridView1.Rows.Add(name, item.Characteristic(), item.ComplexResistance());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
