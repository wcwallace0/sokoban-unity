using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public LayerMask stopsMovement;
    public LayerMask moveable;
    public bool isFragile;

    public AudioSource audioSource;
    public AudioClip potSFX;
    public AudioClip pushSFX;
    public AudioClip thunkSFX;

    public void Push(Vector3 moveBy) 
    {
        // stores the collider2D for another box if this box will collide with it when pushed
        Collider2D other = Physics2D.OverlapCircle(transform.position + moveBy, 0.2f, moveable);

        if(!Physics2D.OverlapCircle(transform.position + moveBy, 0.2f, stopsMovement) && !other) 
        {
            transform.position += moveBy;
            // play move sfx
            audioSource.clip = pushSFX;
            audioSource.Play();
        }
        else
        {
            if (other && other.gameObject.GetComponent<Box>().isFragile)
            {
                // Pushing box into fragile box, we want to break it
                // break pot sfx
                audioSource.clip = potSFX;
                audioSource.Play();
                Destroy(other.gameObject);
                if(isFragile) {
                    Destroy(gameObject);
                } else {
                    transform.position += moveBy;
                }
            }
            else if(isFragile)
            {
                // break pot sfx
                audioSource.clip = potSFX;
                audioSource.Play();
                Destroy(gameObject);
            }
            else
            {
                // play thunk sound effect
                audioSource.clip = thunkSFX;
                audioSource.Play();
            }
        }
    }
}
