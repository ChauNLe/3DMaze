using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateControl : MonoBehaviour
{
    Animator animator;
    // public GameObject Camera;
    // public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerMove>().speed == 2.5f){
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("isNotMoving", false);
        }
        else if (FindObjectOfType<PlayerMove>().speed == 5f){
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", true);
            animator.SetBool("isNotMoving", false);
        }
        else {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isNotMoving", true);

            // Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Camera.transform.position.z + 4.3f);
        }
    }
}
