using UnityEngine;

public class Rio_Controller : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCol;
    [SerializeField] private Rigidbody2D rig2D;
    [Header("Movement Settings")]
    [SerializeField] public float speed;
    [SerializeField] public float jump;
    [Header("Ground Check Settings")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector2 boxSize = new Vector2(0.6f, 0.1f);
    [SerializeField] private Vector2 boxOffset = new Vector2(0f, -1.1f);

    private Rio_Animator rioAnimator;

    private bool isGrounded = false;
    private float horizontal;

    private void Start()
    {
        rioAnimator = GetComponent<Rio_Animator>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        CracterMove(horizontal);
        Jump();

        if (rioAnimator != null)
            rioAnimator.UpdateAnimation(horizontal, !isGrounded);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox((Vector2)transform.position + boxOffset, boxSize, 0f, groundLayer);
    }

    public void CracterMove(float horizontal)
    {
        Vector2 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

       
        if (horizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            SoundManager.Instance.PlaySound(Sound.Jump);
            rig2D.velocity = new Vector2(rig2D.velocity.x, 0f);
            rig2D.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube((Vector2)transform.position + boxOffset, boxSize);
    }

    public Rigidbody2D GetRigBody() { return rig2D; }
}
