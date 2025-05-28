using LMS_software.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS_software
{
    public partial class members : Form
    {
        private readonly string dbFilePath = Path.Combine(Application.StartupPath, "members.txt");
        private List<Member> membersList = new List<Member>();

        public members()
        {
            InitializeComponent();
            EnsureFileExists();
            _ = LoadMembersAsync();
        }

        private void EnsureFileExists()
        {
            if (!File.Exists(dbFilePath))
            {
                using (StreamWriter writer = File.CreateText(dbFilePath))
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        string id = $"STD{i:D3}";
                        string name = $"Member {i}";
                        string email = $"member{i}@mail.com";
                        string contact = $"07712345{i}";
                        writer.WriteLine($"{id},{name},{email},{contact}");
                    }
                }
            }
        }

        private async Task LoadMembersAsync()
        {
            await Task.Run(() =>
            {
                membersList = File.ReadAllLines(dbFilePath)
                                  .Select(line =>
                                  {
                                      var parts = line.Split(',');
                                      return new Member
                                      {
                                          StudentID = parts[0],
                                          Name = parts[1],
                                          Email = parts[2],
                                          Contact = parts[3]
                                      };
                                  }).ToList();
            });

            DisplayMembers();
        }

        private void DisplayMembers()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("StudentID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Email");
            dt.Columns.Add("Contact");

            foreach (var m in membersList)
                dt.Rows.Add(m.StudentID, m.Name, m.Email, m.Contact);

            dataGridView1.DataSource = dt;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DefaultCellStyle.Padding = new Padding(5);
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void SaveMembers()
        {
            using (StreamWriter writer = new StreamWriter(dbFilePath, false))
            {
                foreach (var m in membersList)
                {
                    writer.WriteLine($"{m.StudentID},{m.Name},{m.Email},{m.Contact}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentId = textBox4.Text.Trim();
            string name = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string contact = textBox3.Text.Trim();

            if (string.IsNullOrWhiteSpace(studentId) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Student ID and Name are required.");
                return;
            }

            if (membersList.Any(m => m.StudentID == studentId))
            {
                MessageBox.Show("Student ID already exists.");
                return;
            }

            membersList.Add(new Member
            {
                StudentID = studentId,
                Name = name,
                Email = email,
                Contact = contact
            });

            SaveMembers();
            DisplayMembers();
            ClearFields();
            MessageBox.Show("Member added successfully!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string studentId = textBox4.Text.Trim();
            var member = membersList.FirstOrDefault(m => m.StudentID == studentId);

            if (member == null)
            {
                MessageBox.Show("Member not found.");
                return;
            }

            member.Name = textBox1.Text.Trim();
            member.Email = textBox2.Text.Trim();
            member.Contact = textBox3.Text.Trim();

            SaveMembers();
            DisplayMembers();
            ClearFields();
            MessageBox.Show("Member updated successfully!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string studentId = textBox4.Text.Trim();
            var member = membersList.FirstOrDefault(m => m.StudentID == studentId);

            if (member == null)
            {
                MessageBox.Show("Member not found.");
                return;
            }

            membersList.Remove(member);
            SaveMembers();
            DisplayMembers();
            ClearFields();
            MessageBox.Show("Member deleted successfully!");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox4.Text = row.Cells["StudentID"].Value.ToString();
                textBox1.Text = row.Cells["Name"].Value.ToString();
                textBox2.Text = row.Cells["Email"].Value.ToString();
                textBox3.Text = row.Cells["Contact"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        // Optional empty handlers
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}
