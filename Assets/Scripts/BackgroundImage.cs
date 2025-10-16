using UnityEditor;
using UnityEngine;

public class BackgroundImage : MonoBehaviour
{
    #region 설정
    [Header("배경이미지")]
    [SerializeField] float speed; //배경이 이동하는 속도
    [SerializeField] int startIndex; //현재 맨 앞 이미지
    [SerializeField] int secondIndex;
    [SerializeField] int thirdIndex;
    [SerializeField] int endIndex;

    public Transform[] sprites; //배경 스프라이트 배열
    #endregion
    void Update()
    {
        ImageMove();
    }             

    #region 메서드
    private void ImageMove()
    {
        //백그라운드를 왼쪽으로 이동
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (sprites[endIndex].position.x < -18.0f)
        {
            if (sprites.Length == 2) //끊기지 않고 반복될 이미지
            {
                sprites[endIndex].localPosition = sprites[startIndex].localPosition + Vector3.right * 18.0f;

                //startIndex와 endIndex를 서로 바꿔준다
                int temp = startIndex;
                startIndex = endIndex;
                endIndex = temp;
            }
            else if (sprites.Length == 4) // 달이 등 연달아 나오면 이상해 보여서 SetAactive false를 사이에 추가
            {
                sprites[endIndex].localPosition = sprites[startIndex].localPosition + Vector3.right * 18.0f;

                //startIndex 부터 endIndex까지 서로 봐꿔준다
                int temp = startIndex;
                startIndex = secondIndex;
                secondIndex = thirdIndex;
                thirdIndex = endIndex;
                endIndex = temp;
            }
        }
    }

    #endregion
}
