using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();
        public IdentifiableObject(string[] idents)
        {
            foreach (string ident in idents)
            {
                _identifiers.Add(ident.ToLower());
            }
        }

        public string FirstId
        {
            get
            {
                return _identifiers[0];
            }
        }

        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }

        
        public void AddIdentifier(string id)
        {
            id = id.ToLower();
            _identifiers.Add(id);
        }
    }
}

