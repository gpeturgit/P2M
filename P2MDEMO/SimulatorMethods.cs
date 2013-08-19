using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P2MDEMO
{
    class SimulatorMethods
    {
        public double GetContainerHeight(double h0, double containerCapacity, int input, int output)
        {
            //int ContainerCapacity = 100;
            double h1 = (h0 * containerCapacity - (output/3600) + (input/3600)) / containerCapacity;
            return h1;
        }
    }

    
      
     


    public class Container 
    { 
        public string ContainerName { get; set; }
        public int ContainerID { get; set; }
        public double ContainerCapacity {get; set; }
        public double ContainerVolume { get; set; }
        //ContainerHeight is percentage of capacity
        public double ContainerHeight {get; set; }
        public double ContainerMax { get; set; }
        public double ContainerMin { get; set; }
        public double ContainerWater {get; set; }
        public double ContainerProtein {get; set; }
        public double ContainerFat {get; set; }
  
        public Container()
        {
        
        }

        public Container (string containerName, int containerID, double containerCapacity, double containerVolume, double containerHeight, 
            double containerMax, double containerMin, double containerWater, double containerProtein, double containerFat)
        {
            this.ContainerName = containerName;
            this.ContainerID = containerID;
            this.ContainerCapacity = containerCapacity;
            this.ContainerVolume = containerVolume;
            this.ContainerHeight = containerHeight;
            this.ContainerMax = containerMax;
            this.ContainerMin = containerMin;
            this.ContainerWater = containerWater;
            this.ContainerProtein = containerProtein;
            this.ContainerFat = containerFat;

        }   
    }

    public class Process
    {
        public string ProcessName { get; set; }
        public int ProcessID { get; set; }
        public double ProcessCapacity { get; set; }
        public double ProcessVolume { get; set; }
        //ContainerHeight is percentage of capacity
        public double ProcessHeight { get; set; }
        public double ProcessMax { get; set; }
        public double ProcessMin { get; set; }
        public double ProcessWater { get; set; }
        public double ProcessProtein { get; set; }
        public double ProcessFat { get; set; }
        public double ProcessTemperature {get; set; }
        public double ProcessPressure {get; set; }

        public Process()
        {

        }

        public Process(string processName, int processID, double processCapacity, double processVolume, double processHeight,
            double processMax, double processMin, double processWater, double processProtein, double processFat,
            double processTemperature, double processPressure)
        {
            this.ProcessName = processName;
            this.ProcessID = processID;
            this.ProcessCapacity = processCapacity;
            this.ProcessVolume = processVolume;
            this.ProcessHeight = processHeight;
            this.ProcessMax = processMax;
            this.ProcessMin = processMin;
            this.ProcessWater = processWater;
            this.ProcessProtein = processProtein;
            this.ProcessFat = processFat;
            this.ProcessTemperature = processTemperature;
            this.ProcessPressure = processPressure;

        }
    }

    public class Transfer
    {
        public string TransferName {get; set;}
        public int TransferID {get; set;}
        public int TransferCapacity {get; set;}
        public int TransferStatus { get; set; }

        public Transfer()
        {

        }

        public Transfer(string transferName, int transferID, int transferCapacity, int transferStatus)
        {
            this.TransferName = transferName;
            this.TransferID = transferID;
            this.TransferCapacity = transferCapacity;
            this.TransferStatus = transferStatus;
        }       

    }



}
