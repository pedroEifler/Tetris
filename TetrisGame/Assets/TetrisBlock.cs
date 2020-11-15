using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour {
    public Vector3 rotationPoint;
    private float previousTime;
    public float fallTime = 0.8f;
    private int height = 20;
    private int widght = 10;
    private static Transform[,] grid = new Transform[widght, height]

    // Start is called before the first frame update 
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.LeftArrow)) {
            transform.position += new Vector3 (-1, 0, 0);
            if (!ValidMoviment ()) {
                transform.position += new Vector3 (1, 0, 0);
            }
        } else if (Input.GetKeyDown (KeyCode.RightArrow)) {
            transform.position += new Vector3 (1, 0, 0);
            if (!ValidMoviment ()) {
                transform.position += new Vector3 (-1, 0, 0);
            }
        } else if (Input.GetKeyDown (KeyCode.UpArrow)) {
            transform.RotateAround (transform.TransformPoint (rotationPoint), new Vector3 (0, 0, 1), 90);
            if (!ValidMoviment ()) {
                transform.RotateAround (transform.TransformPoint (rotationPoint), new Vector3 (0, 0, 1), -90);
            }
        }

        if (Time.time - previousTime > (Input.GetKey (KeyCode.DownArrow) ? fallTime / 10 : fallTime)) {
            transform.position += new Vector3 (0, -1, 0);
            if (!ValidMoviment ()) {
                transform.position -= new Vector3 (0, -1, 0);
                this.enabled = false;
                FindObjectOfType<SpawnTetramino>().NewTetramino();
            }
            previousTime = Time.time;
        }
    }

    bool ValidMoviment () {
        foreach (Transform children in transform) {
            int roundedX = Mathf.RoundToInt (children.transform.position.x);
            int roundedY = Mathf.RoundToInt (children.transform.position.y);

            if (roundedX < 0 || roundedX >= widght || roundedY < 0 || roundedY >= height) {
                return false;
            }
        }
        return true;
    }
}