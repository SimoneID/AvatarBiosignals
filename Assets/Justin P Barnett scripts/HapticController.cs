using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//This script allows for sending simple haptic impulses, it allows for setting the amplitude, duration, and controller.

public class HapticController : MonoBehaviour
{
    [SerializeField] public XRBaseController leftController;
    [SerializeField] public XRBaseController rightController;
    public float defaultAmplitude = 0.2f;
    public float defaultDuration = 0.5f;

    [ContextMenu("Send Haptics")]

    public void SendHaptics()
    {
        leftController.SendHapticImpulse(defaultAmplitude, defaultDuration);
        rightController.SendHapticImpulse(defaultAmplitude, defaultDuration);
    }

    public void SendHaptics(float amplitude, float duration)
    {
        leftController.SendHapticImpulse(amplitude, duration);
        rightController.SendHapticImpulse(amplitude, duration);
    }

    public void SendHaptics(bool isLeftController, float amplitude, float duration)
    {
        if (isLeftController)
        {
            leftController.SendHapticImpulse(amplitude, duration);
        }
        else
        {
            rightController.SendHapticImpulse(amplitude, duration);
        }        
    }

    public void SendHaptics(XRBaseController controller, float amplitude, float duration)
    {
        controller.SendHapticImpulse(amplitude, duration);
    }
}