using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllow : MonoBehaviour
{
    public Transform target;       // ���� ��� (�÷��̾�)
    public Vector3 offset;         // ī�޶� ��ġ ����
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {    // ī�޶󿡴� x,y,z���� ������ ������(0,0,-10) �̰�ó�� z���� �����ε� 0�̸� �ٸ��͵�� ��ġ�⶧���� ���� �� �ð��� ������ �����Ѱ��̰� �ٸ��Ϳ��� ������ ����
        Vector3 desiredPosition = new Vector3(transform.position.x, target.position.y, transform.position.z) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

}
