using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleThrowEvent : MonoBehaviour
{
    string handTag;
    bool targetHit;
    bool error;
    GameObject board;
    ParticleSystem ps;
    int score = 0;
    UIManager manager;

    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.FindWithTag("board");
        targetHit = false;
        error = false;
        manager = FindObjectOfType<UIManager>();
        ps = board.GetComponent<ParticleSystem>();
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("g")) {
            Debug.Log("The G (grab) key is being held down");
        } else if(Input.GetKeyUp("g")) {
            if(targetHit && !error) {
                Debug.Log("The dart made collision with the board");
                ps.Play();
                float distance = Vector3.Distance(GameObject.FindWithTag(handTag).transform.position, board.transform.position);
                int points = (int)(distance * 10);
                Debug.Log(score + " " + points);
                score = score + points;
                manager.updateScore(score);
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
