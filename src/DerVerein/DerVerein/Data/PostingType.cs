using System.ComponentModel;

namespace DerVerein.Data
{
    public enum PostingType
    {
        [Description("Einnahme")]
        Income,
        [Description("Ausgabe")]
        Expense
    }
}