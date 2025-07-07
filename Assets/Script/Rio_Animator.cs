using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Rio_Animator : MonoBehaviour
{
    private Animator animator;
    private AudioSource runSfx;

    void Start()
    {
        animator = GetComponent<Animator>();
        runSfx = gameObject.AddComponent<AudioSource>();
        runSfx.clip = SoundManager.Instance.GetClip(Sound.Walk);
    }

    public void UpdateAnimation(float moveInput, bool isJumping)
    {
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        animator.SetBool("isJumping", isJumping);

        bool isRunning = Mathf.Abs(moveInput) > 0.1f && !isJumping;

        if (isRunning)
        {
            if (!runSfx.isPlaying)
            {
                runSfx.Play();
            }
        }
        else
        {
            if (runSfx.isPlaying)
            {
                runSfx.Stop();
            }
        }
    }
}
