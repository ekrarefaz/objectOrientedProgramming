using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _explaination;
        private string _name;

        public GameObject(string[] ids, string name, string excp) : base(ids)
        {
            _explaination = excp;
            _name = name;
        }

        public string ShortExplaination
        {
            get
            {
                return _name + " (" + this.FirstId + ")";
            }
        }

        public string Name
        {
            get => _name;
        }

        public virtual string FullExplaination
        {
            get => _explaination;
        }
    }
}

