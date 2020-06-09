using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> membersList;

        public List<Person> MembersList
        {
            get { return membersList; }
            set { membersList = value; }
        }

        public Family()
        {
            MembersList = new List<Person>();
        }

        public void AddMember(Person member)
        {
            MembersList.Add(member);
        }

        public Person GetOldestMember()
        {
            return membersList.OrderBy(p => p.Age).FirstOrDefault();
        }
    }
}