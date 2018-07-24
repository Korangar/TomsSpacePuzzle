using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocitySensitiveSwitch : MonoBehaviour {

    public enum SwitchSetting
    {
        TurnOnAboveVelocity, TurnOnBelowVelocity
    }

    public SwitchSetting activationSetting;
    public float velocity;
    public BoolEvent OnSwitch;

    private Rigidbody2D playerRigidbody;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        bool isOn = false;
        switch (activationSetting)
        {
            case SwitchSetting.TurnOnAboveVelocity:
                isOn = playerRigidbody.velocity.magnitude > velocity;
                break;
            case SwitchSetting.TurnOnBelowVelocity:
                isOn = playerRigidbody.velocity.magnitude < velocity;
                break;
        }

        OnSwitch.Invoke(isOn);
    }
}
