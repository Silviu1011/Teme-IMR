using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleThrowEvent : MonoBehaviour
{
    string handTag;
    bool targetHit;
    bool error;
    GameObject board;

    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.FindWithTag("board");
        targetHit = false;
        error = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("g")) {
            Debug.Log("The G (grab) key is being held down");
        } else if(Input.GetKeyUp("g")) {
            if(targetHit && !error) {
                Debug.Log("The dart made collision with the board");
                Debug.Log("Hand position (" + handTag +"): " + GameObject.FindWithTag(handTag).transform.position);
                Debug.Log("Board position: " + board.transform.position);
                targetHit = false;
                error = true;
            } else if(error) {
                targetHit = false;
                error = false;
            }
        }
    }

    void OnTriggerEnter(Collider cube) {
        if (cube.gameObject.tag == "board") {
            targetHit = true;
        } else {
            handTag = cube.gameObject.tag;
        }
    }
}
