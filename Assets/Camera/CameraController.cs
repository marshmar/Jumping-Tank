using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Camera이동 로직 구현은 절대강좌 유니티- 이재현저 를 참고하였습니다.
public class CameraController: MonoBehaviour
{
    public Transform targetTr;
    private Transform camTr;

    public float distance = 20.0f;
    public float height = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        camTr = GetComponent<Transform>();    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        camTr.position = targetTr.position + (-targetTr.forward * distance) + (Vector3.up * height);
        camTr.LookAt(targetTr.position);
    }
}
