using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    
    public GameObject player;
    public GameObject enemy;
    public Enemy enemy_script;
    public PlayerStatus playerstatus;
    // Use this for initialization
    void Start()
    {
      //他オブジェクトのスクリプトにアクセスるときは必ず他スクリプトのゲームオブジェクトも一緒に参照する　enemy.  player.
        enemy_script = enemy.GetComponent<Enemy>();
        playerstatus = player.GetComponent<PlayerStatus>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        
       
        if (other.gameObject.tag == "Red")
        {
            GetComponent<Renderer>().material.color = Color.red;
            playerstatus.color_count += 1;

        }
        else if (other.gameObject.tag == "Blue")
        {
            GetComponent<Renderer>().material.color = Color.blue;
            enemy_script.color_count += 1;
        }
    }
}
