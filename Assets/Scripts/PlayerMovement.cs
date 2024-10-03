using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public float moveSpeed = 5f;
    public Transform target; // Position that the player moves towards

    public LayerMask stopsMovement;
    public LayerMask moveable;

    // Animation parameter - Facing
    // 0 - North
    // 1 - East
    // 2 - South
    // 3 - West
    public Animator anim;

    public AudioSource audioSource;
    public AudioClip moveSFX;
    public AudioClip dieSFX;
    public AudioClip thunkSFX;

    private Vector2 previousInput = new Vector2(0f, 0f);

    private void Start() {
        target.parent = null;
    }

    private void Update() 
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(Vector3.Distance(transform.position, target.position) <= .02f)
        {
            anim.SetBool("isWalking", false);

            if(previousInput == Vector2.zero)
            {
                if(Mathf.Abs(horizontal) == 1f) 
                {
                    Vector3 moveBy = new Vector3(horizontal, 0f, 0f);
                    anim.SetFloat("Facing", -1 * moveBy.x + 2);
                    CheckMovement(moveBy);
                } 
                else if(Mathf.Abs(vertical) == 1f) 
                {
                    Vector3 moveBy = new Vector3(0f, vertical, 0f);
                    anim.SetFloat("Facing", -1 * moveBy.y + 1);
                    CheckMovement(moveBy);
                }
            }
        }

        previousInput = new Vector2(horizontal, vertical);
    }

    // Given a Vector3 indicating where the player wishes to move,
    // check if that new position is walkable.
    // If not, or if the new position contains a box, move the player/boxes accordingly
    void CheckMovement(Vector3 moveBy) {
        if(Physics2D.OverlapCircle(target.position + moveBy, 0.2f, moveable)) 
        {
            anim.SetTrigger("Push");
            Collider2D box = Physics2D.OverlapCircle(target.position + moveBy, 0.2f, moveable);
            box.gameObject.GetComponent<Box>().Push(moveBy); // Tell the box to move in the direction, if possible
        }
        else if(!Physics2D.OverlapCircle(target.position + moveBy, 0.2f, stopsMovement)) 
        {
            target.position += moveBy;
            anim.SetBool("isWalking", true);
            // play move sfx
            audioSource.clip = moveSFX;
            audioSource.Play();
        }
        else
        {
            // moving into a wall
            audioSource.clip = thunkSFX;
            audioSource.Play();
        }
    }
}
