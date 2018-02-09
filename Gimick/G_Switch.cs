using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Switch : Gimick {

    float HP = 1.0f;

    [SerializeField]
    List<GameObject> WallList = new List<GameObject>();

    AttackArea AttackMagic;

    private GameObject _child;
    private void Start()
    {
        int count = 0;
        foreach (Transform child in transform)
        {
            GameObject Childwall = GameObject.Find(child.name);
            WallList.Add(Childwall);
            count++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //AttackAreaのついている攻撃が来たら
        if (other.gameObject.GetComponent<AttackArea>())
        {
            AttackMagic = other.gameObject.GetComponent<AttackArea>();
            //プレイヤーの攻撃でしか壊せない
            if (AttackMagic.aligment == aligment.player)
            {
                HP -= AttackMagic.Damage;
                if (HP <= 0)
                {
                    //HPを減らす攻撃であれば壊れる
                    Destroy(gameObject);
                }
            }
        }
    }
}