using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
//using UnityEngine.InputSystem;



public class HapticManager : MonoBehaviour
{
    [SerializeField] public XRBaseController leftController;
    [SerializeField] public XRBaseController rightController;
    public static HapticManager Instance { get; private set; } = null;

    List<HapticEffectSO> ActiveEffects = new List<HapticEffectSO>();
    public static HapticEffectSO PlayEffect(HapticEffectSO effect, Vector3 location)
    {
        return Instance.PlayEffect_Internal(effect, location);
    }

    public static void StopEffect(HapticEffectSO effect)
    {
        Instance.StopEffect_Internal(effect);
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Attempting to create second HapticManager on " + gameObject.name);

            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vibSpeedMotor = 0f;

        for (int index = 0; index < ActiveEffects.Count; ++index)
        {
            var effect = ActiveEffects[index];

            // tick the effect and clean up if finished
            float vibSpeedComponent = 0f;
            
            if (effect.Tick(Camera.main.transform.position, out vibSpeedComponent))
            {
                ActiveEffects.RemoveAt(index);
                --index;
            }

            vibSpeedMotor = Mathf.Clamp01(vibSpeedComponent + vibSpeedMotor);

            //Debug.Log(highSpeedComponent);
            Debug.Log("Player is in the zone now");
        }

        //Gamepad.current.SetMotorSpeeds(lowSpeedMotor, highSpeedMotor);
        leftController.SendHapticImpulse(vibSpeedMotor, 1f);
    }

    void OnDestroy()
    {
        leftController.SendHapticImpulse(0f,0f);
        rightController.SendHapticImpulse(0f, 0f);
    }


    HapticEffectSO PlayEffect_Internal(HapticEffectSO effect, Vector3 location)
    {
        // setup the effect
        var activeEffect = ScriptableObject.Instantiate(effect);
        activeEffect.Initialise(location);

        ActiveEffects.Add(activeEffect);

        return activeEffect;
    }

    void StopEffect_Internal(HapticEffectSO effect)
    {
        ActiveEffects.Remove(effect);
    }
}
