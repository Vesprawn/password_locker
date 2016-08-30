using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordLocker {
    class LockerFile {
        private string password = "";
        private string path = "";

        public LockerFile(string path) {
            this.path = path;
        }

        public List<Dictionary<string, string>> Read(string password) {
            string line = null;

            var reader = new StreamReader(path);
            var encrypted_list = new List<string>();

            while((line = reader.ReadLine()) != null) {
                encrypted_list.Add(line);
            }

            reader.Close();

            var decrypted_list = this.decryptList(encrypted_list, password);
            var properties = this.getProperties(decrypted_list);

            return properties;
        }

        public void Create(string new_path) { 
            //File.Create(this.path);   
            var writter = new StreamWriter(new_path);
            writter.Close();
        }

        public void SaveMasterPassword(string master_password_path, string password) { 
            var writter = new StreamWriter(master_password_path);
            writter.WriteLine(password);
            writter.Close();
        }

        public void Write(List<Dictionary<string, string>> list, string password) {
            var encrypted_list = encryptList(list, password);
            var writter = new StreamWriter(path);

            foreach (var item in encrypted_list) { 
                writter.WriteLine(item);
            }

            writter.Close();
        }

        private List<string> decryptList(List<string> list, string password) {
            var decrypted_list = new List<string>();

            foreach(var item in list) {
                decrypted_list.Add(StringCipher.Decrypt(item, password));
            }

            return decrypted_list;
        }

        private List<string> encryptList(List<Dictionary<string, string>> list, string password) {
            var encrypted_list = new List<string>();
            foreach (var item in list) { 
                var sb = new StringBuilder();

                foreach (var text in item) { 
                    sb.Append(text.Key + "," + text.Value + ";");
                }

                encrypted_list.Add(StringCipher.Encrypt(sb.ToString(), password));
            }

            return encrypted_list;
        }

        private List<Dictionary<string, string>> getProperties(List<string> list) {
            var new_list = new List<Dictionary<string, string>>();
            

            foreach(var item in list) {
                var properties = item.Split(';');

                var dictionary = new Dictionary<string, string>();

                foreach(var prop in properties) {
                    var split = prop.Split(',');

                    if (split.Length == 2) { 
                        dictionary.Add(split[0], split[1]);
                    }

                    
                }

                new_list.Add(dictionary);
            }

            return new_list;
        }

        //private void getProperty(string property) {
        
        //}

        //public List<Dictionary<string, string>> Read() {
        //    var list = new List<Dictionary<string, string>>();
            
        //    var reader = new StreamReader(path);
        //    var unformatted_list = new List<string>();
        //    string line = null;

        //    while ((line = reader.ReadLine()) != null) { 
        //        unformatted_list.Add(line);
        //    }

        //   // return formatList(unformatted_list);
        //}

        //private Dictionary<string, string> formatList(List<string> list) {
        //    var new_list = new List<Dictionary<string, string>>();

        //    foreach(var line in list) {
        //        var properties = line.Split(';');

        //        foreach(var property in properties) {
        //            var values = property.Split(',');

        //            new_list.Add(values[0], values[1]);
        //        }
        //    }

        //    return new_list;
        //}
    }
}


//"Username,Vesprawn;Password,d4rkv3sp0r;Email,mikemalcolm@atlasknowledge.com"
