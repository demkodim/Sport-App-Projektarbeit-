using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_App.Model
{
    internal class TrainingsAufbau
    {
        public int Id { get; set; }

        public int Anzahl { get; set; }

        public int SportartID { get; set; }

        public Sportart Sportart { get; set; } = null!;

        public int TrainingsplanID { get; set; }

        public List<Trainingsplan> Trainingsplan { get; set; } = null!;

    }
}
