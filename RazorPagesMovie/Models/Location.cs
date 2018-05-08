using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalktoMordor.Models
{
    public class Location
    {
        public int ID { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public decimal StartMiles { get; set; }
        public decimal EndMiles { get; set; }
        public decimal DistTotal { get; set; }
        public decimal CheckpointProgress { get; set; }
        public decimal TotalProgress { get; set; }
        public string finalLocation = "You have followed Frodo to the Grey Havens and returned home with Sam.";
        public decimal allMiles = 3405;


        public Location (decimal distTotal)
        {
            DistTotal = distTotal;
        }        

        public void FindLocations (decimal distTotal)
        {
            if (distTotal <= 458)
            {
                StartLocation = "Hobbiton";
                EndLocation = "Rivendell";
                StartMiles = 459;
                EndMiles = 919;
            }
            else if (distTotal <= 920)
            {
                StartLocation = "Rivendell";
                EndLocation = "Lothlorien";
                StartMiles = 459;
                EndMiles = 919;

            }
            else if (distTotal <= 1309)
            {
                StartLocation = "Lothlorien";
                EndLocation = "Rauros Falls";
                StartMiles = 920;
                EndMiles = 1308;
            }
            else if (distTotal <= 1779)
            {
                StartLocation = "Rauros Falls";
                EndLocation = "Mount Doom";
                StartMiles = 1309;
                EndMiles = 1778;

            }
            else if (distTotal <= 2314)
            {
                StartLocation = "Minas Tirith";
                EndLocation = "Isengard";
                StartMiles = 1779;
                EndMiles = 2313;

            }
            else if (distTotal <= 3007)
            {
                StartLocation = "Isengard";
                EndLocation = "Rivendell";
                StartMiles = 2314;
                EndMiles = 3006;

            }
            else if (distTotal <= 3404)
            {
                StartLocation = "Rivendell";
                EndLocation = "Bag End";
                StartMiles = 3007;
                EndMiles = 3403;
            }
            else if (distTotal <= 3871)
            {
                StartLocation = "Bag End";
                EndLocation = "Grey Havens";
                StartMiles = 3404;
                EndMiles = 3871;

            }
            else
            {
                StartLocation = "Grey Havens";
                EndLocation = "Hobbiton";
                StartMiles = 3872;
                EndMiles = 3405;
            }
        }

        public void CalcProgress(decimal current)
        {
            FindLocations(current);
            CheckpointProgress = Math.Round(((current / EndMiles) * 100), 0);
            TotalProgress = Math.Round(((current / allMiles) * 100), 0);

        }

    }
}
