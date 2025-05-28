using LMS_software.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LMS_software
{
    public partial class Out : Form
    {
        private readonly string booksFile = Path.Combine(Application.StartupPath, "db.txt");
        private readonly string transactionsFile = Path.Combine(Application.StartupPath, "transactions.txt");

        public Out()
        {
            InitializeComponent();
            EnsureTransactionFileExists();
        }

        private void EnsureTransactionFileExists()
        {
            if (!File.Exists(transactionsFile))
            {
                File.Create(transactionsFile).Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentId = textBox1.Text.Trim();
            string isbn = textBox2.Text.Trim();
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string transactionType = "OUT";

            if (string.IsNullOrWhiteSpace(studentId) || string.IsNullOrWhiteSpace(isbn))
            {
                MessageBox.Show("Please enter both Student ID and Book ISBN.");
                return;
            }

            if (!File.Exists(booksFile))
            {
                MessageBox.Show("Book database not found.");
                return;
            }

            List<string> bookLines = File.ReadAllLines(booksFile).ToList();
            bool found = false;

            for (int i = 0; i < bookLines.Count; i++)
            {
                var parts = bookLines[i].Split(',');

                if (parts.Length == 5 && parts[0] == isbn)
                {
                    if (!int.TryParse(parts[3], out int qty))
                    {
                        MessageBox.Show("Invalid book quantity.");
                        return;
                    }

                    if (qty <= 0)
                    {
                        MessageBox.Show("Book is currently unavailable (Qty = 0).");
                        return;
                    }

                    parts[3] = (qty - 1).ToString();
                    parts[4] = int.Parse(parts[3]) == 0 ? "Issued" : "Available";
                    bookLines[i] = string.Join(",", parts);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show("Book not found.");
                return;
            }

            File.WriteAllLines(booksFile, bookLines);

            var transaction = new Transaction
            {
                Timestamp = timestamp,
                StudentID = studentId,
                ISBN = isbn,
                Type = transactionType
            };

            string transactionLine = $"{transaction.Timestamp},{transaction.StudentID},{transaction.ISBN},{transaction.Type}";
            File.AppendAllText(transactionsFile, transactionLine + Environment.NewLine);

            MessageBox.Show("Book OUT transaction recorded and quantity updated.");
            ClearFields();
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
    }
}
