using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace notepad
{
	public partial class MainWindow : Form
	{
		string filePath = "";

		public MainWindow()
		{
			InitializeComponent();
		}


		private void New_Click(object sender, EventArgs e)
		{
			string message = "Do you want to save changes in the file?";
			string caption = "Notepad";
			MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
			DialogResult result = new DialogResult();
			if (richTextBox1.Text != "")
			{
				result = MessageBox.Show(message, caption, buttons);

				if (result == DialogResult.Yes)
				{
					Save_Click(sender, e);
				}
				// MessageBox.Show("Do you want to save the file?", "Notepad");
			}
			if (result != DialogResult.Cancel)
			{
				richTextBox1.Clear();
				filePath = "";
			}
			
		}

		private void Open_Click(object sender, EventArgs e)
		{
			/*if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
			}*/
			openFileDialog1.Filter = "txt files (*.txt)|*.txt";
			try
			{
				if (openFileDialog1.ShowDialog() == DialogResult.OK)

				{

					filePath = openFileDialog1.FileName;
					richTextBox1.Text = File.ReadAllText(filePath);
				}
			}
			catch
			{
				MessageBox.Show("Error Reading of TXT-File!");
			}
		}

		private void Save_Click(object sender, EventArgs e)
		{
			if(filePath == "")
			{
				SaveAs_Click(sender, e);
			}
			else
			{
				try
				{
					File.WriteAllText(filePath, richTextBox1.Text);
				}
				catch
				{
					MessageBox.Show("Error Saving of TXT-File!");
				}
			}
		}

		private void SaveAs_Click(object sender, EventArgs e)
		{
			//saveFileDialog1.DefaultExt = ".txt";
			saveFileDialog1.Filter = "txt files (*.txt)|*.txt";//|PDF file|*.pdf|Word File|*.doc
			try
			{
				DialogResult dr = saveFileDialog1.ShowDialog();
				if (dr == DialogResult.OK)
				{
					filePath = saveFileDialog1.FileName;
					File.WriteAllText(filePath, richTextBox1.Text);
				}
			}
			catch
			{
				MessageBox.Show("Error Saving of TXT-File!");
			}
		}

		private void Exit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Font_Click(object sender, EventArgs e)
		{
			if (fontDialog1.ShowDialog() == DialogResult.OK)
			{
				richTextBox1.Font = fontDialog1.Font;
			}
		}

		private void Color_Click(object sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				richTextBox1.ForeColor = colorDialog1.Color;
			}
		}
	}
}
