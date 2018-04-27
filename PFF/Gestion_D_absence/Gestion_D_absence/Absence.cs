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
    public partial class Absence : Form
    {
        public Absence()
        {
            InitializeComponent();
        }
        public void refresh()
        {   
        
            this.absenceTableAdapter.Fill(this.gA.Absence);
            this.profTableAdapter.Fill(this.gA.Prof);
            this.stagiareTableAdapter.Fill(this.gA.Stagiare);
         
        }

        private void Absence_Load(object sender, EventArgs e)
        {
            //RA.Checked = true;
            // TODO: This line of code loads data into the 'gA.Prof' table. You can move, or remove it, as needed.
            this.profTableAdapter.Fill(this.gA.Prof);
            // TODO: This line of code loads data into the 'gA.Stagiare' table. You can move, or remove it, as needed.
            this.stagiareTableAdapter.Fill(this.gA.Stagiare);
            // TODO: This line of code loads data into the 'gA.Absence' table. You can move, or remove it, as needed.
            this.absenceTableAdapter.Fill(this.gA.Absence);





        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            { this.absenceTableAdapter.InsertQuery(dateTimePicker1.Value.ToShortDateString(), textBox1.Text, int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox2.SelectedValue.ToString()), radioButton1.Text);}
            else if (radioButton2.Checked == true) { this.absenceTableAdapter.InsertQuery(dateTimePicker1.Value.ToShortDateString(), textBox1.Text, int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox2.SelectedValue.ToString()), radioButton2.Text); }
            this.absenceTableAdapter.Fill(this.gA.Absence);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.absenceTableAdapter.DeleteQuery(int.Parse(label1.Text));
            this.absenceTableAdapter.Fill(this.gA.Absence);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            { this.absenceTableAdapter.UpdateQuery(dateTimePicker1.Value.ToShortDateString(), textBox1.Text, int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox2.SelectedValue.ToString()), radioButton1.Text,int.Parse(label1.Text)); }
            else if (radioButton2.Checked == true)
            {
              this.absenceTableAdapter.UpdateQuery(dateTimePicker1.Value.ToShortDateString(), textBox1.Text, int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox2.SelectedValue.ToString()), radioButton2.Text,int.Parse(label1.Text));
            }
            this.absenceTableAdapter.Fill(this.gA.Absence);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.absenceTableAdapter.FillBySta(this.gA.Absence, int.Parse(comboBox1.SelectedValue.ToString()));
                label2.Visible = true;
                int nbAbs = (int)this.absenceTableAdapter.CountAbsSta(int.Parse(comboBox1.SelectedValue.ToString()));
                label2.Text = "Le Stagiaire :  " + comboBox1.DisplayMember.ToString() + "  à  " + nbAbs.ToString() + " Absence";
            }
            catch { MessageBox.Show("se Stagiare a aucune absence","info"); }
          
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.absenceTableAdapter.FillByProf(this.gA.Absence, int.Parse(comboBox2.SelectedValue.ToString()));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.absenceTableAdapter.FillByDate(this.gA.Absence, dateTimePicker1.Value.ToShortDateString());
          
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void stagiaireGroupeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SG SGf = new SG();
            SGf.ShowDialog();
        }

        private void professeurmatiereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 PMf = new Form1();
            PMf.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                this.absenceTableAdapter.FillByJus(this.gA.Absence, radioButton1.Text);
            else if (radioButton2.Checked==true) this.absenceTableAdapter.FillByJus(this.gA.Absence, radioButton2.Text);
        }

        private void iNFOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            INFO info = new INFO();
            info.ShowDialog();
        }
    }
}
