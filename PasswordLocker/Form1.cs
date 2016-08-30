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

namespace PasswordLocker {
    public partial class Form1 : Form {
        private string password = "";
        private LockerFile locker_file = null;
        private List<Dictionary<string, string>> accounts = null;
        private List<Dictionary<string, string>> search_results = null;

        public Form1() {
            InitializeComponent();
            var path = Environment.CurrentDirectory + "\\l0g.txt";
            locker_file = new LockerFile(path);
            if (!File.Exists(path)) { 
                locker_file.Create(Environment.CurrentDirectory + "\\l0g.txt");
            }

            if (!File.Exists(Environment.CurrentDirectory + "\\l0g2.txt")) { 
                locker_file.Create(Environment.CurrentDirectory + "\\l0g2.txt");
                pnlSetupView.Show();
                pnlPassword.Hide();
                pnlMainView.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            search_results = new List<Dictionary<string, string>>();

            //Console.WriteLine("");

            //var test = StringCipher.Encrypt("Atl@z20!6", "test");
            //Clipboard.SetText(StringCipher.Encrypt("r0s3 s0ul c04l", "crusty_mango"));
            //var test2 = StringCipher.Decrypt("Tz+opAvWvoVR8szrNqMeRwSkkODLAQT6ouCksX1U0xFoq6H27nLYnbDmnyRKu+6qB4OQ+TYEroAe1/vylmqZuhZA2POv2HkS/nc4hypFNlMas4PwIX3nUP9y9daCrVcQ", "crusty_mango");

            //Console.WriteLine("");
           // MessageBox.Show("Enter Password");

            
          //  Console.WriteLine(" " + encrypted_string);
           // Console.WriteLine("Decrypted: " + decrypted_string);
        }

        private string getSavedPassword() { 
            var reader = new StreamReader(Environment.CurrentDirectory + "\\l0g2.txt");
            var pwd = reader.ReadLine();

            if (pwd != null) { 
                return StringCipher.Decrypt(pwd, "crusty_mango");
            }

            return "";
        }

        private void btnSubmitPassword_Click(object sender, EventArgs e) {
            this.submitPassword();

            
            

           // locker_file.Write(read, password);

            //var original_string = "Title,Amazon;Username,michaelmalcolm@outlook.com;Password,y0lk l3m0n r0s3 s0ul r0s3;";
           // var encrypted_string = StringCipher.Encrypt(original_string, "test");
          //  var decrypted_string = StringCipher.Decrypt(encrypted_string, password);


          //  MessageBox.Show("Original: " + original_string + "\nEncrypted: "+encrypted_string+"\nDecrypted: "+decrypted_string);
         //   Console.WriteLine("test");
        }

        private void listAccounts_SelectedIndexChanged(object sender, EventArgs e) {
            var index = listAccounts.SelectedIndex;
            if (index != -1) { 
                var account = this.accounts[index];

            pnlAccountInfo.Controls.Clear();

            var offset_y = 0;

            foreach (var item in account) { 
                var pnl = new Panel();
                pnl.Width = pnlAccountInfo.Width;
                pnl.Height = 30;
                pnl.Location = new Point(0, offset_y);
                offset_y += 30;
                

                var txtName = new TextBox();
                if (item.Key == "Account") { 
                    txtName.ReadOnly = true;
                }
                txtName.Width = 100;
                txtName.Height = 26;
                txtName.Location = new Point (5, 2);
                txtName.Text = item.Key;
                txtName.Tag = index + ":" +item.Key;
                txtName.Leave += new EventHandler(saveAccountName);

                var txtValue = new TextBox();
                
                txtValue.Width = 200;
                txtValue.Height = 26;
                txtValue.Location = new Point (110, 2);
                txtValue.Text = item.Value;
                txtValue.Tag = index + ":" +item.Key;
                txtValue.Leave += new EventHandler(saveAccountValue);

                if (item.Key == "Password") { 
                    txtName.ReadOnly = true;
                    var btnCopy = new Button();
                    btnCopy.Height = 26;
                    btnCopy.Text = "Copy";
                    btnCopy.Tag = item.Value;
                    btnCopy.Click += new EventHandler(buttonClick);
                    btnCopy.Location = new Point(315, 2);
                    pnl.Controls.Add(btnCopy);
                }
                

                pnl.Controls.Add(txtName);
                pnl.Controls.Add(txtValue);

                pnlAccountInfo.Controls.Add(pnl);
            }

            //var pnlSave = new Panel();

            //pnlSave.Width = pnlAccountInfo.Width;
            //pnlSave.Height = offset_y;

            //var saveBtn = new Button();
            //saveBtn.Text = "Save";
            //saveBtn.Tag = index;
            //saveBtn.Click += new EventHandler(saveAccountClick);

            //pnlSave.Controls.Add(saveBtn);

            //pnlAccountInfo.Controls.Add(pnlSave);
            //Console.WriteLine("");
            }
        }

        //private void saveAccountClick(object sender, System.EventArgs e) { 
        //    var button = (Button)sender;
        //    var index = Convert.ToInt32(button.Tag.ToString());

        //    foreach (Control pnl in pnlAccountInfo.Controls) {
        //        foreach (var control in pnl.Controls) {
        //            Console.WriteLine();
        //        }
        //    }
        //}

        private void saveAccountValue(object sender, System.EventArgs e) { 
            var txt = (TextBox)sender;

            var split = txt.Tag.ToString().Split(':');
            var index = Convert.ToInt32(split[0]);
            var original_key = split[1];

            //this.accounts[index][original_key] = txt.Text;

            this.accounts[index][original_key] = txt.Text;

           // this.updateKey(accounts[index], original_key, txt.Text);
            locker_file.Write(accounts, password);

            //this.accounts[index][txt.Text]


            //Clipboard.SetText(txt.Tag.ToString());
            this.updateAccountList();
        }

        private void saveAccountName(object sender, System.EventArgs e) { 
            var txt = (TextBox)sender;

            var split = txt.Tag.ToString().Split(':');
            var index = Convert.ToInt32(split[0]);
            var original_key = split[1];

            //this.accounts[index][original_key] = txt.Text;

            this.updateKey(accounts[index], original_key, txt.Text);
            locker_file.Write(accounts, password);

            //this.accounts[index][txt.Text]


            //Clipboard.SetText(txt.Tag.ToString());
        }

        private void updateAccountList() { 
            listAccounts.Items.Clear();

            if (this.search_results.Count > 0) {
                foreach (var item in this.search_results) { 
                    listAccounts.Items.Add(item["Account"]);
                }
            } else { 
                foreach (var item in this.accounts) { 
                    listAccounts.Items.Add(item["Account"]);
                }
            }
        }

        private void buttonClick(object sender, System.EventArgs e) { 
            var button = (Button)sender;
            Clipboard.SetText(button.Tag.ToString());
        }

        private void updateKey(Dictionary<string, string> dictionary, string key, string new_key) { 
            var value = dictionary[key];

            dictionary.Remove(key);
            dictionary.Add(new_key, value);
        }

        private void btnAddAccount_Click(object sender, EventArgs e) {
            var details = new Dictionary<string, string>();

            details.Add("Account", "Account_Name");
            details.Add("Username", "Username");
            details.Add("Password", "Password");
            this.accounts.Add(details);
            this.updateAccountList();
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            var index = listAccounts.SelectedIndex;

            if (index != -1) { 
                this.accounts.RemoveAt(index);
            }

            this.updateAccountList();
        }

        private void btnSetPassword_Click(object sender, EventArgs e) {
            this.setPassword();
        }

        private void submitPassword() { 
            var input_password = txtPassword.Text;
            var saved_password = this.getSavedPassword();

            if (input_password != saved_password) { 
                this.ActiveControl = label2;
                MessageBox.Show("Incorrect Master Password!");
            } else { 
                this.password = saved_password;
                pnlPassword.Hide();
                pnlMainView.Show();

                accounts = locker_file.Read(password);
                this.updateAccountList();
            }

            txtPassword.Text = "";
        }

        private void setPassword() { 
            var pwd = StringCipher.Encrypt(txtSetPassword.Text, "crusty_mango");
            locker_file.SaveMasterPassword(Environment.CurrentDirectory + "\\l0g2.txt", pwd);
            pnlMainView.Show();
            pnlSetupView.Hide();
            accounts = locker_file.Read(password);
            this.password = txtSetPassword.Text;
            this.updateAccountList();
        }

        private void txtSetPassword_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyValue == 13) {
                this.setPassword();
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyValue == 13) {
               this.submitPassword();
            }
        }

        private void btnHidePasswords_Click(object sender, EventArgs e) {
            pnlAccountInfo.Controls.Clear();
            listAccounts.SelectedIndex = -1;
            this.logout();
        }

        private void logout() { 
            this.accounts.Clear();
            this.password = "";
            this.pnlMainView.Hide();
            this.pnlPassword.Show();
            this.txtSearch.Text = "";
            this.listAccounts.Items.Clear();
            this.search_results.Clear();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e) {
            var text = txtSearch.Text.ToLower();
            this.search_results.Clear();

            if (text != "") { 
                foreach (var item in this.accounts) {
                    if (item["Account"].ToLower().Contains(text)) { 
                        this.search_results.Add(item);
                    }
                }
            }

            this.updateAccountList();
        }
    }
}
