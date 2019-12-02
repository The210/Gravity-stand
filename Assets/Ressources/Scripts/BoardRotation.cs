using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardRotation : MonoBehaviour
{
    public GameObject camerra;
    public GameObject board;
    private bool playerTurn = true;

    void Update()
    {
        if (Input.GetKeyDown("space") && board.transform.rotation.z == 0)
        {
            board.transform.Rotate(0, 0, 90);
            board.transform.position = new Vector3(0, 100, 100);
            camerra.transform.position = new Vector3(-81.3f, 100, 101);
            camerra.transform.rotation = new Quaternion(0.765f, 89.98f, 0.164f, 90);
        }
        if (Input.GetKeyDown("q") && playerTurn)
        {
            board.transform.Rotate(0, 90, 0);
            playerTurn = false;
        }
        if (Input.GetKeyDown("d") && playerTurn)
        {
            board.transform.Rotate(0, -90, 0);
            playerTurn = false;
        }
        if (Input.GetKeyDown("left") && !playerTurn)
        {
            board.transform.Rotate(0, 90, 0);
            playerTurn = true;
        }
        if (Input.GetKeyDown("right") && !playerTurn)
        {
            board.transform.Rotate(0, -90, 0);
            playerTurn = true;
        }
    }
}
