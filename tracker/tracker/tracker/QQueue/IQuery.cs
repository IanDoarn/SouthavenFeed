using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tracker.DataBase;

namespace tracker.QQueue
{
    interface IQuery
    {
        bool Get();

        void FormatResults();

        void WriteJSONFile();
    }
}
