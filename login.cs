﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient; 

namespace BankAdministrationSystem
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

       
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HAMID\Documents\BankDB.mdf;Integrated Security=True;Connect Timeout=30");


        private void resetButton_Click(object sender, EventArgs e)
        {
            
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
            

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "" || passwordTextBox.Text == "")
            {
                MessageBox.Show("Select Both Admin Name and Password");
            }
            else
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from AdminTable where AdminUsername='" + usernameTextBox.Text + "' and AdminPassword='" + passwordTextBox.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    BankAdministraationSyatem obj = new BankAdministraationSyatem();
                    obj.Show();
                    this.Hide();
                    con.Close();
                    
                }
                else
                {
                    MessageBox.Show("Wrong Admin Name and Password");
                    usernameTextBox.Text = "";
                    passwordTextBox.Text = "";
                }
                con.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
