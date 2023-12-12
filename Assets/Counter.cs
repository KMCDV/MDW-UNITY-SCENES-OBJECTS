using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI _TextMesh;

    private float counter = 0;
    private void Update()
    {
        _TextMesh.text = counter.ToString();
        counter += Time.deltaTime;
    }
}
