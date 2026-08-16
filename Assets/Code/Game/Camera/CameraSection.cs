using System;
using UnityEngine;

[Serializable] public struct CameraSection
{
    public Transform center;
    public Transform limitLeft;
    public Transform limitRight;
    public float limitLeftPosition;
    public float limitRightPosition;
}