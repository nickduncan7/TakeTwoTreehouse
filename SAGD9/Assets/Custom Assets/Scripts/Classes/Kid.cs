using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Custom_Assets.Scripts.Classes
{
    public class Kid
    {
        public String Name;
        public String Benefit;
        public String Title;
        public short Acting;
        public short Production;
        public List<Days> Availability;

        public string GetAvailabilityShort()
        {
            string ret = string.Empty;

            if (Availability.Contains(Days.Monday))
                ret += "M ";

            if (Availability.Contains(Days.Tuesday))
                ret += "Tu ";

            if (Availability.Contains(Days.Wednesday))
                ret += "W ";

            if (Availability.Contains(Days.Thursday))
                ret += "Th ";

            if (Availability.Contains(Days.Friday))
                ret += "F";

            ret = ret.TrimEnd(' ');

            return ret;
        }
    }
}
