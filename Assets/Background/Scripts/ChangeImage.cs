using UnityEngine;

public class ChangeImage : MonoBehaviour
{
    #region ����
    [Header("Ŭ����")]
    //X�� Ȯ�ο� �迭
    public Transform[] confirmImage;
    //��ȯ�� �̹��� �迭
    public GameObject[] backgroundImage;

    //Change() if�� ���ǽĿ� �� ����
    private int current = 0;
    private int num = 1;

    #endregion

    void Update()
    {
        Change();
    }

    #region �޼���
    private void Change()
    {
        //Clouds1 ~ 3���� ��ȯ �� �ٽ� 1���� ����
        if (confirmImage[current].position.x < -18f * num)
        {
            //���� �ε��� ��Ȱ��ȭ
            backgroundImage[current].SetActive(false);

            //�迭�� ������ ���� ���ٸ� �ٽ� 0����
            current++;
            if (current >= backgroundImage.Length)
            {
                current = 0;
                //-f�� ������ ����
                num++;
            }

            //���� �ε��� Ȱ��ȭ
            backgroundImage[current].SetActive(true);
        }
    }
    #endregion
}
