using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] float obstacleSpeed;  //장애물 이동 속도
  
    public new Transform camera;  //메인 카메라

    public GameObject[] obstacle;  //장애물 오브젝트들
    private float halfScreenSizeY;  //화면 높이의 반
    private float halfScreenSizeX;  //화면 가로 길이의 반(카메라 기준)
    private float spriteSizeX;  //장애물 스프라이트 가로길이
    private float obstacleGap;  //장애물 사이 간격

    private float minY;  //장애물 최소 y값
    private float maxY;  //장애물 최대 y값

    private float obstacleY;  //랜덤 돌려서 정할 장애물 y값

    // Start is called before the first frame update
    void Start()
    {
        //배열 안에 있는 장애물들 x값 비교해서 장애물 순서대로 정렬
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

        spriteSizeX = obstacle[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;  //스프라이트 x값 가져와서 장애물 두께 필요할때 씀
        halfScreenSizeY = Camera.main.orthographicSize;  //카메라 높이의 절반
        halfScreenSizeX = Camera.main.orthographicSize * Camera.main.aspect;  //카메라 넓이의 절반

        obstacleSpeed = 5.0f;  //장애물 속도
        obstacleGap = 6.0f;  //장애물 사이 거리

        minY = camera.transform.position.y - halfScreenSizeY + 3.0f;  //최소 카메라 프레임 아래쪽에서 3만큼 위
        maxY = camera.transform.position.y + halfScreenSizeY - 3.0f;  //최대 카메라 프레임 위쪽에서 3만큼 아래
    }

    // Update is called once per frame
    void Update()
    {
        //왼쪽으로 이동
        transform.position += Vector3.left * obstacleSpeed * Time.deltaTime;

        //맨 왼쪽 장애물이 카메라 프레임 왼쪽으로 사라지면
        if (obstacle[0].transform.position.x + spriteSizeX < camera.transform.position.x - halfScreenSizeX)
        {
            //y값 랜덤으로 구하고
            obstacleY = Random.Range(minY, maxY);
            
            //맨 오른쪽으로 이동
            obstacle[0].transform.position
                = new Vector3(obstacle[obstacle.Length - 1].transform.position.x + obstacleGap, obstacleY, 0.0f);

            //맨 왼쪽 장애물을 배열 맨 뒤로 보내고 한칸씩 땡기기 > 배열 맨 앞은 항상 맨 왼쪽 장애물
            GameObject temp = obstacle[0];
            for (int i = 0; i < obstacle.Length - 1; i++)
            {
                obstacle[i] = obstacle[i + 1];
            }
            obstacle[obstacle.Length - 1] = temp;
        }
    }
}
