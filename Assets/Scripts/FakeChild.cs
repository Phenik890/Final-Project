using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeChild : MonoBehaviour
{
    public Transform FakeParent;

    private Vector3 _positionOffset;
    private Quaternion _rotationOffset;

    private void Start()
    {
        if (FakeParent != null)
        {
            SetFakeParent(FakeParent);
        }
    }

    private void Update()
    {
        if (FakeParent == null)
            return;

        var targetPos = FakeParent.position - _positionOffset;
        var targetRot = FakeParent.localRotation * _rotationOffset;

        transform.position = RotatePointAroundPivot(targetPos, FakeParent.position, targetRot);
        transform.localRotation = targetRot;
    }

    public void SetFakeParent(Transform parent)
    {
        _positionOffset = parent.position - transform.position;
        _rotationOffset = Quaternion.Inverse(parent.localRotation * transform.localRotation);
        FakeParent = parent;
    }

    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion rotation)
    {
        Vector3 dir = point - pivot;
        dir = rotation * dir;
        point = dir + pivot;
        return point;
    }
}