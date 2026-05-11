using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public InputActionReference slashAtack;
    public InputActionReference numberKey;
    public inventoryManager inventoryManager;
    public PlayerAtack playerAtack;
    void OnEnable()
    {
        slashAtack.action.started += Slash;
        numberKey.action.started += OnTap;
    }
    void OnDisable()
    {
          slashAtack.action.started -= Slash;
           numberKey.action.started -= OnTap;
    }
    private void Slash(InputAction.CallbackContext obj)
    {
        playerAtack.slashAtack();
    }
    public void OnTap(InputAction.CallbackContext context)
    {
        string keyname = context.control.name;
        if (int.TryParse(keyname,out int value))
        {
            inventoryManager.selectSlot(value);
        }
    }
}
