using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReviewUI : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private Image starsImage;
    [SerializeField] private TextMeshProUGUI reviewText;

    [Header("Listener Events")]
    [SerializeField] private DevolutionEventChannel onReviewPosted;

    void Start()
    {
        starsImage.fillAmount = 0;
        reviewText.text = "There aren't any reviews yet. Get to work!";
    }

    private void OnEnable()
    {
        onReviewPosted.OnEventTriggered += UpdateReview;
    }

    private void OnDisable()
    {
        onReviewPosted.OnEventTriggered -= UpdateReview;
    }

    private void UpdateReview(Devolution review)
    {
        starsImage.fillAmount = review.rating / 10f;
        reviewText.text = review.text;
    }

}
