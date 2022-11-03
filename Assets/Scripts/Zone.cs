using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    //HapticController neededScript;

    public AudioSource audioSource;
    public AudioClip TestAudio;
    public float volume = 0.5f;

    [SerializeField] string TagToCheck = "Player"; //You can overwrite this in the field in Unity
    [SerializeField] HapticEffectSO HapticEffect;

    HapticEffectSO ActiveEffect = null;

    List<GameObject> PlayersInZone = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //neededScript = GameObject.FindGameObjectWithTag("Needed").GetComponent<HapticController>(); //reference to simple haptic script
    }

        void OnTriggerEnter(Collider other) //Collider only reacts to objects with a RigidBody (so not the MainCamera or Controllers)
        {
            if (other.CompareTag(TagToCheck))
            {
                // players now in the zone - start the effect
                if (PlayersInZone.Count == 0)
                    audioSource.PlayOneShot(TestAudio, volume);
                    ActiveEffect = HapticManager.PlayEffect(HapticEffect, transform.position);
                    //neededScript.SendHaptics(0.4f, 0.8f);
                Debug.Log("Player is in the zone now");
                PlayersInZone.Add(other.gameObject);
            }
        }
    

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TagToCheck))
        {
            PlayersInZone.Remove(other.gameObject);

            // no players left in the zone, stop the effect
            if (PlayersInZone.Count == 0)
            {
                HapticManager.StopEffect(ActiveEffect);
                ActiveEffect = null;
                //neededScript.SendHaptics(0.4f, 0.4f);
                Debug.Log("Player is out the zone now");
            }
        }
    }
}
