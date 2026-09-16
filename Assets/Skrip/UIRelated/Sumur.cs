using UnityEngine;
using UnityEngine.U2D.IK;

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
        if (collision.CompareTag("Player"))
        {

            // Debug.Log("usah sampe sini masuk trigger sumur");
            SumurGroup.alpha = 0f;
            LeanTween.alphaCanvas(SumurGroup, 1f, 0.5f).setEase(LeanTweenType.easeInOutQuad);
        }


    }

    // private void JagainBiarGaErorSumur()
    // {
    //     SumurGroup.alpha = 1f;
    //     LeanTween.alphaCanvas(SumurGroup, 0f, 0.5f).setEase(LeanTweenType.easeInOutQuad);
    //     // if (SceneControl.InstanceSceneControl.actNow > 12 && SceneControl.InstanceSceneControl.actNow < 8)
    //     // {

    //     //     SumurTrigger.SetActive(false);
    //     //     Debug.Log("mati haha");
    //     // }
    // }

// & SceneControl.InstanceSceneControl.actNow >= 8 && SceneControl.InstanceSceneControl.actNow < 13 || SceneControl.InstanceSceneControl.actNow >= 8
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") ) 
        {
            // Debug.Log("usah sampe sini exit trigger sumur");
            // JagainBiarGaErorSumur();
            SumurGroup.alpha = 1f;
            LeanTween.alphaCanvas(SumurGroup, 0f, 0.5f).setEase(LeanTweenType.easeInOutQuad);
        }
    }
}
