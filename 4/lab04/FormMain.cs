using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace lab04
{
    public partial class FormMain : Form
    {
        public static List<Cat> Cats = new List<Cat>();
        public static List<Bird> Birds = new List<Bird>();

        void xmlWrite()
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement root = xmlDoc.CreateElement("Animal");
            xmlDoc.AppendChild(root);

            XmlElement cats = xmlDoc.CreateElement("Cat");
            root.AppendChild(cats);

            foreach (Cat item in Cats)
            {
                if (item.getName() != null)
                {
                    XmlElement catElement = xmlDoc.CreateElement("Cats");

                    XmlElement name = xmlDoc.CreateElement("name");
                    name.InnerText = item.getName();
                    catElement.AppendChild(name);

                    XmlElement color = xmlDoc.CreateElement("color");
                    color.InnerText = item.getColor();
                    catElement.AppendChild(color);

                    XmlElement age = xmlDoc.CreateElement("age");
                    age.InnerText = item.getAge().ToString();
                    catElement.AppendChild(age);

                    XmlElement breed = xmlDoc.CreateElement("breed");
                    breed.InnerText = item.getBreed();
                    catElement.AppendChild(breed);

                    XmlElement weight = xmlDoc.CreateElement("weight");
                    weight.InnerText = item.getWeight().ToString();
                    catElement.AppendChild(weight);

                    cats.AppendChild(catElement);
                }
            }

            XmlElement birds = xmlDoc.CreateElement("Bird");
            root.AppendChild(birds);

            foreach (Bird item in Birds)
            {
                if (item.getKind() != null)
                {
                    XmlElement birdElement = xmlDoc.CreateElement("Birds");

                    XmlElement kind = xmlDoc.CreateElement("kind");
                    kind.InnerText = item.getKind();
                    birdElement.AppendChild(kind);

                    XmlElement color = xmlDoc.CreateElement("color");
                    color.InnerText = item.getColor();
                    birdElement.AppendChild(color);

                    XmlElement wingspan = xmlDoc.CreateElement("wingspan");
                    wingspan.InnerText = item.getWingspan().ToString();
                    birdElement.AppendChild(wingspan);

                    XmlElement weight = xmlDoc.CreateElement("weight");
                    weight.InnerText = item.getWeight().ToString();
                    birdElement.AppendChild(weight);

                    birds.AppendChild(birdElement);
                }
            }

            // Сохраняем XML документ в файл
            xmlDoc.Save("Data.xml");
        }
        void xmlParse()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Data.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                XmlNode catsList = xRoot.FirstChild;
                XmlNode birdsList = xRoot.LastChild;
                foreach (XmlElement xnode in catsList)
                {
                    Cat tmp = new Cat();
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "name") tmp.setName(childnode.InnerText);
                        if (childnode.Name == "age") tmp.setAge(Convert.ToInt32(childnode.InnerText));
                        if (childnode.Name == "weight") tmp.setWeight(Convert.ToInt32(childnode.InnerText));
                        if (childnode.Name == "breed") tmp.setBreed(childnode.InnerText);
                        if (childnode.Name == "color") tmp.setColor(childnode.InnerText);

                    }
                    Cats.Add(tmp);
                }
                foreach (XmlElement xnode in birdsList)
                {
                    Bird tmp = new Bird();
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "kind") tmp.setKind(childnode.InnerText);
                        if (childnode.Name == "wingspan") tmp.setWingspan(Convert.ToInt32(childnode.InnerText));
                        if (childnode.Name == "weight") tmp.setWeight(Convert.ToInt32(childnode.InnerText));
                        if (childnode.Name == "color") tmp.setColor(childnode.InnerText);

                    }
                    Birds.Add(tmp);
                }
            }
        }

        void load()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Age", "Age");
            dataGridView1.Columns.Add("Breed", "Breed");
            dataGridView1.Columns.Add("Color", "Color");
            dataGridView1.Columns.Add("Weight", "Weight");

            dataGridView2.Columns.Clear();
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.Columns.Add("Color", "Color");
            dataGridView2.Columns.Add("Kind", "Kind");
            dataGridView2.Columns.Add("Wingspan", "Wingspan");
            dataGridView2.Columns.Add("Weight", "Weight");
        }
        void update()
        {
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
            dataGridView2.Rows.Clear();
            n = Birds.Count;
            if (n > 0)
                dataGridView2.Rows.Add(n);
            for (int i = 0; i < n; ++i)
            {
                dataGridView2.Rows[i].Cells["Color"].Value = Birds[i].getColor();
                dataGridView2.Rows[i].Cells["Kind"].Value = Birds[i].getKind();
                dataGridView2.Rows[i].Cells["Wingspan"].Value = Birds[i].getWingspan();
                dataGridView2.Rows[i].Cells["Weight"].Value = Birds[i].getWeight();
            }
        }
        public FormMain()
        {
            InitializeComponent();
            xmlParse();
            load();
            update();
            xmlWrite();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
            add.Close();
            Add.Cats.Clear();
            Add.Birds.Clear();
            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Remove row", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes && Cats.Count != 0)
            {
                int currentRowIndex = dataGridView1.CurrentRow.Index;

                string name = dataGridView1[0, currentRowIndex].Value?.ToString();
                foreach (Cat Catd in Cats)
                {
                    if (Catd.getName() == name)
                    {
                        Cats.Remove(Catd);
                        break;
                    }
                }
                update();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Remove row", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes && Birds.Count != 0)
            {
                int wings = (int)dataGridView2[2, dataGridView2.CurrentCell.RowIndex].Value;
                foreach (Bird Birdss in Birds)
                {
                    if (Birdss.getWingspan() == wings)
                    {
                        Birds.Remove(Birdss);
                        break;
                    }
                }
                update();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex != -1 && e.RowIndex > -1)
            {
                int currentRowIndex = dataGridView1.CurrentRow.Index;

                string name = dataGridView1[0, currentRowIndex].Value?.ToString();
                foreach (Cat Catd in Cats)
                {
                    if (Catd.getName() == name)
                    {
                        Cat PT = Catd;
                        Cats.Remove(Catd);
                        Edit edit = new Edit(PT);
                        edit.ShowDialog();
                        if (Edit.CatTMP != null)
                        {
                            Cats.Add(Edit.CatTMP);
                            Cats.Sort();
                            Edit.CatTMP = null;
                        }
                        else if (Edit.BirdTMP != null)
                        {
                            Birds.Add(Edit.BirdTMP);
                            Birds.Sort();
                            Edit.BirdTMP = null;
                        }
                        edit.Close();
                        break;
                    }
                }
                update();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentCell.RowIndex != -1 && e.RowIndex > -1)
            {
                int wings = (int)dataGridView2[2, dataGridView2.CurrentCell.RowIndex].Value;
                foreach (Bird Birdss in Birds)
                {
                    if (Birdss.getWingspan() == wings)
                    {
                        Bird FT = Birdss;
                        Birds.Remove(Birdss);
                        Edit edit = new Edit(FT);
                        edit.ShowDialog();
                        if (Edit.CatTMP != null)
                        {
                            Cats.Add(Edit.CatTMP);
                            Cats.Sort();
                            Edit.CatTMP = null;
                        }
                        else if (Edit.BirdTMP != null)
                        {
                            Birds.Add(Edit.BirdTMP);
                            Birds.Sort();
                            Edit.BirdTMP = null;
                        }
                        edit.Close();
                        break;
                    }
                }
                update();
            }
        }

        private int Find(string str, string str2)
        {
            var n = str.Length;
            var m = str2.Length;
            var результат = new int[n + m - 1 + m - 1];

            for (int i = 1 - m; i < n + m - 1; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    результат[i + m - 1] += i + j < 0 | i + j >= n ? 1 : str[i + j] == str2[j] ? 0 : 1;
                }
            }

            return результат.Min();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int r = 0;
            if (textBox1.Text.Length != 0)
            {
                for (int i = 0; i < Cats.Count; i++)
                {
                    dataGridView1.Rows[i].Visible = Find(Cats[i].getBreed(), textBox1.Text) <= r;
                }
                for (int i = 0; i < Birds.Count; i++)
                {
                    dataGridView2.Rows[i].Visible = Find(Birds[i].getKind(), textBox1.Text) <= r;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            xmlWrite();
        }
    }
}
