using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] float obstacleSpeed;  //��ֹ� �̵� �ӵ�
  
    public new Transform camera;  //���� ī�޶�

    public GameObject[] obstacle;  //��ֹ� ������Ʈ��
    private float halfScreenSizeY;  //ȭ�� ������ ��
    private float halfScreenSizeX;  //ȭ�� ���� ������ ��(ī�޶� ����)
    private float spriteSizeX;  //��ֹ� ��������Ʈ ���α���
    private float obstacleGap;  //��ֹ� ���� ����

    private float minY;  //��ֹ� �ּ� y��
    private float maxY;  //��ֹ� �ִ� y��

    private float obstacleY;  //���� ������ ���� ��ֹ� y��

    // Start is called before the first frame update
    void Start()
    {
        //�迭 �ȿ� �ִ� ��ֹ��� x�� ���ؼ� ��ֹ� ������� ����
        for (int i = 0; i < obstacle.Length-1; i++) 
        {
            for (int k = i; k < obstacle.Length-1; k++) 
            {
                if (obstacle[i].transform.position.x > obstacle[k + 1].transform.position.x) 
                {
                    obstacle[i] = obstacle[k + 1];
                }
            }
        }

        spriteSizeX = obstacle[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;  //��������Ʈ x�� �����ͼ� ��ֹ� �β� �ʿ��Ҷ� ��
        halfScreenSizeY = Camera.main.orthographicSize;  //ī�޶� ������ ����
        halfScreenSizeX = Camera.main.orthographicSize * Camera.main.aspect;  //ī�޶� ������ ����

        obstacleSpeed = 5.0f;  //��ֹ� �ӵ�
        obstacleGap = 6.0f;  //��ֹ� ���� �Ÿ�

        minY = camera.transform.position.y - halfScreenSizeY + 3.0f;  //�ּ� ī�޶� ������ �Ʒ��ʿ��� 3��ŭ ��
        maxY = camera.transform.position.y + halfScreenSizeY - 3.0f;  //�ִ� ī�޶� ������ ���ʿ��� 3��ŭ �Ʒ�
    }

    // Update is called once per frame
    void Update()
    {
        //�������� �̵�
        transform.position += Vector3.left * obstacleSpeed * Time.deltaTime;

        //�� ���� ��ֹ��� ī�޶� ������ �������� �������
        if (obstacle[0].transform.position.x + spriteSizeX < camera.transform.position.x - halfScreenSizeX)
        {
            //y�� �������� ���ϰ�
            obstacleY = Random.Range(minY, maxY);
            
            //�� ���������� �̵�
            obstacle[0].transform.position
                = new Vector3(obstacle[obstacle.Length - 1].transform.position.x + obstacleGap, obstacleY, 0.0f);

            //�� ���� ��ֹ��� �迭 �� �ڷ� ������ ��ĭ�� ����� > �迭 �� ���� �׻� �� ���� ��ֹ�
            GameObject temp = obstacle[0];
            for (int i = 0; i < obstacle.Length - 1; i++)
            {
                obstacle[i] = obstacle[i + 1];
            }
            obstacle[obstacle.Length - 1] = temp;
        }
    }
}
