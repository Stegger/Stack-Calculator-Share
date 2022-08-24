using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Logic.RandomGen
{
    public class RemoteRandomProvider : IRandomProvider
    {
        private readonly string URL = "https://qrng.anu.edu.au/API/jsonI.php?length=1&type=uint8&size=1";

        int IRandomProvider.GetRandomNumber()
        {
            return GetRandomNumberFromSource().Result;
        }

        private async Task<int> GetRandomNumberFromSource()
        {
            using UnityWebRequest www = UnityWebRequest.Get(URL);
            www.SetRequestHeader("Content-Type", "application/json");
            UnityWebRequestAsyncOperation asyncOperation = www.SendWebRequest();

            while (!asyncOperation.isDone)
                await Task.Yield();

            if (www.result != UnityWebRequest.Result.Success)
                throw new CalculatorException("Could not get random number from service: " + URL);

            // Show results as text
            string json = www.downloadHandler.text;
            Debug.Log("Json: " + json);

            return 42;
        }
    }
}