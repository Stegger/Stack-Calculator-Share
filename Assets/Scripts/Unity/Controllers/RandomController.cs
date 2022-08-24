using System;
using System.Collections;
using Logic;
using Logic.RandomGen;
using UnityEngine;
using UnityEngine.Networking;

namespace Unity.Controllers
{
    public class RandomController : MonoBehaviour, IRandomProvider
    {
        private int _nextRandom;
        private readonly string URL = "https://qrng.anu.edu.au/API/jsonI.php?length=1&type=uint8&size=1";
        private IRandomProvider _randomProvider;

        // Start is called before the first frame update
        void Start()
        {
            _randomProvider = RandomFactory.CreateRandomProvider(RandomTypes.Unity);
            try
            {
                StartCoroutine(GetNewRandomInteger());
            }
            catch (Exception e)
            {
                ErrorController.instance.DisplayErrorMessage(e.Message);
            }
        }

        /// <summary>
        /// Asynchronously gets a random number from the remote service
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CalculatorException"></exception>
        IEnumerator GetNewRandomInteger()
        {
            using UnityWebRequest www = UnityWebRequest.Get(URL);
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                // Show results as text
                string json = www.downloadHandler.text;
                var data = JsonUtility.FromJson<RandomData>(json);
                if (data.success)
                {
                    _nextRandom = data.data[0];
                    yield break;
                }
            }

            setRandomFromProvider();
        }

        private void setRandomFromProvider()
        {
            ErrorController.instance.DisplayErrorMessage(
                "Failed to get random number from service. Using local random generator");
            _nextRandom = _randomProvider.GetRandomNumber();
        }

        public int GetRandomNumber()
        {
            StartCoroutine(GetNewRandomInteger());
            return _nextRandom;
        }
    }
}