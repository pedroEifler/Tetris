using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTetramino : MonoBehaviour
{
    public GameObject[] Tetraminoes;

    // Start is called before the first frame update
    void Start()
    {
        NewTetramino();
    }

    public void NewTetramino()  
    {
        Instantiate(Tetraminoes[Random.Range(0, Tetraminoes.Length)], transform.position, Quaternion.identity);
    }
}
