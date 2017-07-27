using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garment_Files_Generator
{
    public partial class GFG : Form
    {   
        public GFG()
        {
            InitializeComponent();
        }

        private void buttonSPR_Click(object sender, EventArgs e)
        {
            var SPRF = new System.Windows.Forms.OpenFileDialog();
            SPRF.Filter = "SPR Files|*.spr";
            if (SPRF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = SPRF.FileName;
                System.IO.FileInfo File = new System.IO.FileInfo(SPRF.FileName);
                System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);
                textBoxSPR.Text = SPRF.FileName;
            }
        }

        private void buttonACT_Click(object sender, EventArgs e)
        {
            var ACTF = new System.Windows.Forms.OpenFileDialog();
            ACTF.Filter = "ACT Files|*.act";
            if (ACTF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = ACTF.FileName;
                System.IO.FileInfo File = new System.IO.FileInfo(ACTF.FileName);
                System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);
                textBoxACT.Text = ACTF.FileName;
            }
        }
        private void ButtonGENERATE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Input Garment file name.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxGName.Text))
            {
                MessageBox.Show("Input Garment name.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxSPR.Text))
            {
                MessageBox.Show("Import the main Spirt file");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxACT.Text))
            {
                MessageBox.Show("Import the main Act file");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxSPRd.Text))
            {
                MessageBox.Show("Import the Drop Spirt file");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxACTd.Text))
            {
                MessageBox.Show("Import the Drop Act file");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxitm.Text))
            {
                MessageBox.Show("Import the Item BMP file");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxcoll.Text))
            {
                MessageBox.Show("Import the Collection BMP file");
                return;
            }
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            var G_FILENAME = textBoxName.Text;
            var G_INGAME = textBoxGName.Text;
            var SPRFR = textBoxSPR.Text;
            var ACTFR = textBoxACT.Text;
            var SPRFRd = textBoxSPRd.Text;
            var ACTFRd = textBoxACTd.Text;
            var itmbmp = textBoxitm.Text;
            var collbmp = textBoxcoll.Text;
            string pathdatam = path + @"\data\sprite\로브\" + G_FILENAME+ @"\남";
            string pathdataf = path + @"\data\sprite\로브\" + G_FILENAME + @"\여";
            string pathdatal = path + @"\data\sprite\아이템";
            string pathdatai = path + @"\data\texture\유저인터페이스\item";
            string pathdatac = path + @"\data\texture\유저인터페이스\collection";
            if (!Directory.Exists(pathdatam)) {
                DirectoryInfo DATAFm = Directory.CreateDirectory(pathdatam);
            }
            if (!Directory.Exists(pathdataf))
            {
                DirectoryInfo DATAFf = Directory.CreateDirectory(pathdataf);
            }
            if (!Directory.Exists(pathdatal))
            {
                DirectoryInfo DATAFl = Directory.CreateDirectory(pathdatal);
            }
            if (!Directory.Exists(pathdatai))
            {
                DirectoryInfo DATAFi = Directory.CreateDirectory(pathdatai);
            }
            if (!Directory.Exists(pathdatac))
            {
                DirectoryInfo DATAFc = Directory.CreateDirectory(pathdatac);
            }
            System.IO.File.Copy(SPRFRd, path + @"\data\sprite\아이템\" + G_FILENAME + ".spr" , true);
            System.IO.File.Copy(ACTFRd, path + @"\data\sprite\아이템\" + G_FILENAME + ".act", true);
            System.IO.File.Copy(itmbmp, path + @"\data\texture\유저인터페이스\item\" + G_FILENAME + ".bmp" , true);
            System.IO.File.Copy(collbmp, path + @"\data\texture\유저인터페이스\collection\" + G_FILENAME + ".bmp", true);
            for (int i = 0; i < KroNames.boy.Length; i++)
            {
                System.IO.File.Copy(SPRFR, path + @"\data\sprite\로브\" + G_FILENAME + @"\남\" + KroNames.boy[i] + ".spr", true);
                System.IO.File.Copy(ACTFR, path + @"\data\sprite\로브\" + G_FILENAME + @"\남\" + KroNames.boy[i] + ".act", true);

                System.IO.File.Copy(SPRFR, path + @"\data\sprite\로브\" + G_FILENAME + @"\여\" + KroNames.girl[i] + ".spr", true);
                System.IO.File.Copy(ACTFR, path + @"\data\sprite\로브\" + G_FILENAME + @"\여\" + KroNames.girl[i] + ".act", true);
            }
            textBoxinfo.Text += "------------------------------------------------------" + Environment.NewLine;
            textBoxinfo.Text += "==================================" + Environment.NewLine;
            textBoxinfo.Text += "------------------------------------------------------" + Environment.NewLine;
            textBoxinfo.Text += "iteminfo.lua/iteminfo.lub :" + Environment.NewLine;
            textBoxinfo.Text += "[<ItemID>] = {" + Environment.NewLine;
            textBoxinfo.Text += "   unidentifiedDisplayName = \"" + G_INGAME + "\"," + Environment.NewLine;
            textBoxinfo.Text += "   unidentifiedResourceName = \"" + G_FILENAME + "\"," + Environment.NewLine;
            textBoxinfo.Text += "   unidentifiedDescriptionName = {" + Environment.NewLine;
            textBoxinfo.Text += "       \"Description\"," + Environment.NewLine;
            textBoxinfo.Text += "       \"^ffffff_^000000\"," + Environment.NewLine;
            textBoxinfo.Text += "       \"Weight: ^7777777^000000\"," + Environment.NewLine;
            textBoxinfo.Text += "   }," + Environment.NewLine;
            textBoxinfo.Text += "   identifiedDisplayName = = \"" + G_INGAME + "\"," + Environment.NewLine;
            textBoxinfo.Text += "   identifiedResourceName = \"" + G_FILENAME + "\"," + Environment.NewLine;
            textBoxinfo.Text += "   identifiedDescriptionName = {" + Environment.NewLine;
            textBoxinfo.Text += "       \"Description\"," + Environment.NewLine;
            textBoxinfo.Text += "       \"^ffffff_^000000\"," + Environment.NewLine;
            textBoxinfo.Text += "       \"Weight: ^7777777^000000\"," + Environment.NewLine;
            textBoxinfo.Text += "   }," + Environment.NewLine;
            textBoxinfo.Text += "   slotCount = 0," + Environment.NewLine;
            textBoxinfo.Text += "   ClassNum = <ViewID>" + Environment.NewLine;
            textBoxinfo.Text += "}," + Environment.NewLine;
            textBoxinfo.Text += "------------------------------------------------------" + Environment.NewLine;
            textBoxinfo.Text += "spriterobename.lua/spriterobename.lub :" + Environment.NewLine;
            textBoxinfo.Text += "RobeNameTable = {" + Environment.NewLine;
            textBoxinfo.Text += "   [SPRITE_ROBE_IDs.ROBE_SwordWing] = \"" + G_FILENAME + "\"" + Environment.NewLine;
            textBoxinfo.Text += "}" + Environment.NewLine;
            textBoxinfo.Text += "RobeNameTable_Eng = {" + Environment.NewLine;
            textBoxinfo.Text += "   [SPRITE_ROBE_IDs.ROBE_" + G_FILENAME + "] = \"" + G_FILENAME + "\"" + Environment.NewLine;
            textBoxinfo.Text += "}" + Environment.NewLine;
            textBoxinfo.Text += "------------------------------------------------------" + Environment.NewLine;
            textBoxinfo.Text += "spriterobeid.lua/spriterobeid.lub :" + Environment.NewLine;
            textBoxinfo.Text += "SPRITE_ROBE_IDs = {" + Environment.NewLine;
            textBoxinfo.Text += "   ROBE_" + G_FILENAME + " = <ViewID>" + Environment.NewLine;
            textBoxinfo.Text += "}" + Environment.NewLine;
            textBoxinfo.Text += "------------------------------------------------------" + Environment.NewLine;
            textBoxinfo.Text += " " + Environment.NewLine;
            MessageBox.Show("Done");
            
        }

        private void textBoxSPRd_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSPRd_Click(object sender, EventArgs e)
        {
            var SPRFd = new System.Windows.Forms.OpenFileDialog();
            SPRFd.Filter = "SPR Files|*.spr";
            if (SPRFd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = SPRFd.FileName;
                System.IO.FileInfo File = new System.IO.FileInfo(SPRFd.FileName);
                System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);
                textBoxSPRd.Text = SPRFd.FileName;
            }
        }

        private void buttonACTd_Click(object sender, EventArgs e)
        {
            var ACTFd = new System.Windows.Forms.OpenFileDialog();
            ACTFd.Filter = "ACT Files|*.act";
            if (ACTFd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = ACTFd.FileName;
                System.IO.FileInfo File = new System.IO.FileInfo(ACTFd.FileName);
                System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);
                textBoxACTd.Text = ACTFd.FileName;
            }
        }

        private void buttonitm_Click(object sender, EventArgs e)
        {
            var itmbmp = new System.Windows.Forms.OpenFileDialog();
            itmbmp.Filter = "BMP Files|*.bmp";
            if (itmbmp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = itmbmp.FileName;
                System.IO.FileInfo File = new System.IO.FileInfo(itmbmp.FileName);
                System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);
                textBoxitm.Text = itmbmp.FileName;
            }
        }

        private void buttoncoll_Click(object sender, EventArgs e)
        {
            var collbmp = new System.Windows.Forms.OpenFileDialog();
            collbmp.Filter = "BMP Files|*.bmp";
            if (collbmp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = collbmp.FileName;
                System.IO.FileInfo File = new System.IO.FileInfo(collbmp.FileName);
                System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);
                textBoxcoll.Text = collbmp.FileName;
            }
        }
    }
}
