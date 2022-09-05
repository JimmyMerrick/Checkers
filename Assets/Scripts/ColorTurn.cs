using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTurn : MonoBehaviour
{
    public bool blueTurn;
    private bool blueTurnChange;
    // Start is called before the first frame update
    void Start()
    {
        blueTurn = true;
    }

    
    public void ChangeBlueTurn(bool blueTurn) {
        blueTurnChange = blueTurn;

        if (blueTurnChange) {
            blueTurn = false;
        } else {
            blueTurn = true;
        }
    }

    public bool GetBlueTurn() {
        return blueTurn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
