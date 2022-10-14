using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _velocity;

    public Action OnCubeStopped;

    private void OnEnable()
    {
        Move();
    }

    public void Move()
    {
        Vector3 endPoint = transform.position;
        endPoint.x += _distance;
        transform.DOMove(endPoint, _distance / _velocity).OnComplete((() => OnCubeStopped?.Invoke()));
    }
}
