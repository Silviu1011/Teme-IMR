using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAnimation : MonoBehaviour
{
    private string handTag;
    private int count;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("tab")) {
            count += 1;
            if(count == 1) {
                handTag = "left";
            } else if(count == 2) {
                handTag = "right";
            } else {
                handTag = "cam";
                count = 0;
            }
        }
        if(Input.GetKey("g")) {
            if (handTag == "left") {
                animator.SetBool("grabbed_left", true);
            } else if(handTag == "right") {
                animator.SetBool("grabbed_right", true);
            }
         } else {
            if (handTag == "left") {
                animator.SetBool("grabbed_left", false);
            } else if(handTag == "right") {
                animator.SetBool("grabbed_right", false);
            }
         }
    }
}
