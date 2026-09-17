using UnityEngine;

public class Chest : MonoBehaviour
{

    public bool udahDiambil {get; private set;} = false;
    private CanvasGroup ChestGroup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject ChestGroupDiCanvas = GameObject.Find("ChestMGroup");
        if (ChestGroupDiCanvas != null)
        {
            
            ChestGroup = ChestGroupDiCanvas.GetComponent<CanvasGroup>();
            ChestGroup.alpha =0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && SceneControl.InstanceSceneControl.actNow >= 56 && SceneControl.InstanceSceneControl.actNow <= 62 && !udahDiambil)
        {
            // Debug.Log("yyyy");
            ChestGroup.alpha = 0f;
            LeanTween.alphaCanvas(ChestGroup, 1f, 0.5f).setEase(LeanTweenType.easeInOutQuad);
            // udahDisiram = true;
        } 
    }

    public void DestroyChest()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && ChestGroup.alpha > 0)
        {
            ChestGroup.alpha = 1f;
            LeanTween.alphaCanvas(ChestGroup, 0f, 0.5f).setEase(LeanTweenType.easeInOutQuad);
        }


    }
}
