using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
//using System;
using UnityEngine.UI;

public class SaveAnswersPT : MonoBehaviour
{
    public StreamWriter answersPTFile;
    bool streamAnswersOpen = false;
    public Slider SliderQ1;
    public Slider SliderQ2;
    public Slider SliderQ3;

    public string trialName;

    void Start()
    {
        CreateAnswersFile();
    }

    public void CreateAnswersFile()
    {
        if (streamAnswersOpen == true)
        {
            answersPTFile.Close();
            streamAnswersOpen = false;
        }
        string fname = "PostTrialQuestionData.csv";
        string path = Path.Combine(Application.persistentDataPath, fname);
        answersPTFile = new StreamWriter(path, true);
        streamAnswersOpen = true;
        answersPTFile.WriteLine("TrialName, Approachability, Comfort, Arousal");
    }

    public void SavePTAnswers()
    {
        trialName = GameObject.Find("RandomTrialSpawner").GetComponent<SpawnObject>().currentTrial;
        answersPTFile.WriteLine(trialName + "," + SliderQ1.value + "," + SliderQ2.value + "," + SliderQ3.value);
        answersPTFile.Flush();
        Debug.Log("Answers written to file");

        SliderQ1.SetValueWithoutNotify(1); //If random wanted: Random.Range(1,8) instead of 1
        SliderQ2.SetValueWithoutNotify(0);
        SliderQ3.SetValueWithoutNotify(1);
    }

    private void OnDestroy()
    {
        answersPTFile.Close();
    }
}
