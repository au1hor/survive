using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public inventoryManager inventoryManager;
    public PlayerAtack playerAtack;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           playerAtack.normalAttack(0);
        }else if (Input.GetMouseButtonDown(1))
        {
             playerAtack.normalAttack(1);
        }
        if (Input.inputString!= "")
        {
            if (int.TryParse(Input.inputString,out int value))
            {
                changeSlot(value);
            }
        }
    }
    public void changeSlot(int value)
    {
        inventoryManager.selectSlot(value);
    }
}
