using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    class Test
    {
        int _tutorialId;
        string _tutorialName;

        public void SetTutorial(int pId, string pName)
        {
            _tutorialId = pId;
            _tutorialName = pName;
        }

        public String GetTutorial()
        {
            return _tutorialName;
        }

        static void Main()
        {
        }
    }
}