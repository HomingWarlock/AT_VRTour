using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VrOptions : MonoBehaviour
{
    [SerializeField] private ActionBasedContinuousTurnProvider smooth_turn_comp;
    [SerializeField] private ActionBasedSnapTurnProvider snap_turn_comp;

    public InputActionReference toggle_rotation;
    public bool snap_rot;

    private void Awake()
    {
        toggle_rotation.action.Enable();
        toggle_rotation.action.performed += ToggleRotationMode;

        snap_rot = true;
        snap_turn_comp.enabled = true;
        smooth_turn_comp.enabled = false;

    }

    private void ToggleRotationMode(InputAction.CallbackContext context)
    {
        if (!snap_rot)
        {
            snap_rot = true;
            snap_turn_comp.enabled = true;
            smooth_turn_comp.enabled = false;
            return;
        }

        if (snap_rot)
        {
            snap_rot = false;
            snap_turn_comp.enabled = false;
            smooth_turn_comp.enabled = true;
            return;
        }
    }
}