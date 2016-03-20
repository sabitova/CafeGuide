using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CafeGuide
{
    public interface IProcessing
    {
        void GetSuitableCafes(int time, string type, string cuisine, int avgCheck, bool wi_fi);
        void GetTimeForAllCafes(Address from, string mode);
        void FindCafeByName(string name);
        ArrayList GetPlaceInfo(string placeid);


    }
}
