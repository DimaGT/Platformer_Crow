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
                col.GetComponent<Animator>().SetBool("Ladder", true);
            } 
            else if (Input.GetKey(KeyCode.S))
            {
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ladderSpeed);
                col.GetComponent<Animator>().SetBool("Ladder", true);
            }
            else 
            {
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                col.GetComponent<Animator>().SetBool("Ladder", false);

            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.GetComponent<Rigidbody2D>().gravityScale = 1;
                col.GetComponent<Animator>().SetBool("Ladder", false);

        }
    }


}
