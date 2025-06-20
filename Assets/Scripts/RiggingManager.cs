using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggingManager : MonoBehaviour
{

    public Transform leftHandIK;
    public Transform rightHandIK;
    public Transform HeadIK;

    public Transform leftController;
    public Transform rightController;
    public Transform HMD;

    public Vector3[] leftOffset;
    public Vector3[] rightOffset;
    public Vector3[] headOffset;


    void LateUpdate()
    {
        MappingHandTransform(leftHandIK, leftController, true);
        MappingHandTransform(rightHandIK, rightController, false);
        MappingHeadRotation(HeadIK, HMD);
    }

    private void MappingHandTransform(Transform ik, Transform controller, bool isLeft)
    {
        var offset = isLeft ? leftOffset : rightOffset;
        ik.position = controller.TransformPoint(offset[0]);
        //Debug.Log(ik.position);
        ik.rotation = controller.rotation * Quaternion.Euler(offset[1]);
    }

    private void MappingHeadRotation(Transform ik, Transform hmd)
    {
        ik.position = hmd.position + headOffset[0]; // 캐릭터의 머리 위치로 고정
        ik.rotation = hmd.rotation; // HMD의 회전만 적용
    }
}
