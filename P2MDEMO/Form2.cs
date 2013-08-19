using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace P2MDEMO
{
    public partial class Form2 : Form
    {
        TreeNode nodeTankar = new TreeNode("Tankar");
        TreeNode nodeSniglar = new TreeNode("Sniglar");
        public Form2()
        {
            InitializeComponent();

           // SimulatorObjectsList ContainerList = new SimulatorObjectsList();
           // Grid.DataSource = ContainerList.GetObjectLists();


            //TreeNode nodeTankar = new TreeNode("Tankar");
            tree.Nodes.Add(nodeTankar);

            //TreeNode nodeSniglar = new TreeNode("Sniglar");
            tree.Nodes.Add(nodeSniglar);

       
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //SimulatorObjectsList ContainerList = new SimulatorObjectsList();
            //List<Container> List = ContainerList.GetObjectLists();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tree.SelectedNode == nodeTankar)
            {
                SimulatorContainerList ContainerList = new SimulatorContainerList();
                Grid.DataSource = ContainerList.GetObjectLists();

            }

            if (tree.SelectedNode == nodeSniglar)
            {
                SimulatorScrewList ScrewList = new SimulatorScrewList();
                Grid.DataSource = ScrewList.GetScrewLists();
            }

        }

        private void tree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }
        


    }
}
