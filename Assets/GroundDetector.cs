using UnityEngine;
using System.Collections;

public class GroundDetector : MonoBehaviour
{
    public Transform RayDestination;
    public bool IsGrounded;

    private int _groundMask;

    void Awake()
    {
        _groundMask = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        if (Physics2D.Linecast(this.transform.position, RayDestination.position, _groundMask))
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }
}
