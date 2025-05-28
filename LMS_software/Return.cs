using LMS_software.Models;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LMS_software
{
    public partial class Return : Form
    {
        private readonly string booksFile = Path.Combine(Application.StartupPath, "db.txt");
        private readonly string transactionsFile = Path.Combine(Application.StartupPath, "transactions.txt");

        public Return()
        {
            InitializeComponent();
            EnsureTransactionFileExists();
        }

        private void EnsureTransactionFileExists()
        {
            if (!File.Exists(transactionsFile))
                File.Create(transactionsFile).Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string bookId = textBox1.Text.Trim();
            string studentId = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(bookId) || string.IsNullOrWhiteSpace(studentId))
            {
                MessageBox.Show("Enter both Book ID and Student ID.");
                return;
            }

            var lastOut = File.ReadAllLines(transactionsFile)
                .Reverse()
                .Select(line => line.Split(','))
                .Where(parts => parts.Length == 4 &&
                                parts[1] == studentId &&
                                parts[2] == bookId &&
                                parts[3] == "OUT")
                .FirstOrDefault();

            if (lastOut == null)
            {
                MessageBox.Show("No OUT record found for this student and book.");
                textBox3.Clear();
                textBox4.Clear();
                return;
            }

            DateTime outDate = DateTime.Parse(lastOut[0]);
            textBox3.Text = outDate.ToString("yyyy-MM-dd");

            int lateDays = (DateTime.Now - outDate).Days - 14;
            int lateFee = lateDays > 0 ? lateDays * 10 : 0;
            textBox4.Text = lateFee.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bookId = textBox1.Text.Trim();
            string studentId = textBox2.Text.Trim();
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (string.IsNullOrWhiteSpace(bookId) || string.IsNullOrWhiteSpace(studentId))
            {
                MessageBox.Show("Enter both Book ID and Student ID.");
                return;
            }

            // Append RETURN transaction
            string returnLine = $"{currentDate},{studentId},{bookId},RETURN";
            File.AppendAllText(transactionsFile, returnLine + Environment.NewLine);

            // Update book quantity
            var bookLines = File.ReadAllLines(booksFile).ToList();
            for (int i = 0; i < bookLines.Count; i++)
            {
                var parts = bookLines[i].Split(',');

                if (parts.Length == 5 && parts[0] == bookId)
                {
                    if (int.TryParse(parts[3], out int qty))
                    {
                        qty += 1;
                        parts[3] = qty.ToString();
                        parts[4] = "Available";
                        bookLines[i] = string.Join(",", parts);
                    }
                    break;
                }
            }

            File.WriteAllLines(booksFile, bookLines);

            MessageBox.Show("Book returned successfully! Quantity updated.");

            ClearFields();
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
    }
}
