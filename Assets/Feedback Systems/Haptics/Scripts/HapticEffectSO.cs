using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Haptic Effect", fileName = "hapticEffect")]

public class HapticEffectSO : ScriptableObject
{
    public enum EType
    {
        OneShot,
        Continuous
    }

    [SerializeField] EType Type = EType.OneShot;

    [SerializeField] float Duration = 0f;

    [SerializeField] float VibrationIntensity = 1f;
    [SerializeField] AnimationCurve VibrationCurve;

    [SerializeField] bool VariesWithDistance = false;
    [SerializeField] float MaxDistance = 25f;
    [SerializeField] AnimationCurve FallOffCurve;

    [System.NonSerialized] Vector3 EffectLocation;
    [System.NonSerialized] float Progress;
    public void Initialise(Vector3 _EffectLocation)
    {
        EffectLocation = _EffectLocation;
        Progress = 0f;
    }

    public bool Tick(Vector3 receiverPosition, out float vibSpeed)
    {
        // update the progess
        Progress += Time.deltaTime / Duration;

        // calculating the distance factor
        float distanceFactor = 1f;
        if (VariesWithDistance)
        {
            float distance = (receiverPosition - EffectLocation).magnitude;
            distanceFactor = distance  >= MaxDistance ? 0f : FallOffCurve.Evaluate( distance / MaxDistance);
        }

        vibSpeed = VibrationIntensity * distanceFactor * VibrationCurve.Evaluate(Progress);

        // Check if finished
        if (Progress >= 1f)
        {
            if (Type == EType.OneShot)
                return true;

            Progress = 0f;
        }

        return false;
    }

}
