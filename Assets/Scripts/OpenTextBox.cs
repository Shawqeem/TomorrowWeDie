using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTextBox : MonoBehaviour
{
    [SerializeField] private GameObject textBox;

    bool called = false;

    // Update is called once per frame
    private void Update()
    {
        if (!called && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            textBox.SetActive(true);
            called = true;
        }
    }
}
