using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5f;
    public Transform target; // Position that the player moves towards

    public LayerMask stopsMovement;

    // Animation parameter - Facing
    // 0 - North
    // 1 - East
    // 2 - South
    // 3 - West
    public Animator anim;

    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed*Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) <= .05f) 
        {
            anim.SetBool("isWalking", false);

            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) 
            {
                Vector3 moveBy = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                if(!Physics2D.OverlapCircle(target.position + moveBy, 0.2f, stopsMovement)) 
                {
                    target.position += moveBy;
                    anim.SetFloat("Facing", -1 * moveBy.x + 2);
                    anim.SetBool("isWalking", true);
                }
            } 
            else if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) 
            {
                Vector3 moveBy = new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                if(!Physics2D.OverlapCircle(target.position + moveBy, 0.2f, stopsMovement)) 
                {
                    target.position += moveBy;
                    anim.SetFloat("Facing", -1 * moveBy.y + 1);
                    anim.SetBool("isWalking", true);
                }
            }
        }
    }
}
