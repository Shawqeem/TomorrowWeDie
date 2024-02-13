using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDark : MonoBehaviour
{
    [SerializeField] private GameObject txtFirst, txtSecond;

    [SerializeField] private float changeTime;

    private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            animator.SetBool("ChangeToDark", true);
            Invoke("ChangeText", changeTime);
        }
    }

    private void ChangeText()
    {
        txtFirst.SetActive(false);
        txtSecond.SetActive(true);
    }
}
