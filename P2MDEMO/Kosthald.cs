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
    public partial class Kosthald : Form
    {

        TreeNode nodeSkip = new TreeNode("Skip");

        TreeNode nodeVeidiferd = new TreeNode("Veiðiferð");
        TreeNode nodeAhofn = new TreeNode("Áhöfn");
        TreeNode nodeBirgdir = new TreeNode("Birgðir");
        TreeNode nodeByrgjar = new TreeNode("Byrgjar");
        TreeNode nodeStada = new TreeNode("Staða fæðissjóðs");

        TreeNode nodeDagur = new TreeNode("Dagur");
        TreeNode nodePontun = new TreeNode("Pöntun");
        TreeNode nodeVorulisti = new TreeNode("Vörulisti");
        TreeNode nodeHreyfingar = new TreeNode("Birgðahreyfingar");
        TreeNode nodeVeidiferdAhofn = new TreeNode("Áhöfn");
        TreeNode nodeUppgjor = new TreeNode("Uppgjör");

        TreeNode nodeMorgun = new TreeNode("Matseðill Morgunmatur");
        TreeNode nodeHadegi = new TreeNode("Matseðill Hádegismatur");
        TreeNode nodeKvold = new TreeNode("Matseðill Kvöldmatur");

        TreeNode nodePontunByrgjar = new TreeNode("Byrgjar");
        TreeNode nodePontunByrgjarVorulisti = new TreeNode("Vörulisti");
        TreeNode nodeHreyfingarByrgjar = new TreeNode("Byrgjar");
        TreeNode nodeHreyfinarByrgjarVorulisti = new TreeNode("Vörulisti");
        
        TreeNode nodeTekjur = new TreeNode("Tekjur - Fæðispeningar");
        TreeNode nodeKostnaður = new TreeNode("Kostnaður = Pöntun síðasta túrs - Birgðahreyfingar");

       
        public Kosthald()
        {
            InitializeComponent();

            treeView1.Nodes.Add(nodeSkip);

            nodeSkip.Nodes.Add(nodeVeidiferd);
            nodeSkip.Nodes.Add(nodeAhofn);
            nodeSkip.Nodes.Add(nodeBirgdir);
            nodeSkip.Nodes.Add(nodeByrgjar);
            nodeSkip.Nodes.Add(nodeStada);

            //nodeSkip.Nodes.Add(nodeAhofn);
            //nodeSkip.Nodes.Add(nodeBirgdir);
            //nodeSkip.Nodes.Add(nodeByrgjar);
            //nodeSkip.Nodes.Add(nodeStada);

            nodeVeidiferd.Nodes.Add(nodeDagur);
            nodeVeidiferd.Nodes.Add(nodePontun);
            nodeVeidiferd.Nodes.Add(nodeHreyfingar);
            nodeVeidiferd.Nodes.Add(nodeVeidiferdAhofn);
            nodeVeidiferd.Nodes.Add(nodeUppgjor);

            nodeDagur.Nodes.Add(nodeMorgun);
            nodeDagur.Nodes.Add(nodeHadegi);
            nodeDagur.Nodes.Add(nodeKvold);

            nodePontun.Nodes.Add(nodePontunByrgjar);

            nodeHreyfingar.Nodes.Add(nodeHreyfingarByrgjar);
            
            nodeUppgjor.Nodes.Add(nodeTekjur);
            nodeUppgjor.Nodes.Add(nodeKostnaður);

            nodePontunByrgjar.Nodes.Add(nodePontunByrgjarVorulisti);
            nodeHreyfingarByrgjar.Nodes.Add(nodeHreyfinarByrgjarVorulisti);

       
        }


    }
}
