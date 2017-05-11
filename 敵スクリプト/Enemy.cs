using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Canvas canvas;
    public Text text;
    public GameObject player;
    public PlayerStatus playerstatus;

    public float speed;　　　//スライムの移動速度
    public int attack;       //スライムの攻撃力
    public Animator animator;

    bool EnemyMove = true;
   


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float player_x = transform.position.x;
        float player_z = transform.position.z;
        float x = (player_x) - (player.transform.position.x);
        float z = (player_z) - (player.transform.position.z);

        if ((x * x) + (z * z) < 500f && EnemyMove == true)
        {
            animator.SetBool("Move", true);
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(x, z) * Mathf.Rad2Deg - 180, 0);
            transform.position += ((new Vector3(player.transform.position.x, 0, player.transform.position.z) -
            new Vector3(player_x, 0, player_z))).normalized * Time.deltaTime * speed;
        }

        if ((x * x) + (z * z) < 1f)
        {

            animator.SetBool("Attack", true);
            EnemyMove = false;
            StartCoroutine("EnemyAttack");

        }
        else
        {
            animator.SetBool("Attack", false);
            EnemyMove = true;
        }
    }

    bool CoolTime = false;

    IEnumerator EnemyAttack()
    {
        if (CoolTime == true)
        {

            yield break;
        }
        else
        {
            var Canvas1 = Instantiate(canvas.gameObject, player.transform.position - Camera.main.transform.forward * 0.2f, player.transform.rotation);
            //text.gameObject⇒textはUIなので.gameObjectを付けることでtextがついたgameObjectが複製される
            Destroy(Canvas1.gameObject, 1.0f);
            CoolTime = true;
            playerstatus.hp -= attack;
            yield return new WaitForSeconds(0.8333335f);
            CoolTime = false;
        }
    }
}





