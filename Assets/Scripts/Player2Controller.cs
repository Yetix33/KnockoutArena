using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float speed;
    public Rigidbody r_body;
    private Vector3 _inputs = Vector3.zero;
    private Animator animator;
    private bool isKnockback = false; 
    // Start is called before the first frame update
    void Start()
    {
        r_body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("p2_horizontal");
        float z = Input.GetAxis("p2_vertical");
         if(Input.GetButtonDown("p2_block")){
            r_body.velocity = Vector3.zero;
            r_body.angularVelocity = Vector3.zero;
            r_body.Sleep();
            animator.ResetTrigger("walk");
            animator.SetTrigger("block");
        }
        if((x != 0 || z != 0) && !isKnockback){
            r_body.velocity = new Vector3(x*speed, r_body.velocity.y, z * speed);
            Vector3 movementDirection = new Vector3(x,0,z);
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (movementDirection), Time.deltaTime *20f);
            //transform.rotation = Quaternion.LookRotation(movementDirection);
            animator.SetTrigger("walk");
        } else if(animator.GetCurrentAnimatorStateInfo(0).IsName("walk")) {
            animator.SetTrigger("stop_walk");
        }

        if(Input.GetButtonDown("p2_base_attack")&& !isKnockback){
            animator.SetTrigger("base_attack");
        }
        if(r_body.velocity.magnitude <1){
            isKnockback = false;
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.name == "sword"){
            isKnockback = true;
        }
}
}
