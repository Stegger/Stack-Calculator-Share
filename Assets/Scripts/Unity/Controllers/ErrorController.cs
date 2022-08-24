using System.Collections;
using TMPro;
using UnityEngine;

namespace Unity.Controllers
{
    public class ErrorController : MonoBehaviour
    {
        public static ErrorController instance { get; private set; }
        public float TimeToDisplayErrors;
        public TMP_Text txtErrorField;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

        public void DisplayErrorMessage(string message)
        {
            txtErrorField.text = message;
            StartCoroutine(CleanupErrorMessages());
        }

        IEnumerator CleanupErrorMessages()
        {
            yield return new WaitForSeconds(TimeToDisplayErrors);
            txtErrorField.text = "";
        }
    }
}