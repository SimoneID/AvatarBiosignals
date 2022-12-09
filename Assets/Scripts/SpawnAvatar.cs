using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAvatar : MonoBehaviour
{
    public List<GameObject> negativeAvatars = new List<GameObject>();
    public List<GameObject> neutralAvatars = new List<GameObject>();
    public List<GameObject> positiveAvatars = new List<GameObject>();
    int avatarIndex;
    public Vector3 LocationAvatar;
    public int avatarCase = 0; //0 = none, 1 = negative, 2 = neutral, 3 = positive

    public void SpawnAvatarObject(GameObject thisTrial)
    {
        if (thisTrial.tag == "NegativeAvatar")
        {
            avatarIndex = Random.Range(0, negativeAvatars.Count);
            negativeAvatars[avatarIndex].SetActive(true);
            negativeAvatars[avatarIndex].transform.position = new Vector3(Random.Range(0, 10), 0, Random.Range(-10, 0));
            Debug.Log($"The avatar that is activated: {negativeAvatars[avatarIndex]} at {negativeAvatars[avatarIndex].transform.position}");

            thisTrial.GetComponent<SavePosition>().SaveTrial(thisTrial, negativeAvatars[avatarIndex].transform.position, negativeAvatars[avatarIndex]);
            LocationAvatar = negativeAvatars[avatarIndex].transform.position;

            avatarCase = 1;
        } else if (thisTrial.tag == "NeutralAvatar")
        {
            avatarIndex = Random.Range(0, neutralAvatars.Count);
            neutralAvatars[avatarIndex].SetActive(true);
            neutralAvatars[avatarIndex].transform.position = new Vector3(Random.Range(0, 10), 0, Random.Range(-10, 0));
            Debug.Log($"The avatar that is activated: {neutralAvatars[avatarIndex]} at {neutralAvatars[avatarIndex].transform.position}");

            thisTrial.GetComponent<SavePosition>().SaveTrial(thisTrial, neutralAvatars[avatarIndex].transform.position, neutralAvatars[avatarIndex]);
            LocationAvatar = neutralAvatars[avatarIndex].transform.position;

            avatarCase = 2;
        } else if (thisTrial.tag == "PositiveAvatar")
        {
            avatarIndex = Random.Range(0, positiveAvatars.Count);
            positiveAvatars[avatarIndex].SetActive(true);
            positiveAvatars[avatarIndex].transform.position = new Vector3(Random.Range(0, 10), 0, Random.Range(-10, 0));
            Debug.Log($"The avatar that is activated: {positiveAvatars[avatarIndex]} at {positiveAvatars[avatarIndex].transform.position}");

            thisTrial.GetComponent<SavePosition>().SaveTrial(thisTrial, positiveAvatars[avatarIndex].transform.position, positiveAvatars[avatarIndex]);
            LocationAvatar = positiveAvatars[avatarIndex].transform.position;

            avatarCase = 3;
        }

    }

    public void RemoveAvatar()
    {
        //HapticManager.StopEffect(HBEffect);
        if (avatarCase == 1)
        {
            negativeAvatars[avatarIndex].SetActive(false);
            Debug.Log($"The avatar that is de-activated: {negativeAvatars[avatarIndex]}");
            Destroy(negativeAvatars[avatarIndex]);
            negativeAvatars.Remove(negativeAvatars[avatarIndex]);            
        } else if (avatarCase == 2)
        {
            neutralAvatars[avatarIndex].SetActive(false);
            Debug.Log($"The avatar that is de-activated: {neutralAvatars[avatarIndex]}");
            Destroy(neutralAvatars[avatarIndex]);
            neutralAvatars.Remove(neutralAvatars[avatarIndex]);            
        } else if (avatarCase == 3)
        {
            positiveAvatars[avatarIndex].SetActive(false);
            Debug.Log($"The avatar that is de-activated: {positiveAvatars[avatarIndex]}");
            Destroy(positiveAvatars[avatarIndex]);
            positiveAvatars.Remove(positiveAvatars[avatarIndex]);            
        }
    }
}
