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
    private bool isKnockBackUp = false;
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
        Rigidbody collider_rbody = col.gameObject.GetComponent<Rigidbody>();
        if(col.tag == "Player" && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("base_attack_anim")){
            //float step = 1 * Time.deltaTime;
            //col.transform.position = Vector3.MoveTowards(col.transform.position,col.transform.position + player.transform.forward * knockBack, step );  
            //col.gameObject.GetComponent<Rigidbody>().AddForce(player.transform.forward.x * knockBack, 0, player.transform.forward.z * knockBack);
            float temp_block_knockBack = block_knockBack;
            float temp_knockBack = knockBack;
            if(col.gameObject.name == "Player1"){
                if(col.gameObject.GetComponent<Player1Controller>().isBlockUp){
                    temp_block_knockBack = temp_block_knockBack/2;
                    temp_knockBack = temp_knockBack/2;
                }
            } else if(col.gameObject.name=="Player2"){
                if(col.gameObject.GetComponent<Player2Controller>().isBlockUp){
                    temp_block_knockBack = temp_block_knockBack/2;
                    temp_knockBack = temp_knockBack/2;
                }
            }

            if(col.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("block")){
                Debug.Log("col block");
                collider_rbody.velocity = new Vector3(player.transform.forward.x * temp_block_knockBack, 0, player.transform.forward.z * temp_block_knockBack);
                player_rbody.velocity = new Vector3(-player.transform.forward.x * block_self_knockBack, 0, -player.transform.forward.z * block_self_knockBack);
            }else {
                // Play sound with AudioManager
                FindObjectOfType<AudioManager>().Play("PlayerHit");

                Debug.Log("col notblock");

                Debug.Log("hit " + temp_knockBack);
                collider_rbody.velocity = new Vector3(player.transform.forward.x * temp_knockBack, 0, player.transform.forward.z * temp_knockBack);
            }

        }
    }
    IEnumerator KnockBackUp(){
        float old_knockBack = knockBack;
        knockBack = knockBack * 1.5f;
        isKnockBackUp = true;
        Debug.Log("knock " + knockBack);
        yield return new WaitForSeconds(10f);
        knockBack = old_knockBack;
        isKnockBackUp = false;
    }

    public void startKnockBackUp() {
        if(isKnockBackUp){
            StopCoroutine(KnockBackUp());
        }
        StartCoroutine(KnockBackUp());
    }

}
