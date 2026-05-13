using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public InputActionReference slashAtack;
    public inventoryManager inventoryManager;
    public PlayerAtack playerAtack;
    void Update()
    {
        if (Input.inputString!= "")
        {
            if (int.TryParse(Input.inputString,out int value))
            {
                changeSlot(value);
            }
        }
    }
    void OnEnable()
    {
        slashAtack.action.started += Slash;
    }
    void OnDisable()
    {
          slashAtack.action.started -= Slash;
    }
    public void changeSlot(int value)
    {
        inventoryManager.selectSlot(value);
    }
    private void Slash(InputAction.CallbackContext obj)
    {
        playerAtack.slashAtack();
    }
}
