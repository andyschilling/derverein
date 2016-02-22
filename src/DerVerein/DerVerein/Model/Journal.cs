using System;
using System.Collections.Generic;
using DerVerein.Data;

namespace DerVerein.Model
{
    public class Journal
    {
        public Journal()
        {
            Postings = new List<Posting>();
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Description { get; set; }
        
        public JournalType Type { get; set; }

        public BankAccount Account { get; set; } 

        public IList<Posting> Postings { get; set; } 
    }
}