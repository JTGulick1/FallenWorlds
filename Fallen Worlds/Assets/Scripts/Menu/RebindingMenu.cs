using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class RebindingMenu : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpAction = null;
    [SerializeField] private PlayerControllerMenu playerController = null;
    [SerializeField] private TMP_Text bindingDisplayNameText = null;
    [SerializeField] private GameObject waitingForInputObject = null;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    private void Update()
    {
        if(playerController == null) {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerMenu>();
        }
    }

    public void StartRebindingJump()
    {
        waitingForInputObject.SetActive(true);

        playerController.PlayerInput.SwitchCurrentActionMap("Remapping");
        rebindingOperation = jumpAction.action.PerformInteractiveRebinding().WithControlsExcluding("Mouse").OnMatchWaitForAnother(0.1f)
            .WithCancelingThrough("<Keyboard>/escape").OnComplete(operation => RebindCompleteJump()).Start();
    }

    private void RebindCompleteJump()
    {
        int bindingIndex = jumpAction.action.GetBindingIndexForControl(jumpAction.action.controls[0]);

        bindingDisplayNameText.text = InputControlPath.ToHumanReadableString(jumpAction.action.bindings[bindingIndex].effectivePath,InputControlPath.HumanReadableStringOptions.OmitDevice);

        rebindingOperation.Dispose();
        waitingForInputObject.SetActive(false);

        playerController.PlayerInput.SwitchCurrentActionMap("MouseKeyboard");
        Debug.Log(jumpAction.action);
    }
}