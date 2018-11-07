using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeuBlocodeNotas1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textoTbx.Text = "";
            DialogResult resultado = openFileDialog1.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                 String nomeDoFile = openFileDialog1.FileName;
                Stream entrada = File.Open(nomeDoFile, FileMode.Open);
                StreamReader leitor = new StreamReader(entrada);
               // string linha = leitor.ReadLine();
                string linha = "";
                while ((linha = leitor.ReadLine()) != null)
                {
                    textoTbx.AppendText(linha);
                    textoTbx.AppendText(Environment.NewLine);
                }
                leitor.Close();
                entrada.Close();

            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String nomeDoArquivo = openFileDialog1.FileName;
            Stream saida = File.Open(nomeDoArquivo, FileMode.Create);
            StreamWriter escritor = new StreamWriter(saida);
            escritor.WriteLine(textoTbx.Text);
            escritor.Close();
                saida.Close();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if( MessageBox.Show("Deseja sair ?","Sair",
                MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
    
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Arquivo Texto|*.txt";
            sfd.ShowDialog();
            if(string.IsNullOrEmpty(sfd.FileName)== false)
            {
                using (StreamWriter writer = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                {
                    writer.Write(textoTbx.Text);
                }
            }


        }

        private void corDeFundoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult colorResult = colorDialog1.ShowDialog();
            if (colorResult== DialogResult.OK)
            {
              textoTbx.BackColor = colorDialog1.Color;
            }
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult fontResult = FontDialog1.ShowDialog();
            if (fontResult == DialogResult.OK)
            { 

                textoTbx.Font = FontDialog1.Font;
            }


        }

        private void corDaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult fontResult = colorDialog1.ShowDialog();
            if (fontResult == DialogResult.OK)
            {

                textoTbx.ForeColor = colorDialog1.Color;
            }
        }
    }
}
