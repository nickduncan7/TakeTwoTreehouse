using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Custom_Assets.Scripts.Classes
{
    public class Scene
    {
        public Guid ID;
        public List<Kid> Cast;
        public List<Kid> FailedCast;
        public bool Success;

        public Scene()
        {
            Cast = new List<Kid>();
            FailedCast = new List<Kid>();
        }
    }
}
