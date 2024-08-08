using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPieces : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log($"Mouse clicked {gameObject.name}");
    }

    private void OnMouseEnter()
    {
        Debug.Log($"Mouse entered {gameObject.name}");
    }

    private void OnMouseExit()
    {
        Debug.Log($"Mouse exited {gameObject.name}");
    }
}
