using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    private int width = 10;
    private int height = 13;

    [SerializeField]private GameObject spritePrefab;
    [SerializeField]private float offset;

    private void Start()
    {
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                var currentButton = Instantiate(spritePrefab, new Vector3(i * offset, j * offset, 0), Quaternion.identity);
            }
        }
    }
}
