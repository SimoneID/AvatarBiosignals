using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAvatarSpawner : MonoBehaviour
{
    public GameObject[] myAvatars;

    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, myAvatars.Length);
        Vector3 randomSpawnPosition = new Vector3(Random.Range(0, 10), 0, Random.Range(-10, 0));

        Instantiate(myAvatars[randomIndex], randomSpawnPosition, Quaternion.identity);
    }
}
