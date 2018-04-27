using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_D_absence
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void refresh()
        {
            this.profTableAdapter.Fill(this.gA.Prof);
            this.matiereTableAdapter.Fill(this.gA.matiere);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            // TODO: This line of code loads data into the 'gA.matiere' table. You can move, or remove it, as needed.
            this.matiereTableAdapter.Fill(this.gA.matiere);
            // TODO: This line of code loads data into the 'gA.Prof' table. You can move, or remove it, as needed.
            this.profTableAdapter.Fill(this.gA.Prof);
            // TODO: This line of code loads data into the 'gA.Prof' table. You can move, or remove it, as needed.
            this.profTableAdapter.Fill(this.gA.Prof);
            radioButton1.Checked = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) { this.profTableAdapter.InsertQuery(textBox1.Text, textBox2.Text, radioButton1.Text, int.Parse(comboBox1.SelectedValue.ToString())); }
            else if (radioButton2.Checked == true) { this.profTableAdapter.InsertQuery(textBox1.Text, textBox2.Text, radioButton2.Text, int.Parse(comboBox1.SelectedValue.ToString())); }
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.profTableAdapter.DeleteQuery(int.Parse(label2.Text)); refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) { this.profTableAdapter.UpdateQuery(textBox1.Text, textBox2.Text, radioButton1.Text, int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(label2.Text)); } 
            else if (radioButton2.Checked == true) { this.profTableAdapter.UpdateQuery(textBox1.Text, textBox2.Text, radioButton2.Text, int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(label2.Text));}
            refresh();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.matiereTableAdapter.InsertQuery(textBox3.Text);
            refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.matiereTableAdapter.DeleteQuery(int.Parse(label1.Text));
            refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.matiereTableAdapter.UpdateQuery(textBox3.Text, int.Parse(label1.Text));
            refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = null;
            textBox3.Clear();  refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();  refresh();

        }
    }
}
