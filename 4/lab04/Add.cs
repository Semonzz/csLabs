using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab04
{
    public partial class Add : Form
    {
        public static List<Cat> Cats = new List<Cat>();
        public static List<Bird> Birds = new List<Bird>();

        public Add()
        {
            InitializeComponent();
        }

        public bool valid()
        {
            for (int i = 0; i < Cats.Count; i++)
            {
                if (Cats[i].getName() == textBox1.Text)
                    return false;
            }
            for (int i = 0; i < Birds.Count; i++)
            {
                if (Birds[i].getKind() == textBox1.Text)
                    return false;
            }
            for (int i = 0; i < FormMain.Cats.Count; i++)
            {
                if (FormMain.Cats[i].getName() == textBox1.Text)
                    return false;
            }
            for (int i = 0; i < FormMain.Birds.Count; i++)
            {
                if (FormMain.Birds[i].getKind() == textBox1.Text)
                    return false;
            }
            if (textBox1.Text.Length > 0)
                return true;
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                if (comboBox1.Text == "Cat")
                {
                    Cat PT = new Cat((int)numericUpDown3.Value, textBox1.Text, textBox3.Text, (int)numericUpDown2.Value, textBox2.Text);
                    Cats.Add(PT);
                    FormMain.Cats.Add(PT);
                }
                else if (comboBox1.Text == "Bird")
                {
                    Bird FT = new Bird((int)numericUpDown3.Value, textBox1.Text, (int)numericUpDown2.Value, textBox2.Text);
                    Birds.Add(FT);
                    FormMain.Birds.Add(FT);
                }
                else MessageBox.Show("Choose animal type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                upDate();
            }
            else if (textBox1.Text.Length == 0)
                MessageBox.Show("Enter field " + (comboBox1.SelectedIndex == 0 ? "color" : "hz"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("This name is unavailable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void upDate()
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label4.Text = "Age";
                label5.Text = "Name";
                label6.Location = new System.Drawing.Point(54, 263);
                textBox3.Location = new System.Drawing.Point(164, 263);

                dataGridView1.Columns.Clear();
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.Columns.Add("Name", "Name");
                dataGridView1.Columns.Add("Age", "Age");
                dataGridView1.Columns.Add("Breed", "Breed");
                dataGridView1.Columns.Add("Color", "Color");
                dataGridView1.Columns.Add("Weight", "Weight");
                Cats.Sort();
                dataGridView1.Rows.Clear();
                int n = Cats.Count;
                if (n > 0)
                    dataGridView1.Rows.Add(n);
                for (int i = 0; i < n; ++i)
                {
                    dataGridView1.Rows[i].Cells["Name"].Value = Cats[i].getName();
                    dataGridView1.Rows[i].Cells["Age"].Value = Cats[i].getAge();
                    dataGridView1.Rows[i].Cells["Breed"].Value = Cats[i].getBreed();
                    dataGridView1.Rows[i].Cells["Color"].Value = Cats[i].getColor();
                    dataGridView1.Rows[i].Cells["Weight"].Value = Cats[i].getWeight();
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                label4.Text = "Wingspan";
                label5.Text = "Kind";
                label6.Location = new System.Drawing.Point(-100, -100);
                textBox3.Location = new System.Drawing.Point(-219, -324);

                dataGridView1.Columns.Clear();
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.Columns.Add("Color", "Color");
                dataGridView1.Columns.Add("Kind", "Kind");
                dataGridView1.Columns.Add("Wingspan", "Wingspan");
                dataGridView1.Columns.Add("Weight", "Weight");
                Birds.Sort();
                dataGridView1.Rows.Clear();
                int n = Birds.Count;
                if (n > 0)
                    dataGridView1.Rows.Add(n);
                for (int i = 0; i < n; ++i)
                {
                    dataGridView1.Rows[i].Cells["Color"].Value = Birds[i].getColor();
                    dataGridView1.Rows[i].Cells["Kind"].Value = Birds[i].getKind();
                    dataGridView1.Rows[i].Cells["Wingspan"].Value = Birds[i].getWingspan();
                    dataGridView1.Rows[i].Cells["Weight"].Value = Birds[i].getWeight();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            upDate();
        }
    }
}
