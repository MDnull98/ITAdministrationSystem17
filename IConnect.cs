using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication5
{
    interface IConnect
    {
        void connect();
        void connect(string k);
        void connect(string k, string m);
        void Open();
        void Close();
    }
}
