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


namespace loginformapplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=PRUDHVI\SQLEXPRESS;Initial Catalog=loginprogram;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string username, password;
            username = txt_username.Text;
            password = txt_password.Text;

            try
            {
                string queery = "SELECT * FROM logintable WHERE username = '" + txt_username.Text + "' AND password = '" + txt_password.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(queery, conn);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if(dtable.Rows.Count >0)
                {
                    username = txt_username.Text;
                    password = txt_password.Text;
                    menuforms form2 = new menuforms();
                    form2.Show();
                    this.Hide();

                }

                else
                {
                    MessageBox.Show("Invalid details", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_username.Clear();
                    txt_password.Clear();

                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();
        }
    }

    
}
