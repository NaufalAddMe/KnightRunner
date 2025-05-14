using UnityEngine;

public enum KnightState
{
    Die = -1,
    Idle = 0,
    Walk = 1,
    Fall = 2,
    Jump = 3,
    Attack = 4
}

[RequireComponent(typeof(Rigidbody2D))]
public class KnightController : MonoBehaviour
{
    public GroundDetector Detector;
    public Animator KnightAnimator;
    public float Speed;
    public float JumpPower;
    public float FallSpeedMultiplier = 2f; // Tambahan: kecepatan jatuh saat fast fall

    private Rigidbody2D _rigidbody;
    private Vector2 _input;
    private KnightState _state;

    private bool _jumpRequest;
    private bool _fastFall;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = Vector2.zero;
        _state = KnightState.Idle;
    }

    void Update()
    {
        // Input lompat
        if (Detector.IsGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            _jumpRequest = true;
        }

        // Input fast fall (panah bawah)
        if (!Detector.IsGrounded && Input.GetKey(KeyCode.DownArrow))
        {
            _fastFall = true;
        }
        else
        {
            _fastFall = false;
        }

        // Update animasi
        if (Detector.IsGrounded)
        {
            if (_jumpRequest)
            {
                Jump();
            }
            else
            {
                if (_input.x != 0)
                    SetState(KnightState.Walk, "Walk");
                else
                    SetState(KnightState.Idle, "Idle");
            }
        }
        else
        {
            if (_state != KnightState.Fall)
                SetState(KnightState.Fall, "Jump"); // Gunakan animasi Jump/Fall
        }

        // Input horizontal (kiri-kanan)
        _input.x = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        Vector2 velocity = _rigidbody.linearVelocity;
        velocity.x = _input.x * Speed;

        // Fast fall
        if (_fastFall)
        {
            velocity.y -= FallSpeedMultiplier;
        }

        _rigidbody.linearVelocity = velocity;

        // Flip arah karakter
        Vector3 scale = transform.localScale;
        if (_input.x > 0 && scale.x < 0)
            scale.x *= -1f;
        else if (_input.x < 0 && scale.x > 0)
            scale.x *= -1f;

        transform.localScale = scale;
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        SetState(KnightState.Jump, "Jump");
        _jumpRequest = false;
    }

    private void SetState(KnightState newState, string animationName)
    {
        if (_state != newState)
        {
            KnightAnimator.Play(animationName);
            _state = newState;
        }
    }
}
