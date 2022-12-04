using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField]
    float ladderSpeed = 3;
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.GetComponent<Rigidbody2D>().gravityScale = 0;
            if(Input.GetKey(KeyCode.W))
            {
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, ladderSpeed);
                col.GetComponent<Animator>().SetFloat("LadderSpeed", ladderSpeed);
            } 
            else if (Input.GetKey(KeyCode.S))
            {
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ladderSpeed);
                col.GetComponent<Animator>().SetFloat("LadderSpeed", ladderSpeed);
            }
            else 
            {
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.GetComponent<Rigidbody2D>().gravityScale = 1;
            col.GetComponent<Animator>().SetFloat("LadderSpeed", 0);

        }
    }


}
