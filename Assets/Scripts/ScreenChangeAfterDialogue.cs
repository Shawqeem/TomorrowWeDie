using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenChangeAfterDialogue : MonoBehaviour
{
    [SerializeField] private GameObject imgFirst, imgSecond;

    [SerializeField] private float changeTime;

    [SerializeField] private DialogueSystem lastFinish;

    private Animator animator;
    private bool canBeCalled = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        lastFinish.OnDialogueFinish += DialogueSystem_OnDialogueFinish;
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

    private void DialogueSystem_OnDialogueFinish(object sender, System.EventArgs e)
    {
        canBeCalled = true;
    }

    void ChangeImage()
    {
        imgFirst.SetActive(false);
        imgSecond.SetActive(true);
    }
}
