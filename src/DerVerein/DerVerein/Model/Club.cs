using System;
using System.Collections.Generic;

namespace DerVerein.Model
{
    public class Club
    {
        public Club()
        {
            Members = new List<Member>();
            Journals = new List<Journal>();

            Organization = new HierarchyLevel();

            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public DateTime FoundationDate { get; set; }

        public string DefaultCurrency { get; set; }
        
        public Address Address { get; set; }
        
        public Contact Contact { get; set; } 

        public BankAccount Account { get; set; }

        public IList<Member> Members { get; set; } 

        public IList<Journal> Journals { get; set; } 

        public HierarchyLevel Organization { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}