using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LMS_software
{
    public partial class login : Form
    {
        private readonly string loginFilePath = Path.Combine(Application.StartupPath, "login.txt");

        public login()
        {
            InitializeComponent();
            EnsureLoginFileExists();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both email and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(loginFilePath))
            {
                MessageBox.Show("Login database not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var credentials = File.ReadAllLines(loginFilePath)
                                  .Select(line => line.Split(','))
                                  .FirstOrDefault(parts => parts.Length == 2 && parts[0] == email && parts[1] == password);

            if (credentials != null)
            {
                MessageBox.Show("Login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Home homeForm = new Home();
                homeForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid credentials. Try again.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnsureLoginFileExists()
        {
            try
            {
                if (!File.Exists(loginFilePath))
                {
                    using (StreamWriter writer = File.CreateText(loginFilePath))
                    {
                        writer.WriteLine("test@gmail.com,admin@123");
                    }
                }
                else
                {
                    bool hasDefaultUser = File.ReadAllLines(loginFilePath)
                                              .Any(line => line.StartsWith("test@gmail.com,"));

                    if (!hasDefaultUser)
                    {
                        File.AppendAllText(loginFilePath, "test@gmail.com,admin@123" + Environment.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ensuring login file: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
    }
}
