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
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            
            InitializeComponent();

            lblLastName.Text = Resource1.FullName; // label1
           //lblFirstName.Text = Resource1.FirstName; // label2
            btnAdd.Text = Resource1.Add; // button1
            btnFile.Text = Resource1.File;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtLastName.Text                
            };
            users.Add(u);
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfdialog = new SaveFileDialog();
            if (sfdialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(sfdialog.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    foreach (var i in users)
                    {
                        sw.Write(i.ID);
                        sw.Write("; ");
                        sw.WriteLine(i.FullName);
                    }
                }
            }
        }
    }
}
