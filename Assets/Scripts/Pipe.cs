using System;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private float speed = 1000f;
    private Rigidbody2D body;
    private int width;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        width = (int)Math.Round(GetComponent<BoxCollider2D>().bounds.size.x);
    }

    void Update()
    {
        if (gameObject.transform.position.x < (Main.Instance.VisibleWidth + width) / -2)
        {
            PipeFactory.Instance.ReturnToPool(gameObject);
            return;
        }

        body.velocity = gameObject.transform.right * speed * -1;
    }
}
