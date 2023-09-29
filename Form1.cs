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

namespace Product_FileIO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\ProdFolder\Product.dat", FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(Convert.ToInt32(txtProdID.Text));
                bw.Write(txtProdName.Text);
                bw.Write(Convert.ToDouble(txtProdPrice.Text));
                bw.Close();
                fs.Close();
                MessageBox.Show("Done");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateDriectory_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\ProdFolder";
                if(Directory.Exists(path))
                {
                    MessageBox.Show("Directory Already Exists");
                }
                else
                {
                    Directory.CreateDirectory(path);
                    MessageBox.Show("Directory Created");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\ProdFolder\Product.dat";
                if (File.Exists(path))
                {
                    MessageBox.Show("File Already Exist");
                }
                else
                {
                    File.Create(path);
                    MessageBox.Show("File Created");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\ProdFolder\Product.dat", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                txtProdID.Text = br.ReadInt32().ToString();
                txtProdName.Text = br.ReadString();
                txtProdPrice.Text = br.ReadDouble().ToString();
                br.Close();
                fs.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStreamWrite_Click(object sender, EventArgs e)
        {
            try
            {
            FileStream fs=new FileStream(@"D:\ProdFolder\Product.dat", FileMode.Create, FileAccess.Write);
                StreamWriter sw=new StreamWriter(fs);
                sw.Write(richTextBox1.Text);
                sw.Close();
                fs.Close();
                MessageBox.Show("Done");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStreamRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\ProdFolder\Product.dat", FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                richTextBox1.Text = sw.ReadToEnd();
                sw.Close();
                fs.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
