using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public InputActionReference slashAtack;
    public PlayerAtack playerAtack;
    void OnEnable()
    {
        slashAtack.action.started += Slash;
    }
    void OnDisable()
    {
          slashAtack.action.started -= Slash;
    }
    private void Slash(InputAction.CallbackContext obj)
    {
        playerAtack.slashAtack();
    }
}
