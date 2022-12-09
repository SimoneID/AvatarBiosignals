using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
//using System;
using UnityEngine.UI;

public class SaveAnswersPB : MonoBehaviour
{
    public StreamWriter answersPBFile;
    bool streamAnswersOpen = false;
    public Slider SliderQ1;
    public Slider SliderQ2;
    public Slider SliderQ3;
    public Slider SliderQ4;
    public Slider SliderQ5;
    public Slider SliderQ6;
    public Slider SliderQ7;
    public Slider SliderQ8;
    public Slider SliderQ9;
    public Slider SliderQ10;
    public Slider SliderQ11;
    public Slider SliderQ12;
    public Slider SliderQ13;
    public Slider SliderQ14;

    public string trialName;
    //public List<GameObject> blockName;
    //public string block;

    void Start()
    {
        CreatePBAnswersFile();
    }

    public void CreatePBAnswersFile()
    {
        if (streamAnswersOpen == true)
        {
            answersPBFile.Close();
            streamAnswersOpen = false;
        }
        string fname = "PostBlockData.csv";
        string path = Path.Combine(Application.persistentDataPath, fname);
        answersPBFile = new StreamWriter(path, true);
        streamAnswersOpen = true;
        answersPBFile.WriteLine("Last trial, IPQ1, IPQ2, IPQ3, IPQ4, IPQ5, IPQ6, IPQ7, IPQ8, IPQ9, IPQ10, IPQ11, IPQ12, IPQ13, IPQ14");
    }

    public void SavePBAnswers()
    {
        trialName = GameObject.Find("RandomTrialSpawner").GetComponent<SpawnObject>().currentTrial;
        //blockName = GameObject.Find("RandomTrialSpawner").GetComponent<SpawnObject>().chosenList;
        answersPBFile.WriteLine($"{trialName},{SliderQ1.value},{SliderQ2.value},{SliderQ3.value},{SliderQ4.value},{SliderQ5.value},{SliderQ6.value},{SliderQ7.value},{SliderQ8.value},{SliderQ9.value},{SliderQ10.value},{SliderQ11.value},{SliderQ12.value},{SliderQ13.value},{SliderQ14.value}");
        answersPBFile.Flush();
        Debug.Log("Answers written to PB file");

        SliderQ1.SetValueWithoutNotify(0); //If random wanted: Random.Range(1,8) instead of 1
        SliderQ2.SetValueWithoutNotify(0);
        SliderQ3.SetValueWithoutNotify(0);
        SliderQ4.SetValueWithoutNotify(0);
        SliderQ5.SetValueWithoutNotify(0);
        SliderQ6.SetValueWithoutNotify(0);
        SliderQ7.SetValueWithoutNotify(0);
        SliderQ8.SetValueWithoutNotify(0);
        SliderQ9.SetValueWithoutNotify(0);
        SliderQ10.SetValueWithoutNotify(0);
        SliderQ11.SetValueWithoutNotify(0);
        SliderQ12.SetValueWithoutNotify(0);
        SliderQ13.SetValueWithoutNotify(0);
        SliderQ14.SetValueWithoutNotify(0);
    }

    private void OnDestroy()
    {
        answersPBFile.Close();
    }
}
