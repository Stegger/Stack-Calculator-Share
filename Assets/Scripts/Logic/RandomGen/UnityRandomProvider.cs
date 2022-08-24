using System;

namespace Logic.RandomGen
{
    public class UnityRandomProvider : IRandomProvider
    {
        public int GetRandomNumber()
        {
            return new Random().Next();
        }
    }
}