using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenChange : MonoBehaviour
{
    [SerializeField] private GameObject imgFirst, imgSecond;

    [SerializeField] private float changeTime;

    private Animator animator;
    private bool canBeCalled = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canBeCalled && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            animator.SetBool("ChangeToWhite", true);
            Invoke("ChangeImage", changeTime);
            canBeCalled = false;
        }
    }

    void ChangeImage()
    {
        imgFirst.SetActive(false);
        imgSecond.SetActive(true);
    }
}
