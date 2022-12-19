using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnObject : MonoBehaviour
{
    //public List<GameObject> Trials = new List<GameObject>();
    public List<GameObject> Block1 = new List<GameObject>();
    public List<GameObject> Block2 = new List<GameObject>();
    public List<GameObject> Block3 = new List<GameObject>();
    public List<GameObject> Block4 = new List<GameObject>();
    public List<List<GameObject>> ListOfLists = new List<List<GameObject>>();
    public List<GameObject> chosenList;

    public string currentTrial;
    public GameObject IPQStart;
    public GameObject ClosingCanvas;
    float closingtime = 0f;
    bool needtoClose = false;

    int randomList;
    int randomIndex;

    bool firstBlock = false;

    void Update()
    {
        if (needtoClose == true)
        {
            closingtime += Time.deltaTime;
        }
        if (closingtime >= 5f)
        {
            Application.Quit();
        }
    }

    public void ChooseFirstList()
    {
        chosenList = Block4;
        firstBlock = true;

        ListOfLists.Add(Block2);
        ListOfLists.Add(Block3);
        ListOfLists.Add(Block1);
        Debug.Log($"The ListofLists consits of {ListOfLists.Count} items");
    }

    public void ChooseNextList()
    {
        if (firstBlock == false)
        {
            ListOfLists.Remove(ListOfLists[randomList]);
        }
        Debug.Log($"The ListofLists consits of {ListOfLists.Count} items");

        if (ListOfLists.Count > 0)
        {
            randomList = Random.Range(0, ListOfLists.Count);
            chosenList = ListOfLists[randomList];
            firstBlock = false;
            SpawnTrial();
        } else
        {
            ClosingCanvas.SetActive(true);
            needtoClose = true;
        }

    }

    public void SpawnTrial()
    {   
        Debug.Log($"The list that is chosen:  {chosenList}");
        randomIndex = Random.Range(0, chosenList.Count-1);
        //randomIndex = Random.Range(0, Trials.Count);

        currentTrial = chosenList[randomIndex].ToString();

        chosenList[randomIndex].SetActive(true);
        Debug.Log($"Trial that is activated is: {chosenList[randomIndex]}");
        //chosenList[randomIndex].GetComponent<RandomAvatarSpawner>().SpawnAvatar(chosenList[randomIndex]);
        GameObject.Find("AvatarSpawner").GetComponent<SpawnAvatar>().SpawnAvatarObject(chosenList[randomIndex]);
        //Trials[randomIndex].GetComponent<SavePosition>().SaveTrial(Trials[randomIndex]);
    }

    public void DeactivateTrial()
    {
        chosenList[randomIndex].SetActive(false);
        Debug.Log($"The Trial {chosenList[randomIndex]} is set non active");
        //chosenList[randomIndex].GetComponent<RandomAvatarSpawner>().RemoveAvatar();
        GameObject.Find("AvatarSpawner").GetComponent<SpawnAvatar>().RemoveAvatar();
    }

    public void RemoveTrialFromList()
    {
        Debug.Log($"The Trial {chosenList[randomIndex]} will be removed from the list");
        chosenList.Remove(chosenList[randomIndex]);

        if (chosenList.Count == 0)
        {
            IPQStart.SetActive(true);
        } else
        {
            SpawnTrial();
        }
    }
}
