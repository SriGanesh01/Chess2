using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardUI : MonoBehaviour
{
    public Material squareMaterial;
    float BoardOffset = 3.5f;
    public Color lightCol = new Color(143f / 255f, 216f / 255f, 216f / 255f);
    public Color darkCol = new Color(48f / 255f, 119f / 255f, 119f / 255f);
    private Dictionary<int, string> fileNames = new Dictionary<int, string>(){
        {0, "A"},
        {1, "B"},
        {2, "C"},
        {3, "D"},
        {4, "E"},
        {5, "F"},
        {6, "G"},
        {7, "H"}
    };

    private void Awake() {
        CreateBoard();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateBoard()
    {
        for (int rank = 0; rank < 8; rank++)
        {
            for (int file = 0; file < 8; file++)
            {
                // Create square
                GameObject square = GameObject.CreatePrimitive(PrimitiveType.Quad);
                //GameObject InnerSquare = GameObject.CreatePrimitive(PrimitiveType.Quad);
                square.transform.parent = transform;
                //InnerSquare.transform.parent = square.transform;
                square.name = $"{fileNames[file]}{rank+1}";
                square.transform.position = new Vector3(file - BoardOffset, rank - BoardOffset, 0);
                //InnerSquare.transform.position = new Vector3(file - BoardOffset, rank - BoardOffset, -0.1f);

                // Set square color
                MeshRenderer renderer = square.GetComponent<MeshRenderer>();
                //MeshRenderer InnerRenderer = InnerSquare.GetComponent<MeshRenderer>();
                renderer.material = squareMaterial;
                //InnerRenderer.material = squareMaterial;
                renderer.material.color = (file + rank) % 2 == 0 ? lightCol : darkCol;
                //InnerRenderer.material.color = Color.clear;

                // Pieces.BPawn(new Vector3(file - BoardOffset, rank - BoardOffset, 0));

                // Add collider to square
                BoxCollider collider = square.AddComponent<BoxCollider>();
                collider.size = new Vector3(1, 1, 0);

                // Add the Square component
                square.AddComponent<SelectSquare>();
            }
        }
    }
}
