using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ThermalCommunication : MonoBehaviour
{
    public string hostNameToContact;
    void Start()
    {
        StartCoroutine(getRequest($"http://{hostNameToContact}:5000/peltier/37.3"));
    }

    IEnumerator getRequest(string uri)
    {
        using (UnityWebRequest uwr = UnityWebRequest.Get(uri))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Error While Sending to {uri}: {uwr.error}");
            }
            else
            {
                Debug.Log($"Received from {uri}: {uwr.downloadHandler.text}");
            }
        }

    }
}
