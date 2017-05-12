using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    PlayerStatus playerstatus;
    // Use this for initialization
    void Start()
    {
        playerstatus = GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {

        float x0 = 0;
        float z0 = 0;

        //右・左
        float x = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        //上・下
        float z = CrossPlatformInputManager.GetAxisRaw("Vertical");

        //移動する向き
        Vector3 direction = new Vector3(x, 0f, z).normalized;

        //プレイヤーの角度
        float x1 = x - x0;
        float z1 = z - z0;

        if (x1 == 0 || z1 == 0)
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        else 
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(x1, z1) * Mathf.Rad2Deg, 0);

        //移動の瞬間   
        Move(direction);
    }

    void Move(Vector3 direction)
    {
        
        //プレイヤーの座標を取得
        Vector3 pos = transform.position;

        //移動量を加える
        pos += direction * playerstatus.speed * Time.deltaTime;

        transform.position = pos;


    }



}

