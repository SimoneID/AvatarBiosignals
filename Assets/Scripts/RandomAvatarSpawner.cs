using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAvatarSpawner : MonoBehaviour
{
    public List<GameObject> Avatars = new List<GameObject>();
    int randomGender;
    public static Vector3 LocationAvatar;

    //[SerializeField] Transform Origin;
    [SerializeField] float ActionTime = 1.5f;
    [SerializeField] float WaitTime = 2f;
    float CurrentProgress = 0f;
    bool IsBusy = true;
    [SerializeField] HapticEffectSO HBEffect;

    // Start is called before the first frame update
    public void SpawnAvatar(GameObject thisTrial)
    {
        randomGender = Random.Range(0, Avatars.Count);
        Avatars[randomGender].SetActive(true);
        Avatars[randomGender].transform.position = new Vector3(Random.Range(0, 10), 0, Random.Range(-10, 0));
        Debug.Log($"The avatar that is activated: {Avatars[randomGender]} at {Avatars[randomGender].transform.position}");

        thisTrial.GetComponent<SavePosition>().SaveTrial(thisTrial, Avatars[randomGender].transform.position, Avatars[randomGender]);

        //Vector3 randomSpawnPosition = new Vector3(Random.Range(0, 10), 0, Random.Range(-10, 0));
        //clone = Instantiate(Avatars[randomGender], randomSpawnPosition, Quaternion.identity);
    }

    public void RemoveAvatar()
    {
        HapticManager.StopEffect(HBEffect);
        Avatars[randomGender].SetActive(false);
        Debug.Log($"The avatar that is de-activated: {Avatars[randomGender]}");
    }

    void Update()
    {
        CurrentProgress += Time.deltaTime / (IsBusy ? ActionTime : WaitTime);

        if (CurrentProgress >= 1f && gameObject.activeInHierarchy)
        {
            if (!IsBusy)
                HapticManager.PlayEffect(HBEffect, Avatars[randomGender].transform.position);

            IsBusy = !IsBusy;
            CurrentProgress = 0f;
        }
    }
}
