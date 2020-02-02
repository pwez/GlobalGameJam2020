using input;
using UnityEngine;

namespace players {
    [RequireComponent(typeof (Rigidbody2D))]
    [RequireComponent(typeof (BoxCollider2D))]
    [RequireComponent(typeof (Animator))]
    [RequireComponent(typeof (PlayerInput))]
    [RequireComponent(typeof (PlayerMotion))]
    public class Player : MonoBehaviour  {}
}