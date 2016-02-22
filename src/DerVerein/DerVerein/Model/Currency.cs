namespace DerVerein.Model
{
    public class Currency
    {
        public string Key { get; set; }
        
        public string Description { get; set; }

        public string Sign { get; set; }

        public override string ToString() => Description;
    }
}