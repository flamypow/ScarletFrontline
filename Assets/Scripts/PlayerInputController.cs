using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    InputForPucks playerI;
    void OnEnable()
    {
        playerI = new InputForPucks();
        if (playerI != null)
        {
            //add in attack here once I am ready.
            playerI.PlayerActions.Aim.performed += (val) => PlayerController.Instance.Aim(val.ReadValue<float>());
            playerI.PlayerActions.ChargePower.performed += (val) => PlayerController.Instance.ChargePower();
            playerI.PlayerActions.ChargePower.canceled += (val) => PlayerController.Instance.ChargePowerReleased();

        }
        playerI.Enable();
    }

    private void OnDisable()
    {
        playerI.Disable();
    }
}