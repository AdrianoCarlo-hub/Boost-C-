using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace visual_Sudio2012
{
    public partial class Form1 : Form
    {
        SqlConnection cnx;
        SqlCommand cmd;
        SqlDataReader dr;
        public Form1()
        {
            cnx = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=N:\Programme_Visual_Studio\AprojetC#\visual_Sudio2012\visual_Sudio2012\Etudiant.mdf;Integrated Security=True");
            InitializeComponent();
            cnx.Open();
            cmd = new SqlCommand("Select*from etudiant", cnx);
            dr = cmd.ExecuteReader();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Nom", "Nom");
            dataGridView1.Columns.Add("Prenom", "Prenom");
            dataGridView1.Columns.Add("Age", "Age");
            int i = 0;
            while (dr.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["Id"];
                dataGridView1.Rows[i].Cells[1].Value = dr["Nom"];
                dataGridView1.Rows[i].Cells[2].Value = dr["Prenom"];
                dataGridView1.Rows[i].Cells[3].Value = dr["Age"];
                i++;
            }
            dr.Dispose();
            cnx.Close(); 
            actualiser();
              
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            cnx.Open();

            string sql = "INSERT INTO Etudiant (Nom, Prenom, Age) VALUES (@nom, @prenom, @age)";
            SqlCommand cmd = new SqlCommand(sql, cnx);
            cmd.Parameters.AddWithValue("@nom", textBoxNom.Text);
            cmd.Parameters.AddWithValue("@prenom", textBoxPrenom.Text);
            cmd.Parameters.AddWithValue("@age", textBoxAge.Text);
            cmd.ExecuteNonQuery();

            cnx.Close();
            actualiser(); 
            videLesChamps(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBoxId.Text = row.Cells["Id"].Value.ToString();
                textBoxNom.Text = row.Cells["Nom"].Value.ToString();
                textBoxPrenom.Text = row.Cells["Prenom"].Value.ToString();
                textBoxAge.Text = row.Cells["Age"].Value.ToString();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Supprimer_Click(object sender, EventArgs e)
        {
            cnx.Open();
            SqlCommand cmd = new SqlCommand("Delete from etudiant where Id = @id", cnx);
            cmd.Parameters.AddWithValue("@id", textBoxId.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Suppression réussi!");
            cnx.Close();
            actualiser();
            videLesChamps();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cnx.Open();
            SqlCommand cmd = new SqlCommand("Update etudiant set Nom = @nom, Prenom = @prenom, Age = @age where Id = @id", cnx);
            cmd.Parameters.AddWithValue("@id", textBoxId.Text);
            cmd.Parameters.AddWithValue("@nom", textBoxNom.Text);
            cmd.Parameters.AddWithValue("@prenom", textBoxPrenom.Text);
            cmd.Parameters.AddWithValue("@age", textBoxAge.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Modification réussi!");
            cnx.Close();
            actualiser();
            videLesChamps();
        }
        private void videLesChamps(){
            textBoxId.Text = "";
            textBoxNom.Text = "";
            textBoxPrenom.Text = "";
            textBoxAge.Text = "";
        }
        private void actualiser()
        {
            cnx.Open();
            cmd = new SqlCommand("Select*from etudiant", cnx);
            dr = cmd.ExecuteReader();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Nom", "Nom");
            dataGridView1.Columns.Add("Prenom", "Prenom");
            dataGridView1.Columns.Add("Age", "Age");
            int i = 0;
            while (dr.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["Id"];
                dataGridView1.Rows[i].Cells[1].Value = dr["Nom"];
                dataGridView1.Rows[i].Cells[2].Value = dr["Prenom"];
                dataGridView1.Rows[i].Cells[3].Value = dr["Age"];
                i++;
            }
            dr.Dispose();
            cnx.Close();
        }

    }
    
}

