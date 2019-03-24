using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class cowAnimation : MonoBehaviour
{
    private Animator anim = null;
    private Vector3 oldPosition = Vector3.zero;
    public bool isMoving;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = Instantiate(Resources.Load("Animations/cow_animation_controller")) as RuntimeAnimatorController;
        oldPosition = transform.position;
        isMoving = false;
    }

    void Update()
    {
        if (oldPosition != transform.position)
            isMoving = true;
        else isMoving = false;

        anim.SetBool("isMoving", isMoving);
    }
}
