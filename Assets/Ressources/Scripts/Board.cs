using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;
    public int height;
    public int cell;
    void Start()
    {
        width *= cell;
        height *= cell;
        this.transform.localScale = new Vector3(width, 1, height);
    }
}
