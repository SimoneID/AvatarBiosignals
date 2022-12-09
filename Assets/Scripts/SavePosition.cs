using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public class SavePosition : MonoBehaviour
{
    public float xPos, yPos, zPos, xRot, yRot, zRot;
    public GameObject MainCamera;
    public GameObject TimeWarningCanvas;
    public Vector3 LoadPosition;
    public StreamWriter file;

    [SerializeField] float _interval = 1f;
    float _time;
    float trialTime;
    public bool timeOver = false;
    bool streamOpen = false;
    float avatarDist;
    public Vector3 avatarLoc;
    float vibIntensity;
    double thermalCurrent;
    string thermalTarget;

    //void Start()
    //{
    //    _time = 0f;
    //    Create();
    //}

    void Update()
    {
        _time += Time.deltaTime;
        trialTime += Time.deltaTime;
        //Debug.Log($"trialTime is: {trialTime}");
        while (_time >= _interval)
        {
            Save();
            _time -= _interval;
        }

        if (trialTime >= 30f && timeOver == false)
        {
            TimeWarningCanvas.SetActive(true);
            timeOver = true;
        }
    }

    public void Create(string trialName)
    {
        if (streamOpen == true)
        {
            file.Close();
            streamOpen = false;
        }
        string fname = trialName + ".csv";
        //string fname = "TestFile.csv";
        string path = Path.Combine(Application.persistentDataPath, fname);
        file = new StreamWriter(path, true);
        streamOpen = true;
    }

    public void SaveTrial(GameObject thisTrial, Vector3 thisAvatarLoc, GameObject activeAvatar)
    {
        _time = 0f;
        trialTime = 0f;
        avatarLoc = thisAvatarLoc;
        Create(thisTrial.name);
        
        file.WriteLine($"Trial started: {thisTrial}");
        file.WriteLine($"Avatar activated: {activeAvatar}");
        file.WriteLine($"Avatar location: {thisAvatarLoc}");
        file.WriteLine("trialTime, xPos , yPos , zPos , xRot , yRot , zRot, DisToAv, vibInt, thermalCurrent, thermalTarget");
        file.Flush();
    }

    public void Save()
    {
        xPos = MainCamera.transform.position.x;
        yPos = MainCamera.transform.position.y;
        zPos = MainCamera.transform.position.z;
        xRot = MainCamera.transform.rotation.x;
        yRot = MainCamera.transform.rotation.y;
        zRot = MainCamera.transform.rotation.z;

        avatarDist = Vector3.Distance(avatarLoc, MainCamera.transform.position);
        vibIntensity = GameObject.FindWithTag("HapticManager").GetComponent<HapticManager>().vibInt;

        if (GameObject.FindGameObjectWithTag("ThermalManager") != null)
        {
            thermalCurrent = GameObject.FindWithTag("ThermalManager").GetComponent<ThermalCommunication>().currentTemp;
            thermalTarget = GameObject.FindWithTag("ThermalManager").GetComponent<ThermalCommunication>().communicatedTemp;

            file.WriteLine($"{trialTime},{xPos},{yPos},{zPos},{xRot},{yRot},{zRot},{avatarDist},{vibIntensity},{thermalCurrent},{thermalTarget}");
        } else
        {
            file.WriteLine($"{trialTime},{xPos},{yPos},{zPos},{xRot},{yRot},{zRot},{avatarDist},{vibIntensity}, NA, NA");
        }
        
        file.Flush();
        //file.Close();
    }

    private void OnDestroy()
    {
        file.Close();
    }
}
