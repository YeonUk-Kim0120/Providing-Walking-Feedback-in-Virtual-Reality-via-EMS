using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    public AudioSource audio1; // ù ��° ����� �ҽ�
    public AudioSource audio2; // �� ��° ����� �ҽ�
    public AudioSource audio3; // �� ��° ����� �ҽ�

    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        if (audioSources.Length >= 3)
        {
            audio1 = audioSources[0]; // ù ��° ����� �ҽ�
            audio2 = audioSources[1]; // �� ��° ����� �ҽ�
            audio3 = audioSources[2]; // �� ��° ����� �ҽ�
        }
        else
        {
            Debug.LogError("����� �ҽ��� ������� �ʽ��ϴ�. �� ���� ����� �ҽ��� �߰��ϼ���.");
        }
    }
    //audioSource.time = 0.1f;
    //audioSource.pitch = 1.5f;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Sand")
        {
            audio2.Stop();
            audio2.time = 0.1f;
            audio2.Play();
        }
        else if (other.gameObject.tag == "Mud")
        {
            audio3.Stop();
            audio3.time = 0.05f;
            audio3.Play();
        }
        else if (other.gameObject.tag == "Player")
        {
        }
        else
        {
            audio1.Stop();
            audio1.time = 0.15f;
            audio1.Play();
        }
    }
}
