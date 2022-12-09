using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class setThermal : MonoBehaviour
{
    [SerializeField] float _interval = 1f;
    float _time;

    void Start()
    {
        _time = 0f;
    }

    void Update()
    {
        _time += Time.deltaTime;
        while (_time >= _interval)
        {
            if (GameObject.FindGameObjectWithTag("ThermalManager") != null)
            {
                GameObject.FindWithTag("ThermalManager").GetComponent<ThermalCommunication>().setNewTemp();
            }
            
            _time -= _interval;
        }
    }
}
