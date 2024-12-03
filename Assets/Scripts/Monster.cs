using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    private Rigidbody2D mybody;

    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Set velocity for consistent movement based on speed
        mybody.velocity = new Vector2(speed, mybody.velocity.y);
    }
}