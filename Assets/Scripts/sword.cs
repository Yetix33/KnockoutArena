using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    // Start is called before the first frame update
    public float knockBack;
    public float block_knockBack;
    public float block_self_knockBack;

    public GameObject player;
    private Animator playerAnimator;
    private Rigidbody player_rbody;
    void Start()
    {   
        player = this.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
        playerAnimator = player.GetComponent<Animator>();
        player_rbody = player.GetComponent<Rigidbody>();
        Debug.Log(playerAnimator);               
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col){
        Debug.Log(col.tag);
        Rigidbody collider_rbody = col.gameObject.GetComponent<Rigidbody>();
        if(col.tag == "Player" && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("base_attack_anim")){
            //float step = 1 * Time.deltaTime;
            //col.transform.position = Vector3.MoveTowards(col.transform.position,col.transform.position + player.transform.forward * knockBack, step );  
            //col.gameObject.GetComponent<Rigidbody>().AddForce(player.transform.forward.x * knockBack, 0, player.transform.forward.z * knockBack);
            if(col.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("block")){
                Debug.Log("col block");

                collider_rbody.velocity = new Vector3(player.transform.forward.x * block_knockBack, 0, player.transform.forward.z * block_knockBack);
                player_rbody.velocity = new Vector3(-player.transform.forward.x * block_self_knockBack, 0, -player.transform.forward.z * block_self_knockBack);
            }else {
                // Play sound with AudioManager
                FindObjectOfType<AudioManager>().Play("PlayerHit");

                Debug.Log("col notblock");
                collider_rbody.velocity = new Vector3(player.transform.forward.x * knockBack, 0, player.transform.forward.z * knockBack);
            }

        }
    }
}
