using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public LayerMask stopsMovement;
    public bool isFragile;

    public void Push(Vector3 moveBy) 
    {
        if(!Physics2D.OverlapCircle(transform.position + moveBy, 0.2f, stopsMovement)) 
        {
            if(isFragile)
            {
                // TODO break box
                Destroy(gameObject);
            }
            else
            {
                transform.position += moveBy;
                // TODO play move sfx
            }
        }
        else
        {
            // TODO play thunk sound effect
        }
    }
}
