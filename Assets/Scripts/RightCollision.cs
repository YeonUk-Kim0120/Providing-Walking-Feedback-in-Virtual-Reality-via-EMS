using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCollision : MonoBehaviour
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
                RSerialObject.RInstance.SendData("Sand");
            }
            else if (collision.gameObject.tag == "Mud")
            {
                RSerialObject.RInstance.SendData("Mud");
            }
            else
            {
                RSerialObject.RInstance.SendData("Map");
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
        Rigidbody otherRb = collision.rigidbody;
        if (otherRb != null)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Map"))
            {
                if (collision.gameObject.tag == "Sand")
                {
                    RSerialObject.RInstance.SendData("RightSand");
                }
                else if (collision.gameObject.tag == "Mud")
                {
                    RSerialObject.RInstance.SendData("RightMud");
                }
                else
                {
                    RSerialObject.RInstance.SendData("Right");
                }
            }
            Debug.Log(1);
        }
*/