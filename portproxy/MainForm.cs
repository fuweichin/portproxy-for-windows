using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace portproxy
{
    public partial class MainForm : Form
    {
        private ProxyDal proxyDal = new ProxyDal();
        private List<ProxyRule> boundRules = new List<ProxyRule>();
        static Regex ipv4Regex = new Regex(@"^(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)$");
        static Regex ipv6Regex = new Regex(@"^([0-9a-fA-F]{1,4})?(:[0-9a-fA-F]{0,4}){2,7}(%\d+)?$");
        public MainForm()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowAndActivate();
            }
            base.WndProc(ref m);
        }
        private void ShowAndActivate()
        {
            if (!this.Visible)
            {
                this.Show();
            }
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            this.Activate();
            this.TopMost = true;
            Action<Task> cancelTopMost = (Task t) => {
                this.TopMost = false;
            };
            Task.Delay(1000).ContinueWith(cancelTopMost);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            btnShow.PerformClick();
            cmbDirection.SelectedIndex = 0;
            cmbProtocol.SelectedIndex = 0;
        }

        public void ListViewReload() {
            listRules.Items.Clear();
            foreach (ProxyRule rule in boundRules)
            {
                string[] cells = new string[] { rule.Direction, rule.Listenaddress, rule.Listenport, rule.Connectaddress, rule.Connectport, rule.Protocol };
                ListViewItem item = new ListViewItem(cells);
                listRules.Items.Add(item);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            List<ProxyRule> rules = proxyDal.GetRules();
            boundRules.Clear();
            boundRules.AddRange(rules);
            ListViewReload();
            Cursor = Cursors.Default;
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you want to delete the selected rule(s)?", "Confirm Delete!", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            //return;
            int count = 0;
            foreach (ListViewItem item in listRules.SelectedItems)
            {
                ProxyRule rule=new ProxyRule();
                rule.Direction =item.SubItems[0].Text;
                rule.Listenaddress = item.SubItems[1].Text;
                rule.Listenport = item.SubItems[2].Text;

                if (proxyDal.DeleteRule(rule))
                {
                    int index=boundRules.IndexOf(rule);
                    boundRules.RemoveAt(index);
                    count++;
                }
                else
                {
                    MessageBox.Show("Failed to remove rule "+ rule.ToShortString());
                }
            }
            if(count>0)
                ListViewReload();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool valid = ValidateListenaddress()
                    && ValidateListenport()
                    && ValidateConnectaddress()
                    && ValidateConnectport();
            if (!valid)
            {
                return;
            }
            ProxyRule rule = new ProxyRule();
            rule.Direction = cmbDirection.Text;
            rule.Listenaddress = txtListenaddress.Text;
            rule.Listenport = txtListenport.Text;
            rule.Connectaddress = txtConnectaddress.Text;
            rule.Connectport = txtConnectport.Text;
            rule.Protocol = cmbProtocol.Text;
            string errorMessage=AddOrChangeRule(rule);
            if(string.IsNullOrEmpty(errorMessage))
            {
                ListViewReload();
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private string AddOrChangeRule(ProxyRule rule)
        {
            
            if (rule.Listenaddress == rule.Connectaddress && rule.Listenport == rule.Connectport)
            {
                return "Connect address:port cannot be the same as listen address:port. for rule\r\n    " + rule.ToString();
            }
            int index = boundRules.IndexOf(rule);
            if (index == -1)
            {
                if (proxyDal.AddRule(rule))
                {
                    boundRules.Add(rule);
                    return "";
                }
                else
                {
                    return "Failed to add rule " + rule.ToString();
                }
            }
            else
            {
                if (proxyDal.SetRule(rule))
                {
                    boundRules[index] = rule;
                    return "";
                }
                else
                {
                    return "Failed to update rule " + rule.ToShortString();
                }
            }
        }

        private void tsmiImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.InitialDirectory==null)
            {
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }
            ofd.Filter = "XML|*.xml";
            ofd.FilterIndex = 2;
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                /*if (MessageBox.Show("Are you sure you want to merge rules from the selected file with existing rules? ", "Confirm Import!", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }*/
                string pathname=ofd.FileName;
                List<ProxyRule> rules=proxyDal.ReadRulesFromFile(pathname);
                int successCount = 0;
                foreach(ProxyRule rule in rules)
                {
                    string errorMessage=AddOrChangeRule(rule);
                    if(string.IsNullOrEmpty(errorMessage))
                    {
                        successCount++;
                    }
                    else
                    {
                        if (MessageBox.Show(errorMessage + "\r\n Continue?", "Handle Exception!", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        {
                            break;
                        }
                    }
                }
                if(successCount>0)
                {
                    ListViewReload();
                }
                //MessageBox.Show(successCount + " rules imported from file \"" + pathname + "\"");

            }
        }

        private void tsmiExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.InitialDirectory == null)
            {
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }
            sfd.Filter = "XML|*.xml";
            sfd.FilterIndex = 2;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string pathname = sfd.FileName;
                proxyDal.WriteRulesToFile(boundRules,pathname);
            }
        }

        public static string[] ToStringArray(ListViewItem.ListViewSubItemCollection subitems)
        {
            string[] arr = new string[subitems.Count];
            int i = 0;
            foreach (ListViewItem.ListViewSubItem subitem in subitems)
            {
                arr[i++] = subitem.Text;
            }
            return arr;
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog();
        }

        private void listRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = listRules.SelectedItems.Count > 0;
            if (listRules.SelectedItems.Count == 0)
                return;
            ListViewItem item=listRules.SelectedItems[0];
            string[] arr = ToStringArray(item.SubItems);
            ProxyRule rule = ProxyRule.FromSubitems(arr);
            SelectByValue(cmbDirection, rule.Direction);
            txtListenaddress.Text = rule.Listenaddress;
            txtListenport.Text = rule.Listenport;
            txtConnectaddress.Text = rule.Connectaddress;
            txtConnectport.Text = rule.Connectport;
            SelectByValue(cmbProtocol, rule.Protocol);
            errorProvider1.Clear();
        }

        public static int SelectByValue(ComboBox comboBox, string value)
        {
            for (int i = 0; i <comboBox.Items.Count; i++)
            {
                string text=comboBox.Items[i] as string;
                if (text == value)
                {
                    comboBox.SelectedIndex = i;
                    return i;
                }
            }
            return -1;
        }

        private void txtListenaddress_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateListenaddress();
        }

        private void txtListenport_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateListenport();
        }

        private void txtConnectaddress_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateConnectaddress();
        }

        private void txtConnectport_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateConnectport();
        }

        private bool IsValidPort(string text)
        {
            if (text.Length > 5)
                return false;
            try
            {
                int port = Convert.ToInt32(text);
                return port >= 0 && port <= 65535;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private bool IsValid(string type,string value)
        {
            switch(type)
            {
                case "v4":
                    return ipv4Regex.IsMatch(value);
                case "v6":
                    return ipv6Regex.IsMatch(value);
                case "port":
                    return IsValidPort(value);
                default:
                    return false;
            }
        }
        private bool ValidateListenaddress()
        {
            string type = Regex.Split(cmbDirection.Text, "to")[0];
            if (txtListenaddress.Text == "" || !IsValid(type,txtListenaddress.Text))
            {
                errorProvider1.SetError(txtListenaddress, "Please enter a valid listen address");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtListenaddress, "");
                return true;
            }
        }
        private bool ValidateListenport()
        {
            if (txtListenport.Text == "" || !IsValidPort(txtListenport.Text))
            {
                errorProvider1.SetError(txtListenport, "Please enter a listen port which in range [0,65535]");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtListenport, "");
                return true;
            }
        }
        private bool ValidateConnectaddress()
        {
            string type = Regex.Split(cmbDirection.Text,"to")[1];
            if (txtConnectaddress.Text == "" || !IsValid(type,txtConnectaddress.Text))
            {
                errorProvider1.SetError(txtConnectaddress, "Please enter a valid connect address");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtConnectaddress, "");
                return true;
            }
        }
        private bool ValidateConnectport()
        {
            if (txtConnectport.Text == "" || !IsValidPort(txtConnectport.Text))
            {
                errorProvider1.SetError(txtConnectport, "Please enter a connect port which is in range [0,65535]");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtConnectport, "");
                return true;
            }
        }

        private void cmbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void ScaleListViewColumns(ListView listView, double dpr, double oldDpr)
        {
            foreach (ColumnHeader column in listView.Columns)
            {
                column.Width = (int)Math.Round(column.Width / oldDpr * dpr);
            }
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);
            double oldDpr = 1;
            double dpr = DeviceDpi / 96.0d;
            ScaleListViewColumns(listRules, dpr, oldDpr);
        }

        private void MainForm_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            double oldDpr = e.DeviceDpiOld / 96.0d;
            double dpr = e.DeviceDpiNew / 96.0d;
            ScaleListViewColumns(listRules, dpr, oldDpr);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
