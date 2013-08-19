using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P2MDEMO
{
    class SimulatorScrewList
    {
        List<Transfer> ScrewList = new List<Transfer>();


        public List<Transfer> GetScrewLists()
        {
            /* Container Container1 = new Container();
             Container1.ContainerID = 1;
             Container1.ContainerName = "Tankur 1";
             Container1.ContainerCapacity = 10000;
             Container1.ContainerVolume = 7000;
             Container1.ContainerHeight = 0.7;
             Container1.ContainerMax = 1;
             Container1.ContainerMin = 0.1;
             Container1.ContainerProtein = 2000;
             Container1.ContainerFat = 1000;
             Container1.ContainerWater = 4000;
             */
            List<Transfer> ScrewList = new List<Transfer>();
            ScrewList.Add(new Transfer
            {
                TransferID = 1,
                TransferName = "Snigill 1",
                TransferCapacity = 1000,
                TransferStatus = 1
                
            });


            ScrewList.Add(new Transfer
            {
                TransferID = 2,
                TransferName = "Snigill 2",
                TransferCapacity = 800,
                TransferStatus = 1
            });

            return ScrewList;
        }
    }
}