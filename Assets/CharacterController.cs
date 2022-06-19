using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float speed = 5f;

    private Vector3 move;

    void Start()
    {
        move = new Vector3(0f, 0f, 0f);
    }

    // Move character 3d
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        move = new Vector3(x, y).normalized;
        transform.Translate(move * speed * Time.deltaTime);

        // if move maginitude is greater than 0 activate animation
        if (move.magnitude > 0)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isWalking", false);
        }

        if(Input.GetKey(KeyCode.Space)) {
            GetComponent<Animator>().SetBool("isHappy", true);
        } else if(Input.GetKey(KeyCode.I)) {
            GetComponent<Animator>().SetBool("isEmote1", true);
        } else if(Input.GetKey(KeyCode.O)) {
            GetComponent<Animator>().SetBool("isEmote2", true);
        } else if(Input.GetKey(KeyCode.P)) {
            GetComponent<Animator>().SetBool("isEmote3", true);
        } else {
            GetComponent<Animator>().SetBool("isHappy", false);
            GetComponent<Animator>().SetBool("isEmote1", false);
            GetComponent<Animator>().SetBool("isEmote2", false);
            GetComponent<Animator>().SetBool("isEmote3", false);
        }

        if (x > 0f) {
            transform.localScale = Vector3.one;
        } else if (x < 0f) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
