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
    public partial class Books : Form
    {
        private readonly string dbFilePath = Path.Combine(Application.StartupPath, "db.txt");
        private List<Book> books = new List<Book>();

        public delegate void BookUpdatedEventHandler(object sender, EventArgs e);
        public event BookUpdatedEventHandler BookUpdated;

        public Books()
        {
            InitializeComponent();
            EnsureBooksFileExists();
            _ = LoadBooksAsync();
        }

        private void EnsureBooksFileExists()
        {
            if (!File.Exists(dbFilePath))
            {
                using (StreamWriter writer = File.CreateText(dbFilePath))
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        writer.WriteLine($"ISBN{i:D3},Book Title {i},Author {i},{i + 5},{(i % 2 == 0 ? "Available" : "Issued")}");
                    }
                }
            }
        }

        private async Task LoadBooksAsync()
        {
            await Task.Run(() =>
            {
                books = File.ReadAllLines(dbFilePath)
                            .Where(line => !string.IsNullOrWhiteSpace(line)) // Ignore empty lines
                            .Select(line => line.Split(','))                 // Split by comma
                            .Where(parts => parts.Length == 5)              // Ensure 5 fields
                            .Select(parts =>
                            {
                                int qty = 0;
                                int.TryParse(parts[3], out qty);            // Safely parse quantity

                                return new Book
                                {
                                    ISBN = parts[0].Trim(),
                                    Name = parts[1].Trim(),
                                    Author = parts[2].Trim(),
                                    Qty = qty,
                                    Availability = parts[4].Trim()
                                };
                            })
                            .ToList();
            });

            UpdateGrid();
        }


        private void UpdateGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ISBN");
            dt.Columns.Add("Name");
            dt.Columns.Add("Author");
            dt.Columns.Add("Qty");
            dt.Columns.Add("Availability");

            foreach (var book in books)
            {
                dt.Rows.Add(book.ISBN, book.Name, book.Author, book.Qty.ToString(), book.Availability);
            }

            dataGridView1.DataSource = dt;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.Padding = new Padding(5);
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }

        private void SaveBooks()
        {
            using (StreamWriter writer = new StreamWriter(dbFilePath, false))
            {
                foreach (var book in books)
                {
                    writer.WriteLine($"{book.ISBN},{book.Name},{book.Author},{book.Qty},{book.Availability}");
                }
            }

            OnBookUpdated();
        }

        private void OnBookUpdated()
        {
            BookUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var isbn = textBox1.Text.Trim();
            var name = textBox2.Text.Trim();
            var author = textBox3.Text.Trim();
            var qtyText = textBox4.Text.Trim();

            if (string.IsNullOrWhiteSpace(isbn) || string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(qtyText))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            if (!int.TryParse(qtyText, out int qty))
            {
                MessageBox.Show("Quantity must be a number.");
                return;
            }

            if (books.Any(b => b.ISBN == isbn))
            {
                MessageBox.Show("ISBN already exists.");
                return;
            }

            books.Add(new Book
            {
                ISBN = isbn,
                Name = name,
                Author = author,
                Qty = qty,
                Availability = "Available"
            });

            SaveBooks();
            UpdateGrid();
            MessageBox.Show("Book Added Successfully!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string isbn = textBox1.Text.Trim();
            var book = books.FirstOrDefault(b => b.ISBN == isbn);

            if (book == null)
            {
                MessageBox.Show("Book not found.");
                return;
            }

            book.Name = textBox2.Text.Trim();
            book.Author = textBox3.Text.Trim();
            if (int.TryParse(textBox4.Text.Trim(), out int qty))
                book.Qty = qty;

            SaveBooks();
            UpdateGrid();
            MessageBox.Show("Book Updated Successfully!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string isbn = textBox1.Text.Trim();
            var book = books.FirstOrDefault(b => b.ISBN == isbn);

            if (book == null)
            {
                MessageBox.Show("Book not found.");
                return;
            }

            books.Remove(book);
            SaveBooks();
            UpdateGrid();
            MessageBox.Show("Book Deleted!");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["ISBN"].Value.ToString();
                textBox2.Text = row.Cells["Name"].Value.ToString();
                textBox3.Text = row.Cells["Author"].Value.ToString();
                textBox4.Text = row.Cells["Qty"].Value.ToString();
            }
        }

        // Optional handlers
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}
