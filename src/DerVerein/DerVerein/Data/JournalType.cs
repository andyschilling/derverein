using System.ComponentModel;

namespace DerVerein.Data
{
    public enum JournalType
    {
        [Description("Kasse")]
        Cash,

        [Description("Bankkonto")]
        Bank
    }
}