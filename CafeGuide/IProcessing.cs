using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeGuide
{
    interface IProcessing
    {
        List<Cafe> GetSuitableCafes(int time, string type, string cuisine, int avgCheck, bool wi_fi);
    }
}
