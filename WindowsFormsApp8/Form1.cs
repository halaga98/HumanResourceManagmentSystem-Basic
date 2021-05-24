using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {


        public string NodeFind { get; set; }
        public int count { get; set; }
        public List<Employee> person { get; set; }
        public Employee EditEmp { get; set; }
        public Form1()
        {

            person = new List<Employee>();

            InitializeComponent();
            treeView1.ExpandAll();
            numericUpDown1.Value = DateTime.Now.Year;



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void counter()
        {
            count = 0;
            string[] item = NodeFind.Split('\\');
            count = item.Length;

        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView view = sender as TreeView;
            textBox1.Text = view.SelectedNode.FullPath;
            textBox3.Text = view.SelectedNode.FullPath;
            NodeFind = view.SelectedNode.FullPath;
            counter();
            if (count == 1)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
            }
            if (count == 2)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
            }
            if (count == 3)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
            }


        }

        private void button1_Click(object sender, EventArgs e)

        {

            TreeNode parent = treeView1.SelectedNode;


            if (parent != null && count == 1 && textBox2.Text != "")
            {

                TreeNode node = new TreeNode(textBox2.Text);

                parent.Nodes.Add(node);
                
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Parent Must Be Selected or Text Box cannot be empty");
            }
            treeView1.ExpandAll();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (count == 2)
                textBox2.Text = treeView1.SelectedNode.Text;
            NodeFind = treeView1.SelectedNode.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (count != 2)
            {
                MessageBox.Show("Please select the right node");
                return;
            }

            if (NodeFind != treeView1.SelectedNode.Text)
            {
                MessageBox.Show("Please select the right Department");
                return;
            }


            if (count == 2 && NodeFind == treeView1.SelectedNode.Text && textBox2 != null)
            {
                treeView1.SelectedNode.Text = textBox2.Text;
                textBox2.Text = "";
            }
            else
                MessageBox.Show("Have to fill the Deparment Name");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (count == 2)
                treeView1.SelectedNode.Remove();
            else
                MessageBox.Show("You cannot delete the parent!!!!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TreeNode parent = treeView1.SelectedNode;

            if (count != 2)
            {
                MessageBox.Show("You have to select department !");
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("You have To write name !");
                return;
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("You have To select favorite language !");
                return;
            }
            

            TreeNode node = new TreeNode(textBox4.Text);
            node.SelectedImageIndex = 1;
            node.ImageIndex = 1;
            parent.Nodes.Add(node);
            treeView1.ExpandAll();

            CreateEmployee();

        }
        private void CreateEmployee()
        {
            Employee employees = new Employee();
            employees.FullName = textBox4.Text;
            employees.DepartmentName = treeView1.SelectedNode.Text;
            employees.FavLang = comboBox1.SelectedItem.ToString();
            
            foreach (ListViewItem item in listView1.Items)
            {
                var bir = item.SubItems[1].Text;
                var bir2 = int.Parse(item.SubItems[2].Text);
                employees.Certificates.Add(new EmployeeCertificate() { Title = bir, Year = bir2 });
            }
            person.Add(employees);
            comboBox1.SelectedItem = null;
            listView1.Items.Clear();
            textBox4.Text = "";
        }
        /* private void fillAllView(TreeNode node)
         {
             listView1.Items.Clear();
             var selectedPerson = person.FirstOrDefault(x => x.FullName == node.Text);
             textBox4.Text = selectedPerson.FullName;
             comboBox1.SelectedItem = selectedPerson.FavLang;
             foreach (EmployeeCertificate items in selectedPerson.Certificates)
             {
                 // var iteml = new ListViewItem(new[] { items.Title, items.Year.ToString() });
                 //listView1.Items.Add(iteml);

                 var listitem = listView1.Items.Add(items.Title);

                 listitem.SubItems.Add(items.Year.ToString());
             }
         }*/



        private void button9_Click(object sender, EventArgs e)
        {
            var item = new ListViewItem(new[] {"Delete", textBox5.Text, numericUpDown1.Value.ToString() });
            listView1.Items.Add(item);

            textBox5.Text = "";
            numericUpDown1.Value = DateTime.Now.Year;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (count != 3)
            {
                MessageBox.Show("You have to select person !");
                return;
            }
            
           
            listView1.Items.Clear();
            var selectedPerson = person.FirstOrDefault(x => x.FullName == treeView1.SelectedNode.Text);
            EditEmp = selectedPerson;
            textBox4.Text = selectedPerson.FullName;
            comboBox1.SelectedItem = selectedPerson.FavLang;
            foreach (EmployeeCertificate items in selectedPerson.Certificates)
            {
                // var iteml = new ListViewItem(new[] { items.Title, items.Year.ToString() });
                //listView1.Items.Add(iteml);

                var listitem = listView1.Items.Add("Delete");
                listitem.SubItems.Add(items.Title);
                listitem.SubItems.Add(items.Year.ToString());
            }
            treeView1.ExpandAll();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (count != 3)
            {
                MessageBox.Show("You have to select person !");
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("You have To write name !");
                return;
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("You have To select favorite language !");
                return;
            }
            var changePerson = person.FirstOrDefault(x => x.FullName == EditEmp.FullName);
            changePerson.Certificates = new List<EmployeeCertificate>();
            foreach (ListViewItem items in listView1.Items)
            {
                // var iteml = new ListViewItem(new[] { items.Title, items.Year.ToString() });
                //listView1.Items.Add(iteml);
                changePerson.Certificates.Add(new EmployeeCertificate { Title = items.SubItems[1].Text.ToString(), Year = int.Parse(items.SubItems[2].Text) });

                //var listitem = listView1.Items.Add(items.Title);

                // listitem.SubItems.Add(items.Year.ToString());

            }
            treeView1.SelectedNode.Text = textBox4.Text;
            changePerson.FullName = textBox4.Text;
            changePerson.FavLang = comboBox1.SelectedItem.ToString();
            textBox4.Text = "";
            comboBox1.SelectedItem = null;
            listView1.Items.Clear();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (count == 3)
            {
                var deletePerson = person.FirstOrDefault(x => x.FullName == treeView1.SelectedNode.Text);
                treeView1.SelectedNode.Remove();


            }
        }


        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listView1.SelectedItems[0].Index;
            listView1.Items[index].Remove();
        }
    }
}
