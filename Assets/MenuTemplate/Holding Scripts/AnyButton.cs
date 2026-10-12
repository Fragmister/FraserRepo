using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private bool buttonPress;
    
    void Update()
    {
        InputSystem.onAnyButtonPress.Call(currentAction =>
        {
            buttonPress = true;
            if (currentAction is ButtonControl button && buttonPress)
            {
                buttonPress = false;
            }
        });
    }
}


