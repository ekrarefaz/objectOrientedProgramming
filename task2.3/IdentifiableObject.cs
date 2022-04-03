using System;
using System.Collections.Generic;
using System.Linq;
namespace SwinAdventure
{
    public class IdentifiableObject
    {
        public class id
        {
            private List<string> _identifiers = new List<string>();
            public string _firstid;

            public id(string[] identities)
            {
                foreach (string identity in identities)
                {
                    _identifiers.Add(identity);
                }
            }
            public string FirstId()
            {
                return _identifiers.First();
            }

            public bool AreYou(string id)
            {
                return _identifiers.Contains(id.ToLower());
            }

            public void AddIdentifier(string id)
            {
                _identifiers.Add(id.ToLower());
            }
        }
    }

}

