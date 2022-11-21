using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class ThermalCommunication : MonoBehaviour
{
    public string hostNameToContact;
    [Serializable]
    public class TemperatureResponse
    {
        public double temperature;
    }

    [SerializeField] float _interval = 1f;
    float _time;

    void Start()
    {
        _time = 0f;
        StartCoroutine(PostRequest($"http://{hostNameToContact}/power"));
    }

    void Update()
    {
        _time += Time.deltaTime;
        while (_time >= _interval)
        {
            StartCoroutine(GetRequest($"http://{hostNameToContact}/temperature"));
            _time -= _interval;
        }
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isHttpError || webRequest.isNetworkError)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                //Debug.Log("Succesfully downloaded text");
                var body = webRequest.downloadHandler.text;                
                //Debug.Log($"Body:{body}");
                TemperatureResponse data = JsonUtility.FromJson<TemperatureResponse>(body);
                Debug.Log($"Temperature is now:{data.temperature}");
            }                              
        }
    }

    IEnumerator PostRequest(string uri)
    {
        WWWForm form = new WWWForm();
        form.AddField("target", "-30");

        using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
