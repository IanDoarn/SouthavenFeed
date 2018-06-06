using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracker.QQueue
{
    public abstract class Query : IQuery
    {
        public abstract string FileName { get; }
        public abstract string QueryName { get; }
        public abstract void FormatResults();
        public abstract bool Get();
        public abstract void WriteJSONFile();
    }
}
