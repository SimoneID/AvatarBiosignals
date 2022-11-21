using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnObject : MonoBehaviour
{
    public List<GameObject> Trialss = new List<GameObject>();
    int randomIndex;

    public void SpawnTrial()
    {
        randomIndex = Random.Range(0, Trialss.Count);
        //GameObject currentTrial = Trialss[randomIndex];
        Trialss[randomIndex].SetActive(true);
        Debug.Log($"Trial that is activated is: {Trialss[randomIndex]}");
        Trialss[randomIndex].GetComponent<RandomAvatarSpawner>().SpawnAvatar();
    }

    public void DeactivateTrial()
    {
        Trialss[randomIndex].SetActive(false);
        Debug.Log("The Trial is set non active");
        Trialss[randomIndex].GetComponent<RandomAvatarSpawner>().RemoveAvatar();
    }

    public void RemoveTrialFromList()
    {
        Trialss.Remove(Trialss[randomIndex]);
        Debug.Log("The Trial is removed from the list");
    }
}
