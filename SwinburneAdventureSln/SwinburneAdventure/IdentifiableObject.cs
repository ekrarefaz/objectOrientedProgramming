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
                if (_identifiers.First() == null)
                    return "";
                else
                    return _identifiers.First();
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

