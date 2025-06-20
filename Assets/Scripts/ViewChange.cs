using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewChange : MonoBehaviour
{
    public GameObject firstPersonView;  // 첫 번째 카메라

    private void OnEnable()
    {
        firstPersonView.SetActive(true);
    }

    private void OnDisable()
    {
        firstPersonView.SetActive(false);
    }
}
