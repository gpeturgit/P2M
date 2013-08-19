using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace P2MDEMO
{
    
    public partial class Form1 : Form
    {
        //TreeNode nodeFlokkur1 = new TreeNode("Flokkur 1");
        //TreeNode nodeFlokkur2 = new TreeNode("Flokkur 2");
        dbProductsDataContext data = new dbProductsDataContext();

        public Form1()
        {
            InitializeComponent();

            //treeView1.Nodes.Add(nodeFlokkur1);
            //treeView1.Nodes.Add(nodeFlokkur2);
            //dbProductsDataContext context = new dbProductsDataContext("Initial Catalog=dbProducts; Integrated Security=sspi");
            //Table<tbl_yfirflokkur> YfirFlokkur = context.GetTable<tbl_yfirflokkur>();

            //Populate dataGridView panel
            //string sItem;
            var listYfirflokkur = from c in data.tbl_yfirflokkurs
                        select new
                         {

                             ID = c.pk_yfirflokkur,
                             Name = c.texti
                         };
            
             
           
            //dataGridView1.DataSource = listVorur.ToList();

            //Populate treeView panel
            foreach(var element in listYfirflokkur)
            {
                TreeNode nodeYfirFlokkur = new TreeNode();
                //treeView1.Nodes.Add(element.Name.ToString());
                nodeYfirFlokkur.Text = element.Name.ToString();
                nodeYfirFlokkur.Name = "9999";
                

                var listUndirFlokkur = from b in data.tbl_undirflokkurs
                                       where b.fk_yfirflokkur == element.ID
                                       select new
                                       {
                                           ID = b.pk_undirflokkur,
                                           IDYfirFlokkur = b.fk_yfirflokkur,
                                           Name = b.texti


                                       };
                foreach (var a in listUndirFlokkur)
                {
                    TreeNode nodeUndirFlokkur = new TreeNode();
                    nodeUndirFlokkur.Text = a.Name.ToString();
                    nodeUndirFlokkur.Name = a.ID.ToString();
                    nodeYfirFlokkur.Nodes.Add(nodeUndirFlokkur);
                    
                }
                treeView1.Nodes.Add(nodeYfirFlokkur);
                
            }
            
            /*foreach (P2MDEMO.tbl_yfirflokkur element in listA)
            {
                TreeNode parentNode = new TreeNode(data.tbl_yfirflokkurs);
                treeView1.Nodes.Add(parentNode);
            }*/


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("hef opnast");
        }   

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string pid;
            pid = treeView1.SelectedNode.Name.ToString();
            MessageBox.Show(pid);
            if (pid == "9999")
            {
                pid = "1";
            }
            else
            {
                pid = (treeView1.SelectedNode.Name.ToString());
            }
            int intPid = Convert.ToInt32(pid);
            var listVorur = from d in data.tbl_varas
                            where d.fk_undiflokkur == intPid
                            select new
                            {
                                ID = d.pk_vara,
                                IDUIndirFlokkur = d.fk_undiflokkur,
                                IDByrgja = d.vorunumer_byrgja,
                                Name = d.vara,

                                Eining = d.eining,
                                Stk = d.stk
                            };

            dataGridView1.DataSource = listVorur.ToList();

        }

    } 
}
