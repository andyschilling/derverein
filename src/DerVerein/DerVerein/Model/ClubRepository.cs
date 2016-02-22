using System.Collections.Generic;

namespace DerVerein.Model
{
    public class ClubRepository
    {
        public ClubRepository()
        {
            Club = new Club();
            Currencies = new List<Currency>();
        }

        public Club Club { get; set; }

        public IList<Currency> Currencies { get; set; } 

        // public string Json => JsonConvert.SerializeObject(Club);
    }
}