namespace Module6TP1
{
    public class Game
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private int valToFind;
        private int tries;
        #endregion

        #region Properties
        public int ValToFind
        {
            get { return valToFind; }
            set { valToFind = value; }
        }

        public int Tries
        {
            get { return tries; }
            set { tries = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Game()
        {

        }

        public Game(int valToFind)
        {
            this.valToFind = valToFind;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public string Info()
        {
            return string.Format("valeur secrète {0} , trouvé en {1} coup(s).",valToFind, tries);
        }
        #endregion

        #region Events
        #endregion
    }
}