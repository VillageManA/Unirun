using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public GameObject[] obstacles;
    private bool stepped = false;
    private void OnEnable()
    {
        stepped = false;
        for(int i=0; i<obstacles.Length; i++)
        {
            if(Random.Range(0,3).Equals(0))
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player")&& !stepped)
        {
            stepped = true;
            GameManger.Instance.AddScore(1);
        }
    }

}
