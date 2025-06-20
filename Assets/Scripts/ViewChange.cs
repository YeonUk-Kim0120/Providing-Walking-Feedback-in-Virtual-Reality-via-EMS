using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewChange : MonoBehaviour
{
    public GameObject firstPersonView;  // ù ��° ī�޶�

    private void OnEnable()
    {
        firstPersonView.SetActive(true);
    }

    private void OnDisable()
    {
        firstPersonView.SetActive(false);
    }
}
