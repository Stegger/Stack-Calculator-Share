namespace Logic.RandomGen
{
    public static class RandomFactory
    {
        public static IRandomProvider CreateRandomProvider(RandomTypes randomTypes)
        {
            return randomTypes switch
            {
                RandomTypes.Unity => new UnityRandomProvider(),
                RandomTypes.Remote => new RemoteRandomProvider(),
                _ => throw new CalculatorException("Unknown Random Provider")
            };
        }
    }

    public enum RandomTypes
    {
        Unity,
        Remote
    }
}