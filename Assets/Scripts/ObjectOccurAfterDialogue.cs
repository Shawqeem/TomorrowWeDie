using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOccurAfterDialogue : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    [SerializeField] private float changeTime;

    [SerializeField] private DialogueSystem lastFinish;

    private bool canBeCalled = false;

    // Start is called before the first frame update
    void Start()
    {
        lastFinish.OnDialogueFinish += DialogueSystem_OnDialogueFinish;
    }

    // Update is called once per frame
    void Update()
    {
        if (canBeCalled)
        {
            Invoke("ChangeObject", changeTime);
            canBeCalled = false;
        }
    }

    private void DialogueSystem_OnDialogueFinish(object sender, System.EventArgs e)
    {
        canBeCalled = true;
    }

    void ChangeObject()
    {
        obj.SetActive(true);
    }
}
