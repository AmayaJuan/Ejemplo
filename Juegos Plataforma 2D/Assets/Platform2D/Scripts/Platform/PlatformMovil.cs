﻿using UnityEngine;

public class PlatformMovil : MonoBehaviour
{
    public float speed;
    public Transform target;

    private Vector3 start, end;

    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            target.parent = null;
            start = transform.position;
            end = target.position;
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        }

        if (transform.position == target.position)
            target.position = (target.position == start) ? end : start;
    }
}
