using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAvatarSpawner : MonoBehaviour
{
    public List<GameObject> Avatars = new List<GameObject>();
    int randomGender;
    public static Vector3 LocationAvatar;

    // Start is called before the first frame update
    public void SpawnAvatar(GameObject thisTrial)
    {
        randomGender = Random.Range(0, Avatars.Count);
        Avatars[randomGender].SetActive(true);
        Avatars[randomGender].transform.position = new Vector3(Random.Range(0, 10), 0, Random.Range(-10, 0));
        Debug.Log($"The avatar that is activated: {Avatars[randomGender]} at {Avatars[randomGender].transform.position}");

        thisTrial.GetComponent<SavePosition>().SaveTrial(thisTrial, Avatars[randomGender].transform.position);

        //Vector3 randomSpawnPosition = new Vector3(Random.Range(0, 10), 0, Random.Range(-10, 0));
        //clone = Instantiate(Avatars[randomGender], randomSpawnPosition, Quaternion.identity);
    }

    public void RemoveAvatar()
    {
        Avatars[randomGender].SetActive(false);
        Debug.Log($"The avatar that is de-activated: {Avatars[randomGender]}");
    }
}
