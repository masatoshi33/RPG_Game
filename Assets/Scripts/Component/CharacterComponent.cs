using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
    public enum Direction
    {
        forward = 0,
        back = 1,
        left = 2,
        right = 3,
    }

    public Transform transform;
    public Direction direction;
    public float speed;
    public Transform targetPosition;
    public Animator animator;
    public Rigidbody rigidbody;
}