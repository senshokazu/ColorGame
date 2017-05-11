using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//タッチ処理のスクリプト

public class Controller : MonoBehaviour
{
    public GameObject player;
    public GameObject playercollider;
    SphereCollider sphereCollider;　//プレイヤーのコライダー
    new public Camera camera;　　　 //newは名前の隠蔽
    public Animator animator;
    public float speed ;            //プレイヤーの移動速度
    float playerx, playerz;

    // Use this for initialization
    void Start()
    {

        sphereCollider = playercollider.GetComponent<SphereCollider>();
        animator = player.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Attack", false);
        animator.SetBool("move", false);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = camera.ScreenPointToRay(touch.position);
            RaycastHit hit;

            playerx = player.transform.position.x;
            playerz = player.transform.position.z;
            if (touch.phase == TouchPhase.Began)
            {

                if (Physics.Raycast(ray, out hit))
                {
                    float x = (playerx) - (hit.point.x);
                    float z = (playerz) - (hit.point.z);
                    player.transform.eulerAngles = new Vector3(0, Mathf.Atan2(x, z) * Mathf.Rad2Deg - 180, 0);//キャラクターの向き変更

                    if (hit.collider.gameObject.tag == "Cube")
                    {
                        animator.SetBool("Move", true);
                        player.transform.position += ((new Vector3(hit.point.x, 0.25f, hit.point.z) -
                           new Vector3(playerx, 0.25f, playerz))).normalized * Time.deltaTime * speed;
                    }

                    if (hit.collider.gameObject.tag == "Blue")
                        PlayerAttack();


                }
            }

            if (touch.phase == TouchPhase.Moved)
            {

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Cube")
                    {
                        animator.SetBool("Move", true);

                        float x = (playerx) - (hit.point.x);
                        float z = (playerz) - (hit.point.z);

                        player.transform.eulerAngles = new Vector3(0, Mathf.Atan2(x, z) * Mathf.Rad2Deg - 180, 0);//キャラクターの向き変更
                        player.transform.position += ((new Vector3(hit.point.x, 0.25f, hit.point.z) -
                        new Vector3(playerx, 0.25f, playerz))).normalized * Time.deltaTime * speed;

                    }
                }
            }

        }


    }

    bool Attack = true;
    void PlayerAttack()
    {
        if (Attack == true)
        {
            Attack = false;
            animator.SetBool("Attack", true);
            Invoke("ColliderStart", 0.3f);
            Invoke("ColliderEnd", 0.5f);
            Invoke("Cooltime", 0.75f);
        }
    }

    void ColliderStart()
    {
        sphereCollider.enabled = true;
    }
    void ColliderEnd()
    {
        sphereCollider.enabled = false;

    }
    void Cooltime()
    {
        Attack = true;
    }


}


