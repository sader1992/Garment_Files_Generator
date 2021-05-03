using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Garment_Files_Generator
{
    public partial class GFG : Form
    {
        public GFG()
        {
            InitializeComponent();
        }

        private void ButtonGENERATE_Click(object sender, EventArgs e)
        {
            
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            if (!File.Exists(path + @"\boys_list.txt") || !File.Exists(path + @"\girls_list.txt"))
            {
                MessageBox.Show("You are missing one of the following files! , boys_list.txt || girls_list.txt");
                MessageBox.Show("The files contain the list of boys names and girls names!.");
                return;
            }
            string[] boy = File.ReadLines(path + @"\boys_list.txt").ToArray();
            string[] girl = File.ReadLines(path + @"\girls_list.txt").ToArray();
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox.Name == "textBoxinfo")
                        continue;
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        MessageBox.Show("Please Provide " + textBox.AccessibleName);
                        return;
                    }
                }
            }
            var G_FILENAME = textBoxName.Text;
            if (G_FILENAME.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0 || G_FILENAME.Contains(" "))
            {
                MessageBox.Show("Invalid name for a File Name.");
                return;
            }
            var G_INGAME = textBoxGName.Text;
            var SPRFR = textBoxSPR.Text;
            var ACTFR = textBoxACT.Text;
            var SPRFRd = textBoxSPRd.Text;
            var ACTFRd = textBoxACTd.Text;
            var itmbmp = textBoxitm.Text;
            var collbmp = textBoxcoll.Text;
            string pathdatam = path + @"\data\sprite\로브\" + G_FILENAME + @"\남";
            string pathdataf = path + @"\data\sprite\로브\" + G_FILENAME + @"\여";
            string pathdatal = path + @"\data\sprite\아이템";
            string pathdatai = path + @"\data\texture\유저인터페이스\item";
            string pathdatac = path + @"\data\texture\유저인터페이스\collection";
            if (!Directory.Exists(pathdatam))
            {
                Directory.CreateDirectory(pathdatam);
            }
            if (!Directory.Exists(pathdataf))
            {
                Directory.CreateDirectory(pathdataf);
            }
            if (!Directory.Exists(pathdatal))
            {
                Directory.CreateDirectory(pathdatal);
            }
            if (!Directory.Exists(pathdatai))
            {
                Directory.CreateDirectory(pathdatai);
            }
            if (!Directory.Exists(pathdatac))
            {
                Directory.CreateDirectory(pathdatac);
            }
            
            File.Copy(SPRFRd, path + @"\data\sprite\아이템\" + G_FILENAME + ".spr", true);
            File.Copy(ACTFRd, path + @"\data\sprite\아이템\" + G_FILENAME + ".act", true);
            File.Copy(itmbmp, path + @"\data\texture\유저인터페이스\item\" + G_FILENAME + ".bmp", true);
            File.Copy(collbmp, path + @"\data\texture\유저인터페이스\collection\" + G_FILENAME + ".bmp", true);
            for (int i = 0; i < boy.Length; i++)
            {
                if(!string.IsNullOrEmpty(boy[i]) && boy[i].IndexOfAny(Path.GetInvalidFileNameChars()) < 0 && !boy[i].StartsWith("/"))
                {
                    File.Copy(SPRFR, path + @"\data\sprite\로브\" + G_FILENAME + @"\남\" + boy[i] + ".spr", true);
                    File.Copy(ACTFR, path + @"\data\sprite\로브\" + G_FILENAME + @"\남\" + boy[i] + ".act", true);
                }
            }

            for (int i = 0; i < girl.Length; i++)
            {
                if (!string.IsNullOrEmpty(girl[i]) && girl[i].IndexOfAny(Path.GetInvalidFileNameChars()) < 0 && !girl[i].StartsWith("/"))
                {
                    File.Copy(SPRFR, path + @"\data\sprite\로브\" + G_FILENAME + @"\여\" + girl[i] + ".spr", true);
                    File.Copy(ACTFR, path + @"\data\sprite\로브\" + G_FILENAME + @"\여\" + girl[i] + ".act", true);
                }
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
            textBoxinfo.Text += "   [SPRITE_ROBE_IDs.ROBE_" + G_FILENAME + "] = \"" + G_FILENAME + "\"" + Environment.NewLine;
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
            textBoxinfo.Text += "transparentItem.lua/transparentItem.lub :" + Environment.NewLine;
            textBoxinfo.Text += "transparentItemlist = {" + Environment.NewLine;
            textBoxinfo.Text += "	{ <ViewID>, 255, 255, 25500 }," + Environment.NewLine;
            textBoxinfo.Text += "}" + Environment.NewLine;
            textBoxinfo.Text += "------------------------------------------------------" + Environment.NewLine;
            textBoxinfo.Text += " " + Environment.NewLine;
            MessageBox.Show("Done");
        }

        private void buttonSPR_Click(object sender, EventArgs e)
        {
            textBoxSPR.Text = ImportFile("SPR Files|*.spr");
        }

        private void buttonACT_Click(object sender, EventArgs e)
        {
            textBoxACT.Text = ImportFile("ACT Files|*.act");
        }

        private void buttonSPRd_Click(object sender, EventArgs e)
        {
            textBoxSPRd.Text = ImportFile("SPR Files|*.spr");
        }

        private void buttonACTd_Click(object sender, EventArgs e)
        {
            textBoxACTd.Text = ImportFile("ACT Files|*.act");
        }

        private void buttonitm_Click(object sender, EventArgs e)
        {
            textBoxitm.Text = ImportFile("BMP Files|*.bmp");
        }

        private void buttoncoll_Click(object sender, EventArgs e)
        {
            textBoxcoll.Text = ImportFile("BMP Files|*.bmp");
        }


        private string ImportFile(string Type)
        {
            var dial = new OpenFileDialog();
            dial.Filter = Type;
            if (dial.ShowDialog() == DialogResult.OK)
            {
                return dial.FileName;
            }
            throw new Exception("Something Went Wrong Importing The File!");
        }
    }
}
