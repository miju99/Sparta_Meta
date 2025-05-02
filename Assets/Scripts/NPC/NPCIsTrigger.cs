using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    private Animator animator;
    public Canvas Score;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        if(Score != null)
        {
            Score.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("IsTriggered", true);

            if(Score != null)
            {
                Score.enabled = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("IsTriggered", false); // 플레이어가 멀어지면 끄기 (선택사항)

            if (Score != null)
            {
                Score.enabled = false;
            }
        }
    }
}
