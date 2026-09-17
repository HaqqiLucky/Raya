using UnityEngine;

public class Patung : MonoBehaviour
{

    [SerializeField] private CanvasGroup PatungKGroup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && SceneControl.InstanceSceneControl.actNow == 63)
        {
            PatungKGroup.alpha = 0f;
            LeanTween.alphaCanvas(PatungKGroup, 1f, 0.5f).setEase(LeanTweenType.easeInOutQuad);
            // udahDisiram = true;
        } 
    }

    // private void OnTriggerStay2D(Collider2D collision)
    // {
    //     if(collision.CompareTag("Player") && SceneControl.InstanceSceneControl.actNow != 63)
    //     {
    //         PatungKGroup.alpha = 1f;
    //         LeanTween.alphaCanvas(PatungKGroup, 0f, 0.5f).setEase(LeanTweenType.easeInOutQuad);
    //         // udahDisiram = true;
    //     } 
    // }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && PatungKGroup.alpha > 0)
        {
            LeanTween.alphaCanvas(PatungKGroup, 0f, 0.5f).setEase(LeanTweenType.easeInOutQuad);
            // udahDisiram = true;
        } 
    }
}
