using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    public Rigidbody rb;
    public float fallSpeed;

    private bool playerTurn = true;

    public Vector3 AdjustPiece(Vector3 pieceposition)
    {
        pieceposition.y += 5 - (pieceposition.y % 10);
        pieceposition.z += 5 - (pieceposition.z % 10);
        print(pieceposition);
        // Debug.Log(pieceposition);
        return (pieceposition);
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        rb.velocity = new Vector3(0, -fallSpeed, 0);
        if ((Input.GetKeyDown("q") || Input.GetKeyDown("d")) && playerTurn)
        {
            this.transform.position = AdjustPiece(this.transform.position);
            playerTurn = false;
        }
        if (!playerTurn && (Input.GetKeyDown("left") || Input.GetKeyDown("right")))
        {
            this.transform.position = AdjustPiece(this.transform.position);
            playerTurn = true;
        }
    }
}
