using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

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

        public string Json => JsonConvert.SerializeObject(Club);

        protected void CreateClub(Club newClub)
        {
            Club = newClub;
            if (Club.Id == Guid.Empty)
            {
                Club.Id = Guid.NewGuid();
            }
        }

        public void CreateHierarchyRoot()
        {
            Club.Organization = new HierarchyLevel {Description = Club.Name};
        }

        public void CreateHierarchyLevel(HierarchyLevel parent, HierarchyLevel level)
        {
            CreateHierarchyLevelRecursive(parent, level, Club.Organization);
        }

        public HierarchyLevel ReadHierarchyLevel(Guid id)
        {
            return ReadHierarchyLevelRecursive(id, Club.Organization);
        }

        public void CreateMembershipType(HierarchyLevel parent, MembershipType memberType)
        {
            CreateMembershipTypeRecursive(parent, memberType, Club.Organization);
        }

        public MembershipType ReadMembershipType(Guid id)
        {
            return ReadMembershipTypeRecursive(id, Club.Organization);
        }

        private bool CreateHierarchyLevelRecursive(HierarchyLevel parent, HierarchyLevel level, HierarchyLevel organization)
        {
            if (organization == parent)
            {
                organization.Sublevels.Add(level);
                return true;
            }

            return organization.Sublevels.Select(sublevel => 
                        CreateHierarchyLevelRecursive(parent, level, sublevel)).Any(result => result);
        }

        private HierarchyLevel ReadHierarchyLevelRecursive(Guid id, HierarchyLevel hierarchyLevel)
        {
            return hierarchyLevel.Id == id ? hierarchyLevel : hierarchyLevel.Sublevels.Select(sublevel => ReadHierarchyLevelRecursive(id, sublevel)).FirstOrDefault(level => level.Id == id);
        }

        private bool CreateMembershipTypeRecursive(HierarchyLevel parent, MembershipType memberType, HierarchyLevel organization)
        {
            if (organization == parent)
            {
                organization.MemberhipTypes.Add(memberType);
                return true;
            }

            return organization.Sublevels.Select(sublevel => 
                        CreateMembershipTypeRecursive(parent, memberType, sublevel)).Any(result => result);
        }

        private MembershipType ReadMembershipTypeRecursive(Guid id, HierarchyLevel currentLevel)
        {
            foreach (var membershipType in currentLevel.MemberhipTypes)
            {
                if (membershipType.Id == id)
                {
                    return membershipType;
                }
            }

            return currentLevel.Sublevels.Select(sublevel => 
                        ReadMembershipTypeRecursive(id, sublevel)).FirstOrDefault(type => type.Id == id);
        }
    }
}