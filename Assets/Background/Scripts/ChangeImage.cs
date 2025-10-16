using UnityEngine;

public class ChangeImage : MonoBehaviour
{
    #region 설정
    [Header("클라우드")]
    //X축 확인용 배열
    public Transform[] confirmImage;
    //변환할 이미지 배열
    public GameObject[] backgroundImage;

    //Change() if문 조건식에 쓸 변수
    private int current = 0;
    private int num = 1;

    #endregion

    void Update()
    {
        Change();
    }

    #region 메서드
    private void Change()
    {
        //Clouds1 ~ 3까지 순환 후 다시 1부터 시작
        if (confirmImage[current].position.x < -18f * num)
        {
            //현재 인덱스 비활성화
            backgroundImage[current].SetActive(false);

            //배열의 마지막 까지 갔다면 다시 0으로
            current++;
            if (current >= backgroundImage.Length)
            {
                current = 0;
                //-f의 범위를 증감
                num++;
            }

            //다음 인덱스 활성화
            backgroundImage[current].SetActive(true);
        }
    }
    #endregion
}
