using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pion : MonoBehaviour
{
    public GameObject piece;
    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.tag == "Hole")
        {
            Debug.Log("hole hit");
            Destroy(piece);
        }
    }
}
