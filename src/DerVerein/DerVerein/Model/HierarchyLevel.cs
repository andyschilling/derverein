using System;
using System.Collections.Generic;

namespace DerVerein.Model
{
    public class HierarchyLevel
    {
        public HierarchyLevel()
        {
            Sublevels = new List<HierarchyLevel>();
            MemberhipTypes = new List<MembershipType>();

            Id = Guid.NewGuid();    
        }

        public Guid Id { get; set; } 

        public string Description { get; set; }

        public IList<HierarchyLevel> Sublevels { get; set; } 

        public IList<MembershipType> MemberhipTypes { get; set; } 
    }
}