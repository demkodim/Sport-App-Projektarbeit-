using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_App.Model
{
    internal class Trainingsplan
    {
        public int Id { get; set; }
        
        public int NutzerID { get; set; }

        public Nutzer Nutzer { get; set; } = null!;

        public List<TrainingsAufbau> TrainingsAufbau { get; set; } = null!;

        public int TrainingZeit { get; set; }
    }
}
