using UnityEditor;
using UnityEngine;

public class BackgroundImage : MonoBehaviour
{
    #region ����
    [Header("����̹���")]
    [SerializeField] float speed; //����� �̵��ϴ� �ӵ�
    [SerializeField] int startIndex; //���� �� �� �̹���
    [SerializeField] int secondIndex;
    [SerializeField] int thirdIndex;
    [SerializeField] int endIndex;

    public Transform[] sprites; //��� ��������Ʈ �迭
    #endregion
    void Update()
    {
        ImageMove();
    }             

    #region �޼���
    private void ImageMove()
    {
        //��׶��带 �������� �̵�
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (sprites[endIndex].position.x < -18.0f)
        {
            if (sprites.Length == 2) //������ �ʰ� �ݺ��� �̹���
            {
                sprites[endIndex].localPosition = sprites[startIndex].localPosition + Vector3.right * 18.0f;

                //startIndex�� endIndex�� ���� �ٲ��ش�
                int temp = startIndex;
                startIndex = endIndex;
                endIndex = temp;
            }
            else if (sprites.Length == 4) // ���� �� ���޾� ������ �̻��� ������ SetAactive false�� ���̿� �߰�
            {
                sprites[endIndex].localPosition = sprites[startIndex].localPosition + Vector3.right * 18.0f;

                //startIndex ���� endIndex���� ���� �����ش�
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
