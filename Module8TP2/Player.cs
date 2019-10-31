using Module8TP2ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module8TP2
{
    public class Player : Personne
    {
        private Game[] games;

        public Game[] Games
        {
            get { return games; }
            set { games = value; }
        }

        public Player(string firstname, string lastname) : base(firstname, lastname)
        {
            this.games = new Game[20];
        }
    }
}
