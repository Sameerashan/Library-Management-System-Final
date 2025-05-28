using LMS_software.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS_software
{
    public partial class Home : Form
    {
        private readonly string dbFilePath = Path.Combine(Application.StartupPath, "db.txt");
        private List<Book> books = new List<Book>();

        public Home()
        {
            InitializeComponent();
            LoadBooksAsync();
        }

        private async void LoadBooksAsync()
        {
            await Task.Run(() =>
            {
                EnsureBooksFileExists();

                try
                {
                    books = File.ReadAllLines(dbFilePath)
                                .Where(line => !string.IsNullOrWhiteSpace(line))
                                .Select(line => line.Split(','))
                                .Where(parts => parts.Length == 5)
                                .Select(parts =>
                                {
                                    int qty = 0;
                                    int.TryParse(parts[3], out qty);

                                    return new Book
                                    {
                                        ISBN = parts[0].Trim(),
                                        Name = parts[1].Trim(),
                                        Author = parts[2].Trim(),
                                        Qty = qty,
                                        Availability = parts[4].Trim()
                                    };
                                })
                                // Optional: only show Available books
                                //.Where(b => b.Availability.Equals("Available", StringComparison.OrdinalIgnoreCase))
                                .OrderBy(b => b.Author)
                                .ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading books: " + ex.Message);
                }
            });

            DisplayBooks();
        }

        private void DisplayBooks()
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = 0;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));

            tableLayoutPanel1.Controls.Add(CreateLabel("ISBN", true), 0, 0);
            tableLayoutPanel1.Controls.Add(CreateLabel("Name", true), 1, 0);
            tableLayoutPanel1.Controls.Add(CreateLabel("Author", true), 2, 0);
            tableLayoutPanel1.Controls.Add(CreateLabel("Qty", true), 3, 0);
            tableLayoutPanel1.Controls.Add(CreateLabel("Availability", true), 4, 0);

            int row = 1;
            foreach (var book in books)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutPanel1.Controls.Add(CreateLabel(book.ISBN), 0, row);
                tableLayoutPanel1.Controls.Add(CreateLabel(book.Name), 1, row);
                tableLayoutPanel1.Controls.Add(CreateLabel(book.Author), 2, row);
                tableLayoutPanel1.Controls.Add(CreateLabel(book.Qty.ToString()), 3, row);
                tableLayoutPanel1.Controls.Add(CreateLabel(book.Availability), 4, row);
                row++;
            }
        }

        private void EnsureBooksFileExists()
        {
            // Always overwrite for testing/demo
            using (StreamWriter writer = new StreamWriter(dbFilePath, false))
            {
                for (int i = 1; i <= 20; i++)
                {
                    string isbn = $"ISBN{i:D3}";
                    string name = $"Book Title {i}";
                    string author = $"Author {i}";
                    int qty = i + 5;
                    string availability = (i % 2 == 0) ? "Available" : "Issued";
                    writer.WriteLine($"{isbn},{name},{author},{qty},{availability}");
                }
            }
        }

        private Label CreateLabel(string text, bool isHeader = false)
        {
            return new Label
            {
                Text = text,
                Font = isHeader ? new Font("Segoe UI", 11, FontStyle.Bold) : new Font("Segoe UI", 10),
                ForeColor = isHeader ? Color.White : Color.Black,
                BackColor = isHeader ? Color.SteelBlue : Color.Transparent,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5),
                AutoSize = true
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Books booksForm = new Books();
            booksForm.BookUpdated += (s, args) => LoadBooksAsync();
            booksForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            members mem = new members();
            mem.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Out u = new Out();
            u.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Return re = new Return();
            re.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}
