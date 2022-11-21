using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAvatarSpawner : MonoBehaviour
{
    public GameObject[] myAvatars;
    GameObject clone;
    int randomIndex;

    // Start is called before the first frame update
    public void SpawnAvatar()
    {
        randomIndex = Random.Range(0, myAvatars.Length);
        Vector3 randomSpawnPosition = new Vector3(Random.Range(0, 10), 0, Random.Range(-10, 0));

        clone = Instantiate(myAvatars[randomIndex], randomSpawnPosition, Quaternion.identity);
    }

    public void RemoveAvatar()
    {
        myAvatars[randomIndex].SetActive(false);
        Destroy(clone);
    }
}
