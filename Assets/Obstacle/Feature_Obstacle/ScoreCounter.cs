using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)  //무사히 빠져나가야 점수를 얻으니까 Exit 사용
    {
        //플레이어가 무사히 빠져나가면
        if (collision.CompareTag("Player"))
        {
            //점수 획득
            //GameManager.Instance.AddScore(1);
        }
    }
}
