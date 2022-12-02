using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarPosition : MonoBehaviour
{
    [SerializeField] Transform Origin;
    [SerializeField] float ActionTime = 1.5f;
    [SerializeField] float WaitTime = 2f;
    float CurrentProgress = 0f;
    bool IsBusy = true;
    
    //float x;
    //float y;
    //float z;
    //Vector3 pos;

    [SerializeField] HapticEffectSO HBEffect;
    void Start()
    {
        //x = Random.Range(0f, 10f);
        //y = 0f;
        //z = Random.Range(0f, -10f);
        //pos = new Vector3(x, y, z);
        //transform.position = pos;
    }

    //void Update()
    //{    
    //    CurrentProgress += Time.deltaTime / (IsBusy ? ActionTime : WaitTime);

    //    if (CurrentProgress >= 1f && gameObject.activeSelf == true)
    //    {
    //        if (!IsBusy)
    //            HapticManager.PlayEffect(HBEffect, Origin.transform.position);

    //        IsBusy = !IsBusy;
    //        CurrentProgress = 0f;
    //    } else if (gameObject.activeSelf == false)
    //    {
    //        HapticManager.StopEffect(HBEffect);
    //    }        
    //}
}
