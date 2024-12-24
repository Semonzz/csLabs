using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab04
{
    public partial class Edit : Form
    {
        public static Cat CatTMP = null;
        public static Bird BirdTMP = null;
        public Edit(Cat CatTMP)
        {
            Edit.CatTMP = CatTMP;
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            numericUpDown3.Value = CatTMP.getAge();
            numericUpDown2.Value = CatTMP.getWeight();
            textBox1.Text = CatTMP.getColor();
            textBox2.Text = CatTMP.getName();
            textBox3.Text = CatTMP.getBreed();
        }
        public Edit(Bird BirdTMP)
        {
            Edit.BirdTMP = BirdTMP;
            InitializeComponent();
            comboBox1.SelectedIndex = 1;
            numericUpDown2.Value = BirdTMP.getWeight();
            numericUpDown3.Value = BirdTMP.getWingspan();
            textBox1.Text = BirdTMP.getColor();
            textBox2.Text = BirdTMP.getKind();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label4.Text = "Age";
                label5.Text = "Name";
                label6.Location = new System.Drawing.Point(28, 245);
                textBox3.Location = new System.Drawing.Point(136, 245);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                label4.Text = "Wingspan";
                label5.Text = "Kind";
                label6.Location = new System.Drawing.Point(-35, -307);
                textBox3.Location = new System.Drawing.Point(-181, -304);
            }
        }

        public bool valid()
        {
            for (int i = 0; i < FormMain.Cats.Count; i++)
            {
                if (FormMain.Cats[i].getWeight() == (int)numericUpDown2.Value)
                    return false;
            }
            for (int i = 0; i < FormMain.Birds.Count; i++)
            {
                if (FormMain.Birds[i].getWeight() == (int)numericUpDown2.Value)
                    return false;
            }
            if (textBox1.Text.Length > 0 && comboBox1.SelectedIndex != -1)
                return true;
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                CatTMP = null;
                BirdTMP = null;
                if (comboBox1.SelectedIndex == 0)
                {
                    CatTMP = new Cat((int)numericUpDown3.Value, textBox2.Text, textBox3.Text, (int)numericUpDown2.Value, textBox1.Text);
                }
                else
                {
                    BirdTMP = new Bird((int)numericUpDown3.Value, textBox2.Text, (int)numericUpDown2.Value, textBox1.Text);
                }
            }
            else if (comboBox1.SelectedIndex == -1)
                MessageBox.Show("Enter Animal Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox1.Text.Length == 0)
                MessageBox.Show("Enterfield " + (comboBox1.SelectedIndex == 0 ? "Breed" : "Kind"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Name is unavailable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
