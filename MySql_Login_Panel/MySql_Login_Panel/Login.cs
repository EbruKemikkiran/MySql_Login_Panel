using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;




namespace MySql_Login_Panel
{
    public partial class Login : Form
    {
        Method mth = new Method();
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txtPassword.Focus();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            #region login panel made it with MySql connection and filtering by customer.           
            string constr = "SERVER=localhost; DATABASE=sales; UID=root; PWD=1234";
            using (var connect = new MySqlConnection(constr))
            {
                using (var cmd = new MySqlCommand("SELECT customer FROM sales ORDER BY customer ASC", connect))
                {
                    try
                    {
                        cmd.Connection.Open();
                        MySqlDataReader dt =cmd.ExecuteReader();
                        while (dt.Read())
                        {
                            comboUsers.Items.Add(dt["customer"].ToString());
                        }
                        comboUsers.SelectedIndex = 0;
                       
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }
        
                }
            }
            #endregion
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(mth.UserControl(comboUsers.SelectedItem.ToString(),txtPassword.Text)==1 )
            {
                //MessageBox.Show("Connected Successful","Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm af = new MainForm();
                af.lblUsers.Text = this.comboUsers.SelectedItem.ToString();
                af.Text = "Welcome," +this.comboUsers.SelectedItem.ToString();
                this.Hide();
                af.Show();
            }
            else 
            { 
                MessageBox.Show("Connection Failured","Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}





