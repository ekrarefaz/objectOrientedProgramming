using System;
using System.Collections.Generic;

namespace _7._2
{
    public class Path : GameObject
    {
        private string _excp;
        private Location _loctn;

        public Path(string[] ids, string name, string excp, Location place) : base(ids, name, excp)
        {
            _excp = excp;
            _loctn = place;
        }

        public string fullexcp
        {
            get => _excp;
        }
        public Location location
        {
            get
            {
                return _loctn;
            }
        }
    }
}
