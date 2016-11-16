using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace loginpage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int _failedLoginCounter = 0;

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_click(object sender, MouseEventArgs e)
        {
              var username = UserId.Text;
              var password = Password.Text;

             if (string.IsNullOrEmpty(username))
             {
                  MessageBox.Show("Please type your Username");
                  UserId.Focus();
                 return;
            }

             if (string.IsNullOrEmpty(password))
             {
                  MessageBox.Show("Please type your Password");
                  Password.Focus();
                  return;
             }

            // Seperate the login check and make it lously coupled from the UI (= do not refer to the UI elements, instead pass the values to a method)
            CheckLogin(username, password);
            Password.Clear();
       }

        private void CheckLogin(string username, string password)
        {
            try
            {
                string constring = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\Nida\Off Board\Learning\Github\login\Login.accdb;";

                // You need to use a using statement since OleDbConnection implements IDisposable
                // more inf: http://msdn.microsoft.com/en-us/library/system.data.oledb.oledbconnection(v=vs.110).aspx
                using (OleDbConnection conDataBase = new OleDbConnection(constring))
                {
                    // You need to use a using statement since OleDbCommand implements IDisposable
                    // more info: http://msdn.microsoft.com/en-us/library/system.data.oledb.oledbcommand(v=vs.110).aspx
                    using (OleDbCommand cmdDataBase = conDataBase.CreateCommand())
                    {
                        cmdDataBase.CommandText =
                            "SELECT * FROM user_details WHERE UserId=@username AND Passcode = @password";

                        cmdDataBase.Parameters.AddRange(new OleDbParameter[]
                {
                    new OleDbParameter("@username", username),
                    new OleDbParameter("@password", password)
                });

                        // Open database if not open
                        if (conDataBase.State != ConnectionState.Open)
                            conDataBase.Open();

                        var numberOrResults = 0;

                        // You need to use a using statement since OleDbDataReader inherits DbDataReader which implements IDisposable
                        // more info: http://msdn.microsoft.com/en-us/library/system.data.common.dbdatareader(v=vs.110).aspx
                        using (OleDbDataReader myReader = cmdDataBase.ExecuteReader())
                        {
                            while (myReader != null && myReader.Read())
                            {
                                numberOrResults++;
                            }
                        }

                        // If only one result was returned by the database => Succesful login
                        if (numberOrResults == 1)
                        {
                            MessageBox.Show("Login Successful");
                            this.Hide();
                            Form2 loginsuccess = new Form2();
                            loginsuccess.Show();
                        }

                        // If more than 1 result was returned by the database => Failed login
                        // This is not a good idea, this situation should never occor.
                        // Always make sure username + pass (or whatever you use for authentication) is unique.
                        else if (numberOrResults > 1)
                        {
                            MessageBox.Show("Duplicate Username or Password");
                            // increment the failed login counter
                            _failedLoginCounter++;
                        }
                        // No match was found in te database => Failed login
                        else if (numberOrResults == 0)
                        {
                            MessageBox.Show("Username or Password do not match");
                            // increment the failed login counter
                            _failedLoginCounter++;
                        }
                    }

                }

                // If the user has 3 failed login attempts on a row => close.
                if (_failedLoginCounter >= 3)
                {
                    MessageBox.Show("Three incorrect attempt. Account Locked!!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void password_click(object sender, EventArgs e)
        {
            Password.UseSystemPasswordChar = true;
        }

        private void userid_click(object sender, EventArgs e)
        {

        }

        private void password_click(object sender, MouseEventArgs e)
        {
            Password.UseSystemPasswordChar = true;
        }
    }
}




