using System;
using System.Collections.Generic;
using System.Linq;
namespace SwinburneAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] identities)
        {
            foreach (string identity in identities)
            {
                _identifiers.Add(identity);
            }
        }
        public string FirstId
        {
            get
            {
                if (_identifiers.Count != 0)
                    return _identifiers[0];
                else
                    return "";
            }
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

