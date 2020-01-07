using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionJudgment : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("物件發生碰撞");
        }
       if(other.gameObject.tag =="enemy")
        {
            Debug.Log("敵人碰撞物件");
        }
    }
}
