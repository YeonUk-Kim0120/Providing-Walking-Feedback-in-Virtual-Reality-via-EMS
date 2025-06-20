using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCollision : MonoBehaviour
{
    private bool isColliding = false; // 현재 충돌 상태를 추적하는 변수

    private void OnCollisionEnter(Collision collision)
    {
        if (isColliding) return; // 이미 충돌 중이라면 무시

        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            isColliding = true; // 충돌 상태 활성화

            if (collision.gameObject.tag == "Sand")
            {
                LSerialObject.LInstance.SendData("Sand");
            }
            else if (collision.gameObject.tag == "Mud")
            {
                LSerialObject.LInstance.SendData("Mud");
            }
            else
            {
                LSerialObject.LInstance.SendData("Map");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            isColliding = false; // 충돌 상태 비활성화
        }
    }
}

/*
        if (isColliding) return; // 이미 충돌 중이라면 무시

        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            isColliding = true; // 충돌 상태 활성화

            if (collision.gameObject.tag == "Sand")
            {
                LSerialObject.LInstance.SendData(ThirdPersonController.way + "Sand");
            }
            else if (collision.gameObject.tag == "Mud")
            {
                LSerialObject.LInstance.SendData(ThirdPersonController.way + "Mud");
            }
            else
            {
                LSerialObject.LInstance.SendData(ThirdPersonController.way + "Map");
            }
        }
*/