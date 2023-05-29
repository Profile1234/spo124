using System;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class SecondForm : Form
    {
        int index = 0;

        public SecondForm()
        {
            InitializeComponent();
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = true;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButtonR_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = true;
            label5.Visible = true;
            label4.Text = "R =";
            label5.Text = "Ом";
            textBox1.Visible = false;
            textBox2.Visible = true;
            index = 1;
        }

        private void radioButtonC_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label4.Text = "C =";
            label5.Text = "Ф";
            textBox1.Visible = true;
            textBox2.Visible = true;
            index = 2;
        }

        private void radioButtonI_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label4.Text = "L =";
            label5.Text = "Гн";
            textBox1.Visible = true;
            textBox2.Visible = true;
            index = 3;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            FirstForm form = (FirstForm)Owner;
            Elements buffer = null;
            string bufferStr = "";

            try
            {
                if (index == 1)
                {
                    if (textBox2.Text == "")
                        throw new NullReferenceException("Значение не задано");
                    buffer = new Resistor(float.Parse(textBox2.Text));
                    bufferStr = "Резистор";
                }
                else if (index == 2)
                {
                    if (textBox2.Text == "" || textBox1.Text == "")
                        throw new NullReferenceException("Значение не задано");
                    buffer = new Capacitor(float.Parse(textBox1.Text), float.Parse(textBox2.Text));
                    bufferStr = "Конденсатор";
                }
                else if (index == 3)
                {
                    if (textBox2.Text == "" || textBox1.Text == "")
                        throw new NullReferenceException("Значение не задано");
                    buffer = new Inductance(float.Parse(textBox1.Text), float.Parse(textBox2.Text));
                    bufferStr = "Катушка";
                }
                else
                {
                    throw new Exception("Пункт не выбран");
                }
                form.list.Add(buffer);
                form.dataGridView1.Rows.Add(bufferStr, buffer.Characteristic(), buffer.ComplexResistance());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

#if RAND
        private void buttonRand_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int indexRand = random.Next(1, 4);

            if (indexRand == 1)
            {
                radioButtonR.Select();
                textBox2.Text = Convert.ToString(random.Next(1, 100));
            }
            else if (indexRand == 2)
            {
                radioButtonC.Select();
                textBox1.Text = Convert.ToString(random.Next(1, 100) * 2 * Math.PI);
                textBox2.Text = Convert.ToString((float)random.Next(1, 10) / 1000000);
            }
            else if (indexRand == 3)
            {
                radioButtonI.Select();
                textBox1.Text = Convert.ToString(random.Next(1, 100) * 2 * Math.PI);
                textBox2.Text = Convert.ToString((float)random.Next(1, 10) / 1000);
            }
        }
#endif
    }
}
