using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class ThermalCommunication : MonoBehaviour
{
    float avatarDistance;
    public GameObject MainCamera;
    public double currentTemp;
    public string communicatedTemp;

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
        //StartCoroutine(PostRequest($"http://{hostNameToContact}/power")); //to set heating power
        StartCoroutine(PostRequest($"http://{hostNameToContact}/temperature", "26")); //to set target temperature using PID
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

    void OnDestroy()
    {
        var Coro = PostRequest($"http://{hostNameToContact}/power", "0");
        while (Coro.MoveNext())
        {

        }
        Debug.Log("Power Shutdown");
    }

    public void setNewTemp()
    {
        avatarDistance = Vector3.Distance(GameObject.Find("AvatarSpawner").GetComponent<SpawnAvatar>().LocationAvatar, MainCamera.transform.position);
        if (avatarDistance < 0.46)
        {
            StartCoroutine(PostRequest($"http://{hostNameToContact}/temperature", "36"));
        }
        else if (avatarDistance >= 0.46 && avatarDistance < 1.22)
        {
            StartCoroutine(PostRequest($"http://{hostNameToContact}/temperature", "34"));
        }
        else if (avatarDistance >= 1.22 && avatarDistance < 3.70)
        {
            StartCoroutine(PostRequest($"http://{hostNameToContact}/temperature", "32"));
        }
        else if (avatarDistance >= 3.70)
        {
            StartCoroutine(PostRequest($"http://{hostNameToContact}/temperature", "30"));
        }
    }

    public void setNeuTemp()
    {
        StartCoroutine(PostRequest($"http://{hostNameToContact}/temperature", "26"));
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
                currentTemp = data.temperature;
            }                              
        }
    }

    IEnumerator PostRequest(string uri, string target)
    {
        WWWForm form = new WWWForm();
        form.AddField("target", target);

        using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log($"Form upload complete with temp: {target}!");
                communicatedTemp = target;
            }
        }
    }
}
