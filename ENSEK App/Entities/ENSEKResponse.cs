using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENSEK_App
{
    public class ENSEKResponse
    {
        public int failedCount { get; set; }
        public int savedCount { get; set; }
        public int totalCount { get; set; }

        public IList<Error> errorDictionary => new List<Error>();

    }

    public class Error
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }
}
