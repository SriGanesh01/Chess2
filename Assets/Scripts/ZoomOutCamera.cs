using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ZoomOutCamera : MonoBehaviour
{
    public GlobalConstants globalConstants;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        globalConstants = FindObjectOfType<GlobalConstants>();
        cam.orthographicSize = globalConstants.boardSize / 2f + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
