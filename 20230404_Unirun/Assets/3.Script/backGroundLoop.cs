using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGroundLoop : MonoBehaviour
{
    private float width;

    private void Awake()
    {
        // BoxCollider2D boxcolider = transform.GetComponent(BoxCollider2D);
        width = transform.GetComponent<BoxCollider2D>().size.x;
    }
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<= -width)
        {
            Reposition();
        }
    }

    public void Reposition()
    {
        Vector2 offset = new Vector2(width * 2, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
