using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveThroughTrials : MonoBehaviour
{
    static List<string> Trials = new List<string> {"Personal Project - Simone - Trial 1"};

    public void NextTrial()
    {
        if (Trials.Count < 0)
        {
            Debug.Log("This was the last trial");
            //SceneManager.LoadScene("TBD End Scene");
        }
        else
        {
            //randomly choose an index from the list:
            int nextLevelIndex = Random.Range(0, Trials.Count);
            //get the scenename by the index of the list:
            string nextLevel = Trials[nextLevelIndex];
            //remove the scene from the list to make it not appear again:
            Trials.Remove(nextLevel);
            // load the chosen scene:
            SceneManager.LoadScene(nextLevel);
        }
    }
}
