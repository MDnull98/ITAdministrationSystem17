using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace WindowsFormsApplication5
{
    class Person
    {
        int id;
        DateTime dateover;
        decimal sum;
        int client;

        public int ID
        { get { return id; }}
        public DateTime Dateover
        {get { return dateover; } }
        public int Client
        { get { return client; } }
        public decimal Sum
        {get { return sum; }  }
        public Person(int id, DateTime dateover, decimal sum, int client)
        {
            this.id = id;
            this.dateover = dateover;
            this.sum = sum;
            this.client= client;
        }
    }
}