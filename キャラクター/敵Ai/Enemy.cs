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
    public int attack,color_count;//スライムの攻撃力
    public int init_color_count;
    public Animator animator;

    bool EnemyMove = true;
   


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        
        init_color_count = color_count;
    }

    // Update is called once per frame
    void Update()
    {
        if (color_count > init_color_count)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            init_color_count += 1;
        }

        float enemy_position_x=transform.position.x;
        float enemy_position_z = transform.position.z;
        float x = (enemy_position_x) - (player.transform.position.x);
        float z = (enemy_position_z) - (player.transform.position.z);

        if ((x * x) + (z * z) < 500f && EnemyMove == true)
        {
            animator.SetBool("Move", true);
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(x, z) * Mathf.Rad2Deg - 180, 0);
            transform.position += ((new Vector3(player.transform.position.x, 0, player.transform.position.z) -
            new Vector3(enemy_position_x, 0, enemy_position_z))).normalized * Time.deltaTime * speed;
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

    bool CanAttack = true;

    IEnumerator EnemyAttack()
    {
        if (CanAttack == false)
        {

            yield break;
        }
        else
        {
            var Canvas1 = Instantiate(canvas.gameObject, player.transform.position - Camera.main.transform.forward * 0.2f, player.transform.rotation);
            //text.gameObject⇒textはUIなので.gameObjectを付けることでtextがついたgameObjectが複製される
            Destroy(Canvas1.gameObject, 1.0f);
            CanAttack = false;
            playerstatus.hp -= attack;
            yield return new WaitForSeconds(0.8333335f);
            CanAttack = true;
        }
    }
}





