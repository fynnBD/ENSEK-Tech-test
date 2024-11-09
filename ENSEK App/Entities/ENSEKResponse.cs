using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENSEK_App
{
    public class ENSEKResponse
    {
        public int totalUploaded { get; set; }
        public int totalSaved { get; set; }
        public int totalFailed { get; set; }

        public IDictionary<int, string> failures;

    }
}
