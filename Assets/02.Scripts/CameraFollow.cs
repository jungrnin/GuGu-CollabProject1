using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllow : MonoBehaviour
{
    public Transform target;       // 따라갈 대상 (플레이어)
    public Vector3 offset;         // 카메라 위치 보정
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {    // 카메라에는 x,y,z축이 존재함 하지만(0,0,-10) 이것처럼 z축은 음수인데 0이면 다른것들과 겹치기때문에 음수 즉 시각적 순서만 조절한것이고 다른것에는 영향이 없음
        Vector3 desiredPosition = new Vector3(transform.position.x, target.position.y, transform.position.z) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

}
