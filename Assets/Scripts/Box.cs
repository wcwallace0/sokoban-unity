using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public LayerMask stopsMovement;
    public LayerMask moveable;
    public bool isFragile;

    public void Push(Vector3 moveBy) 
    {
        // stores the collider2D for another box if this box will collide with it when pushed
        Collider2D other = Physics2D.OverlapCircle(transform.position + moveBy, 0.2f, moveable);

        if(!Physics2D.OverlapCircle(transform.position + moveBy, 0.2f, stopsMovement) && !other) 
        {
            transform.position += moveBy;
            // TODO play move sfx
        }
        else
        {
            if (other && other.gameObject.GetComponent<Box>().isFragile)
            {
                // Pushing box into fragile box, we want to break it
                // TODO break pot sfx
                Destroy(other.gameObject);
                if(isFragile) {
                    Destroy(gameObject);
                } else {
                    transform.position += moveBy;
                }
            }
            else if(isFragile)
            {
                // TODO break pot sfx
                Destroy(gameObject);
            }
            else
            {
                // TODO play thunk sound effect
            }
        }
    }
}
