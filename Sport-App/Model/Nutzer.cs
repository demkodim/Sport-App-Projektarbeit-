using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_App.Model
{
    internal class Nutzer
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Alter { get; set; }

        public double Gewicht { get; set; }

        public List<Trainingsplan> Trainingsplan { get; set; }


    }
}
