using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Rebinding : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpAction;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TMP_Text bindingDisplayNameText;
    [SerializeField] private GameObject waitingForInputObject;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    private const string RebindsKey = "rebinds";

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        string rebinds = PlayerPrefs.GetString(RebindsKey, string.Empty);

        if (string.IsNullOrEmpty(rebinds)) { return; }

        playerController.PlayerInput.actions.LoadBindingOverridesFromJson(rebinds);

        int bindingIndex = jumpAction.action.GetBindingIndexForControl(jumpAction.action.controls[0]);

        bindingDisplayNameText.text = InputControlPath.ToHumanReadableString(
            jumpAction.action.bindings[bindingIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);
    }

    public void Save()
    {
        string rebinds = playerController.PlayerInput.actions.SaveBindingOverridesAsJson();

        PlayerPrefs.SetString(RebindsKey, rebinds);
    }

    public void StartRebindingJump()
    {
        waitingForInputObject.SetActive(true);

        playerController.PlayerInput.SwitchCurrentActionMap("Remapping");

        rebindingOperation = jumpAction.action.PerformInteractiveRebinding().WithControlsExcluding("Mouse").OnMatchWaitForAnother(0.1f).OnComplete(operation => RebindCompleteJump()).Start();
    }

    private void RebindCompleteJump()
    {
        int bindingIndex = jumpAction.action.GetBindingIndexForControl(jumpAction.action.controls[0]);

        bindingDisplayNameText.text = InputControlPath.ToHumanReadableString(
            jumpAction.action.bindings[bindingIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);

        rebindingOperation.Dispose();

        waitingForInputObject.SetActive(false);

        playerController.PlayerInput.SwitchCurrentActionMap("Mouse+Keyboard");
    }
}