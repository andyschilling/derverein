using System;

namespace DerVerein.Model
{
    public class MembershipType
    {
        public MembershipType()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { set; get; }

        public string Description { get; set; }

        public double Fee { get; set; }
    }
}