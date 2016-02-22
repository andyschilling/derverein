using System;

namespace DerVerein.Model
{
    public class Member
    {
        public Member()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public int MembershipNumber { get; set; }

        public string GivenName { get; set; }
        
        public string FamilyName { get; set; }
        
        public DateTime Birthday { get; set; }

        public Address Address { get; set; }

        public Contact Contact { get; set; }

        public BankAccount Account { get; set; }

        public override string ToString()
        {
            return $"{GivenName} {FamilyName}";
        }
    }
}