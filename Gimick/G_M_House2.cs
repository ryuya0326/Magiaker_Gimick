using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_M_House2 : Gimick {
    [SerializeField]
    List<GameObject> WallList = new List<GameObject>();

    [SerializeField]
    List<GameObject> EnemyList = new List<GameObject>();
	
	// Update is called once per frame
	void Update () {
        int x = EnemyList.Count - 1;

        //常にモンスターがリストからいなくなったらリストを削除する
        for (int i = 0; i <= x; i++)
        {
            if (EnemyList[i] == null)
            {
                EnemyList.Remove(EnemyList[i]);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーがモンスターハウス内に入った時
        if (other.gameObject.tag == Tags.Player)
        {
            //壁を作る
            for (int i = 0; i < WallList.Count; i++)
            {
                WallList[i].SetActive(true);
            }
            //enemyが出現
            for (int i = 0; i < EnemyList.Count; i++)
            {
                EnemyList[i].SetActive(true);
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        //Enemyがいなくなったとき
        //壁がなくなる
        if (EnemyList.Count == 0)
        {
            if (other.gameObject.tag == Tags.Player)
            {
                for (int i = 0; i < WallList.Count; i++)
                {
                    WallList[i].SetActive(false);
                }
            }
        }
    }
}
