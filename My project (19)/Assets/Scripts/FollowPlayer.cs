using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform cameraTarget;
    public Transform lookTarget;

    public float _speed;
    public Vector3 distance;

    private void LateUpdate()
    {
        Vector3 dPos = cameraTarget.position + distance;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, _speed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(lookTarget.position);
    }
}
