using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCollision : MonoBehaviour
{
    private bool isColliding = false; // ���� �浹 ���¸� �����ϴ� ����

    private void OnCollisionEnter(Collision collision)
    {
        if (isColliding) return; // �̹� �浹 ���̶�� ����

        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            isColliding = true; // �浹 ���� Ȱ��ȭ

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
            isColliding = false; // �浹 ���� ��Ȱ��ȭ
        }
    }
}

/*
        if (isColliding) return; // �̹� �浹 ���̶�� ����

        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            isColliding = true; // �浹 ���� Ȱ��ȭ

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