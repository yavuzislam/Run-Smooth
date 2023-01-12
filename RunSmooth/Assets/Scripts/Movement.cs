using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
public class Movement : MonoBehaviour
{public bool set;
    public PlayerControl playerControl;
    public Transform currentLeadTransform;
    float currentVelocity = 0.0f;
    float smoothTime = 0.0525f;
    private void Update()
    {
        if (!set)
        {
            Move();
        }
    }
    public void Move()
    {
        if (currentLeadTransform == null)
        {
            return;
        }
        else
        {
            transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, currentLeadTransform.position.x, ref currentVelocity, smoothTime),
                transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collected")
        {
            //other.tag = "Collect";
            transform.tag = "Collected";
            transform.GetComponent<BoxCollider>().isTrigger = false;
            transform.parent = other.transform.parent;
            playerControl.stackList.Add(transform.gameObject);
            //playerControl.stackList[playerControl.stackList.Count - 1].transform.position += new Vector3(0, 0, playerControl.stackList.Count * 1.5f);
            playerControl.stackList[playerControl.stackList.Count - 1].transform.position = playerControl.stackList[playerControl.stackList.Count - 2].transform.position +
                new Vector3(0, 0, 1.5f);
            SetLeadTransform(playerControl.stackList[playerControl.stackList.Count - 2].transform);
        }
    }
    public void SetLeadTransform(Transform leadTransform)
    {
        currentLeadTransform = leadTransform;
    }
}
