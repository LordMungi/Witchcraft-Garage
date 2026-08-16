using UnityEngine;

public class DeliveredPopupUI : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] Animator animator;

    [Header("Listener Events")]
    [SerializeField] DevolutionEventChannel onPotionDelivered;

    private void OnEnable()
    {
        onPotionDelivered.OnEventTriggered += PlayAnimation;
    }
    private void OnDisable()
    {
        onPotionDelivered.OnEventTriggered -= PlayAnimation;
    }

    private void PlayAnimation(Devolution d)
    {
        animator.SetTrigger("ShowImage");
    }
}
