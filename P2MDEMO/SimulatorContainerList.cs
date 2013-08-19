using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P2MDEMO
{
    public class SimulatorContainerList
    {
        List<Container> ContainerList = new List<Container>();
    

    public List<Container> GetObjectLists()
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
        List<Container> ContainerList = new List<Container>();
        ContainerList.Add(new Container
        {
            ContainerID = 1,
            ContainerName = "Tankur 1",
            ContainerCapacity = 10000,
            ContainerVolume = 7000,
            ContainerHeight = 0.7,
            ContainerMax = 1,
            ContainerMin = 0.1,
            ContainerProtein = 2000,
            ContainerFat = 1000,
            ContainerWater = 4000
        });


        ContainerList.Add(new Container
        {
            ContainerID = 2,
            ContainerName = "Tankur 2",
            ContainerCapacity = 12000,
            ContainerVolume = 9000,
            ContainerHeight = 0.75,
            ContainerMax = 1,
            ContainerMin = 0.1,
            ContainerProtein = 3000,
            ContainerFat = 1500,
            ContainerWater = 4500
        });

        return ContainerList; 
    }

    }
}

