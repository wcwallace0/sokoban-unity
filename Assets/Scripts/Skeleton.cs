using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public LayerMask stopsMovement;
    public LayerMask moveable;

    public SpriteRenderer sr;
    public Vector3 moveBy = new Vector3(-1, 0, 0);

    public void Move() {
        // stores the collider2D for another box if this skeleton will collide with it
        Collider2D other = Physics2D.OverlapCircle(transform.position + moveBy, 0.2f, moveable);

        if(!Physics2D.OverlapCircle(transform.position + moveBy, 0.2f, stopsMovement) && !other) 
        {
            transform.position += moveBy;
        }
        else
        {
            if (other && other.gameObject.GetComponent<Box>().isFragile)
            {
                // Moving into fragile box, we want to break it
                other.gameObject.GetComponent<Box>().Break(other.gameObject);
                transform.position += moveBy;
            }
            else
            {
                // moving into wall or box, flip the skeleton
                sr.flipX = !sr.flipX;
                moveBy = new Vector3(moveBy.x * -1, 0, 0);
            }
        }
    }
}
