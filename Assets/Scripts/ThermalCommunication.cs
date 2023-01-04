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
        //StartCoroutine(PostRequest($"http://{hostNameToContact}/power", "0")); //to set target
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
        Vector2 playerLoc = new Vector2(MainCamera.transform.position.x, MainCamera.transform.position.z);
        avatarDistance = Vector2.Distance(GameObject.Find("AvatarSpawner").GetComponent<SpawnAvatar>().avatarFlatLocation, playerLoc);

        if (avatarDistance < 0.46)
        {
            //StartCoroutine(PostRequest($"http://{hostNameToContact}/temperature", "44"));
            if (currentTemp > 44.00)
            {
                StartCoroutine(PostRequest($"http://{hostNameToContact}/power", "20"));
            }
            else if (currentTemp <= 44.00)
            {
                StartCoroutine(PostRequest($"http://{hostNameToContact}/power", "110"));
            }
            communicatedTemp = "44";
        }
        else if (avatarDistance >= 0.46 && avatarDistance < 1.22)
        {
            //StartCoroutine(PostRequest($"http://{hostNameToContact}/temperature", "42"));
            if (currentTemp > 42.00)
            {
                StartCoroutine(PostRequest($"http://{hostNameToContact}/power", "20"));
            }
            else if (currentTemp <= 42.00)
            {
                StartCoroutine(PostRequest($"http://{hostNameToContact}/power", "110"));
            }
            communicatedTemp = "42";
        }
        else if (avatarDistance >= 1.22 && avatarDistance < 3.70)
        {
            //StartCoroutine(PostRequest($"http://{hostNameToContact}/temperature", "40")); //36 P1 & P2
            if (currentTemp > 40.00)
            {
                StartCoroutine(PostRequest($"http://{hostNameToContact}/power", "10"));
            }
            else if (currentTemp <= 40.00)
            {
                StartCoroutine(PostRequest($"http://{hostNameToContact}/power", "110"));
            }
            communicatedTemp = "40";
        }
        else if (avatarDistance >= 3.70)
        {
            //StartCoroutine(PostRequest($"http://{hostNameToContact}/temperature", "36")); //30 P1 & P2
            if (currentTemp > 36.00)
            {
                StartCoroutine(PostRequest($"http://{hostNameToContact}/power", "10"));
            } else if (currentTemp <= 36.00)
            {
                StartCoroutine(PostRequest($"http://{hostNameToContact}/power", "110"));
            }
            communicatedTemp = "36";
        }
    }

    public void setNeuTemp()
    {
        StartCoroutine(PostRequest($"http://{hostNameToContact}/power", "-1"));
        communicatedTemp = "none";
    }

    public void setCoolingTemp()
    {
        StartCoroutine(PostRequest($"http://{hostNameToContact}/power", "-80"));
        communicatedTemp = "cool";
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
                //communicatedTemp = target;
            }
        }
    }
}
