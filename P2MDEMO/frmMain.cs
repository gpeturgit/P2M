using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace P2MDEMO
{
           

    public partial class frmMain : Form
    {
        SimulatorMethods SimulatorMethod = new SimulatorMethods();

        //---------------------------------------------------
        // create container objects
        //---------------------------------------------------
        Container Container1 = new Container("Tankur 1", 1, 20000, 12800, 0.64, 0.9, 0.2, 3800, 2000, 7000);
        Container Container2 = new Container("Tankur 2", 2, 20000, 14600, 0.73, 0.9, 0.2, 4200, 2400, 8000);
        Container Container3 = new Container("Tankur 3", 3, 12000, 9000, 0.81, 0.9, 0.3, 3000, 1500, 4500);
        Container Container4 = new Container();
        Container Container5 = new Container();
        
        //----------------------------------------------------
        // create process objects
        //----------------------------------------------------
        Process Process1 = new Process();
        Process Process2 = new Process();
        Process Process3 = new Process();
        Process Process4 = new Process();
        Process Process5 = new Process();

        //---------------------------------------------------
        // create transfer objects
        //---------------------------------------------------
        Transfer Screw1 = new Transfer("Snigill 1", 1, 100000, 1);
        Transfer Screw2 = new Transfer("Snigill 2", 2, 20000, 1);
        Transfer Screw3 = new Transfer("Snigill 3", 1, 10000, 1);
        Transfer Screw4 = new Transfer("Snigill 4", 2, 200000, 1);
        Transfer Pump1 = new Transfer();
        Transfer Pump2 = new Transfer();
        Transfer Screw5 = new Transfer();
        Transfer Screw6 = new Transfer();
        Transfer Screw7 = new Transfer();
        Transfer Screw8 = new Transfer();
        Transfer Pump3 = new Transfer();
        Transfer Pump4 = new Transfer();
        Transfer Pump5 = new Transfer();

        //----------------------------------
        // Hráefnistankur 1. ct001
        //----------------------------------
        //string ct001_label;
        ////Rammi hæðarsúlu.
        //int ct00101_left;
        //int ct00101_top;
        ////Hæðarsúla
        //int ct00102_left;
        //int ct00102_top;
        //int ct00102_height;
        int intTimerTick;

        //-----------------------------------
        // Hráefnistankur 2. ct002
        //-----------------------------------
        //string ct002_label;
        ////Rammi hæðarsúlu.
        //int ct00201_left;
        //int ct00201_top;
        ////Hæðarsúla
        //int ct00202_left;
        //int ct00202_top;
        //int ct00202_height;

        //---------------------------------------
        // Mótorar og Pumpur - Motors and pumps
        //---------------------------------------
        // status 1 = off
        // status 2 = on
        // status 3 = stop

        int status_m1 = 1;
        int status_m2 = 1;
        int status_m3 = 1;
        int status_m4 = 1;
        int status_m5 = 1;
        int status_m6 = 1;
        int status_m7 = 1;

        int status_p1 = 1;
        int status_p2 = 1;
        int status_p3 = 1;

        //---------------------------------------
        // Tankar - Tanks
        //---------------------------------------

        //default height
        double containerHeightDefault = 0;
        //default temp
        double processTempDefault = 0;
        //default pressure
        double processPressureDefault = 0; 

        //System.Timers.Timer maintimer;
   
        public frmMain()
        {
            InitializeComponent();

          
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            loadMImage();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {


        }

        public void loadMImage()
        {
            this.t7.Image = global::P2MDEMO.Properties.Resources.moff;
            this.t1.Image = global::P2MDEMO.Properties.Resources.moff;
            this.t2.Image = global::P2MDEMO.Properties.Resources.moff;
            this.t3.Image = global::P2MDEMO.Properties.Resources.moff;
            this.t4.Image = global::P2MDEMO.Properties.Resources.moff;
            //this.m6.Image = global::P2MDEMO.Properties.Resources.moff;
            this.t8.Image = global::P2MDEMO.Properties.Resources.moff;
            this.m1.Image = global::P2MDEMO.Properties.Resources.moff;
            this.t9.Image = global::P2MDEMO.Properties.Resources.moff;
            this.t6.Image = global::P2MDEMO.Properties.Resources.dpumpoff;
            this.t12.Image = global::P2MDEMO.Properties.Resources.lpumpoff;
            this.t13.Image = global::P2MDEMO.Properties.Resources.lpumpoff;
            this.t5.Image = global::P2MDEMO.Properties.Resources.lpumpoff;
            this.t11.Image = global::P2MDEMO.Properties.Resources.dpumpoff;
    

            //labels
            this.c1label.Text = "Hráefnistankar";
            this.pr1label.Text = "Blöndunarkar";
            this.pr2label.Text = "Forsjóðari";
            this.pr3label.Text = "Sjóðari";
            this.c3label.Text = "Kar";
            this.pr4label.Text = "Pressa";
            this.c4label.Text = "Olíutankur";
            this.pr5label.Text = "Ketill";
            this.c5label.Text = "Kar";


            //-------------------------------------------------------------------
            // set numerical gauge on tanks - stilla númerískan hæðamæli á tönkum
            //--------------------------------------------------------------------

            this.c1h.Text = String.Format("{0:0.00}", Container1.ContainerHeight);
            this.c2h.Text = String.Format("{0:0.00}", Container2.ContainerHeight);
            this.pr1h.Text = String.Format("{0:0.00}", Container3.ContainerHeight);
            this.pr3h.Text = String.Format("{0:0.00}", containerHeightDefault);
            this.c3h.Text = String.Format("{0:0.00}", containerHeightDefault);
            this.pr4h.Text = String.Format("{0:0.00}", containerHeightDefault);
            this.c4h.Text = String.Format("{0:0.00}", containerHeightDefault);
            this.c5h.Text = String.Format("{0:0.00}", containerHeightDefault);

            //--------------------------------------------------------------------
            // set graphical gauge on tanks - stilla grafískan hæðamæli á tönkum
            //--------------------------------------------------------------------

            //tankur 1 - hráefnistankur
            this.c1g.ClientSize = new Size(this.c1g.ClientSize.Width, (int)(this.c1b.ClientSize.Height*Container1.ContainerHeight));
            this.c1g.Location = new Point(this.c1g.Location.X, this.c1b.Location.Y + (this.c1b.ClientSize.Height - this.c1g.ClientSize.Height));

            //tankur 2 - hráefnistankur
            this.c2g.ClientSize = new Size(this.c2g.ClientSize.Width, (int)(this.c2b.ClientSize.Height*Container2.ContainerHeight));
            this.c2g.Location = new Point(this.c2g.Location.X, this.c2b.Location.Y + (this.c2b.ClientSize.Height - this.c2g.ClientSize.Height));

            //tankur 3 - blöndunarkar
            this.pr1g.ClientSize = new Size(this.pr1g.ClientSize.Width, (int)(this.pr1b.ClientSize.Height*Container3.ContainerHeight));
            this.pr1g.Location = new Point(this.pr1g.Location.X, this.pr1b.Location.Y + (this.pr1b.ClientSize.Height - this.pr1g.ClientSize.Height));

            //tankur 4
            this.c3g.ClientSize = new Size(this.c3g.ClientSize.Width, (int)(this.c3b.ClientSize.Height*containerHeightDefault));
            this.c3g.Location = new Point(this.c3g.Location.X, this.c3b.Location.Y + (this.c3b.ClientSize.Height - this.c3g.ClientSize.Height));

            //tankur 5
            this.c5g.ClientSize = new Size(this.c5g.ClientSize.Width, (int)(this.c5b.ClientSize.Height*containerHeightDefault));
            this.c5g.Location = new Point(this.c5g.Location.X, this.c5b.Location.Y + (this.c5b.ClientSize.Height - this.c5g.ClientSize.Height));

            //tankur 6 - olíutankur
            this.c4g.ClientSize = new Size(this.c4g.ClientSize.Width, (int)(this.c4b.ClientSize.Height*containerHeightDefault));
            this.c4g.Location = new Point(this.c4g.Location.X, this.c4b.Location.Y + (this.c4b.ClientSize.Height - this.c4g.ClientSize.Height));

            //process 2 - sjóðari
            this.g7.ClientSize = new Size(this.g7.ClientSize.Width, (int)(this.b7.ClientSize.Height * containerHeightDefault));
            this.g7.Location = new Point(this.g7.Location.X, this.b7.Location.Y + (this.b7.ClientSize.Height - this.g7.ClientSize.Height));

            //process 3 - pressa
            this.pr4g.ClientSize = new Size(this.pr4g.ClientSize.Width, (int)(this.pr4b.ClientSize.Height * containerHeightDefault));
            this.pr4g.Location = new Point(this.pr4g.Location.X, this.pr4b.Location.Y + (this.pr4b.ClientSize.Height - this.pr4g.ClientSize.Height));


            //---------------------------------------------------------------------
            // set numerical temperature gauge on tanks - stilla hitamæla á tönkum
            //---------------------------------------------------------------------
            // forsjóðari
            this.pr2t.Text = String.Format("{0:0.00}", processTempDefault);
            // sjóðari
            this.pr3t.Text = String.Format("{0:0.00}", processTempDefault);
           
            //this.ct00101.Left = 100;
            //this.ct00101.Top = 92;
            //this.ct00102.Left = 100;
            //this.ct00102.Top = 92;

            //this.ct00201.Left = 100;
            //this.ct00201.Top = 198;
            //this.ct00202.Left = 100;
            //this.ct00202.Top = 198;

            //this.pr00401.Left = 50;
            //this.pr00401.Top = 395;
            //this.pr00402.Left = 50;
            //this.pr00402.Top = 395;

        }

        public void SumulatorStart()
        {
            timer1.Start();

        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            intTimerTick = intTimerTick+1;
            lblTimerTics.Text = intTimerTick.ToString();

            ///////////////////////TEST/////////////////////////////////

            //---------------------------------------------------------
            // update position for both numerical and graphical gauges
            //---------------------------------------------------------
          

            //Container1
            this.c1g.ClientSize = new Size(this.c1g.ClientSize.Width, (int)(this.c1b.ClientSize.Height * SimulatorMethod.GetContainerHeight(Container1.ContainerHeight, Container1.ContainerCapacity, 0, Screw1.TransferCapacity * intTimerTick)));
            this.c1g.Location = new Point(this.c1g.Location.X, this.c1b.Location.Y + (this.c1b.ClientSize.Height - this.c1g.ClientSize.Height));
            this.c1h.Text = String.Format("{0:0.000}", SimulatorMethod.GetContainerHeight(Container1.ContainerHeight, Container1.ContainerCapacity, 0, Screw1.TransferCapacity * intTimerTick));

            //Container 2
            this.c2g.ClientSize = new Size(this.c2g.ClientSize.Width, (int)(this.c2b.ClientSize.Height * SimulatorMethod.GetContainerHeight(Container2.ContainerHeight, Container2.ContainerCapacity, 0, Screw2.TransferCapacity * intTimerTick)));
            this.c2g.Location = new Point(this.c2g.Location.X, this.c2b.Location.Y + (this.c2b.ClientSize.Height - this.c2g.ClientSize.Height));
            this.c2h.Text = String.Format("{0:0.000}", SimulatorMethod.GetContainerHeight(Container2.ContainerHeight, Container2.ContainerCapacity, 0, Screw2.TransferCapacity * intTimerTick));

            //Container 3
             this.pr1g.ClientSize = new Size(this.pr1g.ClientSize.Width, (int)(this.pr1b.ClientSize.Height * SimulatorMethod.GetContainerHeight(Container3.ContainerHeight, Container3.ContainerCapacity, Screw3.TransferCapacity * intTimerTick, Screw4.TransferCapacity * intTimerTick)));
            this.pr1g.Location = new Point(this.pr1g.Location.X, this.pr1b.Location.Y + (this.pr1b.ClientSize.Height - this.pr1g.ClientSize.Height));
            pr1h.Text = String.Format("{0:0.000}", SimulatorMethod.GetContainerHeight(Container3.ContainerHeight, Container3.ContainerCapacity, Screw3.TransferCapacity * intTimerTick, Screw4.TransferCapacity * intTimerTick));
            if (SimulatorMethod.GetContainerHeight(Container3.ContainerHeight, Container3.ContainerCapacity, Screw3.TransferCapacity * intTimerTick, Screw4.TransferCapacity * intTimerTick) < Container3.ContainerMin)
            {
                pr1g.BackColor = Color.Red;
                this.t6.Image = global::P2MDEMO.Properties.Resources.dpumpstop;
            }
            
            ////////////////////////////////////////////////////////////

        }

        private void hermirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SumulatorStart();
        }


        private void l9_Click(object sender, EventArgs e)
        {

        }

        private void gæðakerfiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void gæðakerfiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void viðhaldskerfiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void birgðakerfiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void m2_Click(object sender, EventArgs e)
        {
            if (status_m2 == 1)
            {
                this.t1.Image = global::P2MDEMO.Properties.Resources.mon;
                status_m2 = 2;
            }
            else if (status_m2 == 2)
            {
                this.t1.Image = global::P2MDEMO.Properties.Resources.moff;
                status_m2 = 1;
            }
            else 
            {
                this.t1.Image = global::P2MDEMO.Properties.Resources.mstop;
                status_m3 = 3;
            }
        }

        private void m3_Click(object sender, EventArgs e)
        {
            if (status_m3 == 1)
            {
                this.t2.Image = global::P2MDEMO.Properties.Resources.mon;
                status_m3 = 2;
            }
            else if (status_m3 == 2)
            {
                this.t2.Image = global::P2MDEMO.Properties.Resources.moff;
                status_m3 = 1;
            }
            else
            {
                this.t2.Image = global::P2MDEMO.Properties.Resources.mstop;
                status_m3 = 3;
            }
        }

        private void m4_Click(object sender, EventArgs e)
        {
            if (status_m4 == 1)
            {
                this.t3.Image = global::P2MDEMO.Properties.Resources.mon;
                status_m4 = 2;
            }
            else if (status_m4 == 2)
            {
                this.t3.Image = global::P2MDEMO.Properties.Resources.moff;
                status_m4 = 1;
            }
            else
            {
                this.t3.Image = global::P2MDEMO.Properties.Resources.mstop;
            }
        }


        private void m5_Click(object sender, EventArgs e)
        {
            if (status_m5 == 1)
            {
                this.t4.Image = global::P2MDEMO.Properties.Resources.mon;
                status_m5 = 2;
            }
            else if (status_m5 == 2)
            {
                this.t4.Image = global::P2MDEMO.Properties.Resources.moff;
                status_m5 = 1;
            }
            else 
            {
                this.t4.Image = global::P2MDEMO.Properties.Resources.mstop;
                status_m5 = 3;
            }
        }

        private void p1_Click(object sender, EventArgs e)
        {
            if (status_p1 == 1)
            {
                this.t6.Image = global::P2MDEMO.Properties.Resources.dpumprun;
                status_p1 = 2;
            }
            else if (status_p1 == 2)
            {
                this.t6.Image = global::P2MDEMO.Properties.Resources.dpumpoff;
                status_p1 = 1;
            }
            else
            {
                this.t6.Image = global::P2MDEMO.Properties.Resources.dpumpstop;
                status_p1 = 3;
            }

        }

        private void kosthaldToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Kosthald frm = new Kosthald();
            frm.Show();
        }

        private void p5_Click(object sender, EventArgs e)
        {

        }

        private void g1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

   


    }
}
