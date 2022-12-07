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
    public Vector3 LoadPosition;
    public StreamWriter file;

    [SerializeField] float _interval = 1f;
    float _time;
    bool streamOpen = false;
    float avatarDist;
    public Vector3 avatarLoc;
    float vibIntensity;

    //void Start()
    //{
    //    _time = 0f;
    //    Create();
    //}

    void Update()
    {
        _time += Time.deltaTime;
        while (_time >= _interval)
        {
            Save();
            _time -= _interval;
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
        avatarLoc = thisAvatarLoc;
        Create(thisTrial.name);
        
        file.WriteLine($"Trial started: {thisTrial}");
        file.WriteLine($"Avatar activated: {activeAvatar}");
        file.WriteLine($"Avatar location: {thisAvatarLoc}");
        file.WriteLine("xPos , yPos , zPos , xRot , yRot , zRot, DisToAv, vibInt");
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


        //string filePath = @"C:\Users\simone\Documents\testfile.csv"; //On the PC at CWI
        //string filePath = @"C:\Users\20173880\Documents\testfile.csv"; //On my laptop

        //var content = "testing";
        //Debug.Log("Values of position are" + xPos + "," + yPos + "," + zPos);
        //Debug.Log("Values of the rotation are" + xRot + "," + yRot + "," + zRot);
        //File.AppendAllText(filePath, xPos + "," + yPos + "," + zPos + "," + xRot + "," + yRot + "," + zRot + Environment.NewLine);

        //string fname = System.DateTime.Now.ToString("HH-mm-ss") + ".csv";


        //file.WriteLine("Test");
        file.WriteLine(xPos + "," + yPos + "," + zPos + "," + xRot + "," + yRot + "," + zRot + "," + avatarDist + "," + vibIntensity);
        file.Flush();
        //file.Close();
    }

    private void OnDestroy()
    {
        file.Close();
    }
}
