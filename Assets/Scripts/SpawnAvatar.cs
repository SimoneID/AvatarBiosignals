using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAvatar : MonoBehaviour
{
    public List<GameObject> negativeAvatarsMale = new List<GameObject>();
    public List<GameObject> negativeAvatarsFemale = new List<GameObject>();
    public List<GameObject> neutralAvatarsMale = new List<GameObject>();
    public List<GameObject> neutralAvatarsFemale = new List<GameObject>();
    public List<GameObject> positiveAvatarsMale = new List<GameObject>();
    public List<GameObject> positiveAvatarsFemale = new List<GameObject>();
    int avatarIndex;
    int randGender;
    public Vector3 LocationAvatar;
    public Vector2 avatarFlatLocation;
    public int avatarCase = 0; //0 = none, 1 = negative, 2 = neutral, 3 = positive
    public int trialNum = 0;

    public void SpawnAvatarObject(GameObject thisTrial)
    {
        trialNum++;

        if (thisTrial.tag == "NegativeAvatar")
        {
            avatarIndex = Random.Range(0, negativeAvatarsMale.Count);
            randGender = Random.Range(0, 2); //0 = Male , 1 = Female
            if (randGender == 0)
            {
                negativeAvatarsMale[avatarIndex].SetActive(true);
                negativeAvatarsMale[avatarIndex].transform.position = new Vector3(Random.Range(0, 10), 0, Random.Range(-10, 0));
                Debug.Log($"The avatar that is activated: {negativeAvatarsMale[avatarIndex]} at {negativeAvatarsMale[avatarIndex].transform.position}");

                thisTrial.GetComponent<SavePosition>().SaveTrial(trialNum, thisTrial, negativeAvatarsMale[avatarIndex].transform.position, negativeAvatarsMale[avatarIndex]);
                LocationAvatar = negativeAvatarsMale[avatarIndex].transform.position;
                avatarFlatLocation = new Vector2(negativeAvatarsMale[avatarIndex].transform.position.x, negativeAvatarsMale[avatarIndex].transform.position.z);
            } else if (randGender == 1)
            {
                negativeAvatarsFemale[avatarIndex].SetActive(true);
                negativeAvatarsFemale[avatarIndex].transform.position = new Vector3(Random.Range(0, 10), 0, Random.Range(-10, 0));
                Debug.Log($"The avatar that is activated: {negativeAvatarsFemale[avatarIndex]} at {negativeAvatarsFemale[avatarIndex].transform.position}");

                thisTrial.GetComponent<SavePosition>().SaveTrial(trialNum, thisTrial, negativeAvatarsFemale[avatarIndex].transform.position, negativeAvatarsFemale[avatarIndex]);
                LocationAvatar = negativeAvatarsFemale[avatarIndex].transform.position;
                avatarFlatLocation = new Vector2(negativeAvatarsFemale[avatarIndex].transform.position.x, negativeAvatarsFemale[avatarIndex].transform.position.z);
            }      

            avatarCase = 1;

        } else if (thisTrial.tag == "NeutralAvatar")
        {
            avatarIndex = Random.Range(0, neutralAvatarsMale.Count);
            randGender = Random.Range(0, 2); //0 = Male , 1 = Female
            if (randGender == 0)
            {
                neutralAvatarsMale[avatarIndex].SetActive(true);
                neutralAvatarsMale[avatarIndex].transform.position = new Vector3(Random.Range(0, 10), 0, Random.Range(-10, 0));
                Debug.Log($"The avatar that is activated: {neutralAvatarsMale[avatarIndex]} at {neutralAvatarsMale[avatarIndex].transform.position}");

                thisTrial.GetComponent<SavePosition>().SaveTrial(trialNum, thisTrial, neutralAvatarsMale[avatarIndex].transform.position, neutralAvatarsMale[avatarIndex]);
                LocationAvatar = neutralAvatarsMale[avatarIndex].transform.position;
                avatarFlatLocation = new Vector2(neutralAvatarsMale[avatarIndex].transform.position.x, neutralAvatarsMale[avatarIndex].transform.position.z);
            }
            else if (randGender == 1)
            {
                neutralAvatarsFemale[avatarIndex].SetActive(true);
                neutralAvatarsFemale[avatarIndex].transform.position = new Vector3(Random.Range(0, 10), 0, Random.Range(-10, 0));
                Debug.Log($"The avatar that is activated: {neutralAvatarsFemale[avatarIndex]} at {neutralAvatarsFemale[avatarIndex].transform.position}");

                thisTrial.GetComponent<SavePosition>().SaveTrial(trialNum, thisTrial, neutralAvatarsFemale[avatarIndex].transform.position, neutralAvatarsFemale[avatarIndex]);
                LocationAvatar = neutralAvatarsFemale[avatarIndex].transform.position;
                avatarFlatLocation = new Vector2(neutralAvatarsFemale[avatarIndex].transform.position.x, neutralAvatarsFemale[avatarIndex].transform.position.z);
            }

            avatarCase = 2;
        } else if (thisTrial.tag == "PositiveAvatar")
        {
            avatarIndex = Random.Range(0, positiveAvatarsMale.Count);
            randGender = Random.Range(0, 2); //0 = Male , 1 = Female
            if (randGender == 0)
            {
                positiveAvatarsMale[avatarIndex].SetActive(true);
                positiveAvatarsMale[avatarIndex].transform.position = new Vector3(Random.Range(0, 10), 0, Random.Range(-10, 0));
                Debug.Log($"The avatar that is activated: {positiveAvatarsMale[avatarIndex]} at {positiveAvatarsMale[avatarIndex].transform.position}");

                thisTrial.GetComponent<SavePosition>().SaveTrial(trialNum, thisTrial, positiveAvatarsMale[avatarIndex].transform.position, positiveAvatarsMale[avatarIndex]);
                LocationAvatar = positiveAvatarsMale[avatarIndex].transform.position;
                avatarFlatLocation = new Vector2(positiveAvatarsMale[avatarIndex].transform.position.x, positiveAvatarsMale[avatarIndex].transform.position.z);
            }
            else if (randGender == 1)
            {
                positiveAvatarsFemale[avatarIndex].SetActive(true);
                positiveAvatarsFemale[avatarIndex].transform.position = new Vector3(Random.Range(0, 10), 0, Random.Range(-10, 0));
                Debug.Log($"The avatar that is activated: {positiveAvatarsFemale[avatarIndex]} at {positiveAvatarsFemale[avatarIndex].transform.position}");

                thisTrial.GetComponent<SavePosition>().SaveTrial(trialNum, thisTrial, positiveAvatarsFemale[avatarIndex].transform.position, positiveAvatarsFemale[avatarIndex]);
                LocationAvatar = positiveAvatarsFemale[avatarIndex].transform.position;
                avatarFlatLocation = new Vector2(positiveAvatarsFemale[avatarIndex].transform.position.x, positiveAvatarsFemale[avatarIndex].transform.position.z);
            }

            avatarCase = 3;
        }

    }

    public void RemoveAvatar()
    {
        if (avatarCase == 1)
        {
            if (randGender == 0)
            {
                negativeAvatarsMale[avatarIndex].SetActive(false);
                Debug.Log($"The avatar that is de-activated: {negativeAvatarsMale[avatarIndex]}");
                Destroy(negativeAvatarsMale[avatarIndex]);
            }
            else if (randGender == 1)
            {
                negativeAvatarsFemale[avatarIndex].SetActive(false);
                Debug.Log($"The avatar that is de-activated: {negativeAvatarsFemale[avatarIndex]}");
                Destroy(negativeAvatarsFemale[avatarIndex]);
            }

            negativeAvatarsMale.Remove(negativeAvatarsMale[avatarIndex]);
            negativeAvatarsFemale.Remove(negativeAvatarsFemale[avatarIndex]);
        } else if (avatarCase == 2)
        {
            if (randGender == 0)
            {
                neutralAvatarsMale[avatarIndex].SetActive(false);
                Debug.Log($"The avatar that is de-activated: {neutralAvatarsMale[avatarIndex]}");
                Destroy(neutralAvatarsMale[avatarIndex]);
            }
            else if (randGender == 1)
            {
                neutralAvatarsFemale[avatarIndex].SetActive(false);
                Debug.Log($"The avatar that is de-activated: {neutralAvatarsFemale[avatarIndex]}");
                Destroy(neutralAvatarsFemale[avatarIndex]);
            }

            neutralAvatarsMale.Remove(neutralAvatarsMale[avatarIndex]);
            neutralAvatarsFemale.Remove(neutralAvatarsFemale[avatarIndex]);
        } else if (avatarCase == 3)
        {
            if (randGender == 0)
            {
                positiveAvatarsMale[avatarIndex].SetActive(false);
                Debug.Log($"The avatar that is de-activated: {positiveAvatarsMale[avatarIndex]}");
                Destroy(positiveAvatarsMale[avatarIndex]);
            }
            else if (randGender == 1)
            {
                positiveAvatarsFemale[avatarIndex].SetActive(false);
                Debug.Log($"The avatar that is de-activated: {positiveAvatarsFemale[avatarIndex]}");
                Destroy(positiveAvatarsFemale[avatarIndex]);
            }

            positiveAvatarsMale.Remove(positiveAvatarsMale[avatarIndex]);
            positiveAvatarsFemale.Remove(positiveAvatarsFemale[avatarIndex]);
        }
    }
}
