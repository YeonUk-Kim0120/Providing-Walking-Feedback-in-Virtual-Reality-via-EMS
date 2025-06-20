using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    public AudioSource audio1; // 첫 번째 오디오 소스
    public AudioSource audio2; // 두 번째 오디오 소스
    public AudioSource audio3; // 세 번째 오디오 소스

    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        if (audioSources.Length >= 3)
        {
            audio1 = audioSources[0]; // 첫 번째 오디오 소스
            audio2 = audioSources[1]; // 두 번째 오디오 소스
            audio3 = audioSources[2]; // 두 번째 오디오 소스
        }
        else
        {
            Debug.LogError("오디오 소스가 충분하지 않습니다. 두 개의 오디오 소스를 추가하세요.");
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
