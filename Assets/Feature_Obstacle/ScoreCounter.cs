using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)  //������ ���������� ������ �����ϱ� Exit ���
    {
        //�÷��̾ ������ ����������
        if (collision.CompareTag("Player"))
        {
            //���� ȹ��
            //GameManager.Instance.AddScore(1);
        }
    }
}
