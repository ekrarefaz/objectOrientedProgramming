using System;
namespace SwinburneAdventure
{
    public interface IHaveInventory
    {
        public GameObject Locate(string id);
        string Name
        {
            get;
        }
    }
}
