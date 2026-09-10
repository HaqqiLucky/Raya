using UnityEngine;

public class Sumur : MonoBehaviour
{

    [SerializeField] private CanvasGroup SumurGroup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // SumurGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SumurGroup.alpha = 0f;
        LeanTween.alphaCanvas(SumurGroup, 1f, 0.5f).setEase(LeanTweenType.easeInOutQuad);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SumurGroup.alpha = 1f;
        LeanTween.alphaCanvas(SumurGroup, 0f, 0.5f).setEase(LeanTweenType.easeInOutQuad);
    }
}
