using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollObject : MonoBehaviour
{

    public float speed = 10f;
    

    // Update is called once per frame
    void Update()
    {
        if(!GameManger.Instance.isGameOver)
        {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
