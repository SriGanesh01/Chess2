using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSquare : MonoBehaviour
{
    private Color originalColor;
    private Color transparentColor;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = GetComponent<MeshRenderer>().material.color;
        transparentColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0.6f); // Adjust the alpha value to make it less opaque
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        Debug.Log($"Mouse entered {gameObject.name}");
        GetComponent<MeshRenderer>().material.color = transparentColor;
    }

    private void OnMouseExit()
    {
        Debug.Log($"Mouse exited {gameObject.name}");
        GetComponent<MeshRenderer>().material.color = originalColor;
    }

    private void OnMouseDown()
    {
        Debug.Log($"Mouse clicked {gameObject.name}");
    }
}
