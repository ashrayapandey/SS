using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleSpreadsheet
{
    public partial class frmSpreadsheet : Form
    {
        TextBox cellsLeave;
        float firstNumber, secondNumber;
        Operations operation = new Operations(); 
        public frmSpreadsheet()
        {
            InitializeComponent();
        }

        private void PanelSpreadsheet_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void FrmSpreadsheet_Load(object sender, EventArgs e)
        {
            LoadSpreadsheet();
        }
        private void LoadSpreadsheet()
        {
            int x = 20, y = 50;
            string[] alphabets = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            for (int i = 1; i < 27; i++)
            {
                int j = 0;
                foreach (var item in alphabets)
                {
                    TextBox cells = new TextBox();
                    cells.Size = new Size(57, 100);
                    cells.Location = new Point(x, y);
                    cells.Name = $"{alphabets[j]}{i}";
                    //cells.Text = cells.Name;
                    cells.Leave += new EventHandler(Cells_Leave);
                    panelSpreadsheet.Controls.Add(cells);
                    j++;
                    x += 58;
                }
                x = 20;
                y += 28;
            }
        }
        private void Cells_Leave(object sender, EventArgs e)
        {
            cellsLeave = sender as TextBox;
            string cellText = cellsLeave.Text.Trim();

            if (cellText.Contains("=SUM"))
            {
                CellFinder(cellText);
                cellsLeave.Text = operation.Sum().ToString();
            }
            else if(cellText.Contains("=MULTI")) 
            {
                CellFinder(cellText);
                cellsLeave.Text = operation.Multiply().ToString();
            }
            else if (cellText.Contains("=MEAN"))
            {
                CellFinder(cellText);
                cellsLeave.Text = operation.Mean().ToString();
            }
            else if (cellText.Contains("=MEDIAN"))
            {
                CellFinder(cellText);
                cellsLeave.Text = operation.Median().ToString();
            }
            else if (cellText.Contains("=MODE"))
            {
                CellFinder(cellText);
                cellsLeave.Text = operation.Mode().ToString();
            }
            else
            {
                MessageBox.Show("Formula Not Found!!!", "Error");
            }
        }
        private void CellFinder(string cellText)
        {
            int length = cellText.Length;
            int colonIndex = cellText.IndexOf(":");
            int spaceIndex = cellText.IndexOf(" ");
            string firstCell = cellText.Substring(spaceIndex + 1, colonIndex - spaceIndex - 1);
            string secondCell = cellText.Substring(colonIndex + 1, length - colonIndex - 1);
            foreach (TextBox textbox in panelSpreadsheet.Controls)
            {
                if (textbox.Name == firstCell)
                {
                    firstNumber = int.Parse(textbox.Text);
                }
                if (textbox.Name == secondCell)
                {
                    secondNumber = int.Parse(textbox.Text);
                }
            }
            operation.FirstNumber = firstNumber;
            operation.SecondNumber = secondNumber;
        }

    }
}
