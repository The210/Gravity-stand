using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // GameObjects
    public Transform Board;
    public GameObject Piece;
    public GameObject Enemy;
    public GameObject Hole;
    public GameObject wall;

    // pieces //
    public int wallsize;
    public int max_wall;
    public int max_piece;
    public int max_enemy;
    public int max_hole;

    Ray myRay;
    RaycastHit hit;

    public Vector3 AdjustPiece(Vector3 pieceposition)
    {
        pieceposition.x +=  5 - (pieceposition.x % 10);
        pieceposition.z +=  5 - (pieceposition.z % 10);
        print(pieceposition);
       // Debug.Log(pieceposition);
        return (pieceposition);
    }

    Vector3 AdjustWall(Vector3 wallPosition)
    {
        print(wallPosition);
        if (wallPosition.x % 10 >= 7 && wallPosition.z % 10 < 7 && wallPosition.z % 10 > 3)
        {
            wallPosition.z += 5 - (wallPosition.z % 10);
            wallPosition.x -= wallPosition.x % 10;
            wallPosition.x += 10;
            wall.transform.localScale = new Vector3(0.5f, wallsize, 10);
            print("rightt");
        }

        else if (wallPosition.x % 10 <= 3 && wallPosition.z % 10 < 7 && wallPosition.z % 10 > 3)
        {
            wallPosition.z += 5 - (wallPosition.z % 10);
            wallPosition.x -= wallPosition.x % 10;
            wall.transform.localScale = new Vector3(0.5f, wallsize, 10);
            print("left");
        }

        else if (wallPosition.z % 10 <= 3 && wallPosition.x % 10 < 7 && wallPosition.x % 10 > 3)
        {
            wallPosition.x += 5 - (wallPosition.x % 10);
            wallPosition.z -= wallPosition.z % 10;
            wall.transform.localScale = new Vector3(10, wallsize, 0.5f);
            print("up");
        }

        else if (wallPosition.z % 10 >= 7 && wallPosition.x % 10 < 7 && wallPosition.x % 10 > 3)
        {
            wallPosition.x += 5 - (wallPosition.x % 10);
            wallPosition.z -= wallPosition.z % 10;
            wallPosition.z += 10;
            wall.transform.localScale = new Vector3(10, wallsize, 0.5F);
            print("down");
        }
        else
            wallPosition.y = 10000;
        return (wallPosition);

    }
    void Update()
    {          
        if (Input.GetMouseButtonDown(0) && max_piece > 0)
        {
            myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(myRay, out hit) && hit.point.y == 0.5)
            {
               // Debug.Log(hit.point);
                hit.point = AdjustPiece(hit.point);
                GameObject myPrefabClone =  Instantiate(Piece, hit.point, Quaternion.identity);
                myPrefabClone.transform.parent = Board.transform;
                max_piece--;
            }
        }
        if (Input.GetKeyDown("p") && max_enemy > 0)
        {
            myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(myRay, out hit) && hit.point.y == 0.5)
            {
                // Debug.Log(hit.point);
                hit.point = AdjustPiece(hit.point);
                GameObject myPrefabClone = Instantiate(Enemy, hit.point, Quaternion.identity);
                myPrefabClone.transform.parent = Board.transform;
                max_enemy--;
            }
        }
        if (Input.GetMouseButtonDown(1) && max_hole > 0)
        {
            myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(myRay, out hit) && hit.point.y == 0.5)
            {
                // Debug.Log(hit.point);
                hit.point = AdjustPiece(hit.point);
                GameObject myPrefabClone = Instantiate(Hole, hit.point, Quaternion.identity);
                myPrefabClone.transform.parent = Board.transform;
                max_hole--;
            }
        }
        if (Input.GetMouseButtonDown(2) && max_wall > 0)
        {
            myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(myRay, out hit) && hit.point.y == 0.5)
            {
                // Debug.Log(hit.point);
                hit.point = AdjustWall(hit.point);
                if (hit.point.y < 50)
                {
                    GameObject myPrefabClone = Instantiate(wall, hit.point, Quaternion.identity);
                    myPrefabClone.transform.parent = Board.transform;
                    max_wall--;
                }      
            }
        }
        // Redo fonction
        if (Input.GetKeyDown("backspace"))
        {
            myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(myRay, out hit))
            {
                if (hit.transform.tag == "Wall")
                {
                    Destroy(hit.collider.gameObject);
                    max_wall++;
                }
                if (hit.transform.tag == "Piece")
                {
                    Destroy(hit.collider.gameObject);
                    max_piece++;
                }
                if (hit.transform.tag == "Enemy")
                {
                    Destroy(hit.collider.gameObject);
                    max_enemy++;
                }
                if (hit.transform.tag == "Hole")
                {
                    Destroy(hit.collider.gameObject);
                    max_hole++;
                }

            }
        }

    }
}

