using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove : MonoBehaviour
{
    Transform player;
    public float moveSpeed;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        if (transform.position == player.position)
        {
           // PV--;
        }
    }
}
