using System;
using System.Collections.Generic;

namespace Logic.RandomGen
{
    [Serializable]
    public class RandomData
    {
        public string type;
        public int length;
        public List<int> data;
        public bool success;
    }
}