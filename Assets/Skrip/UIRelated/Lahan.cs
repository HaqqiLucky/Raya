using UnityEditor;
using UnityEngine;

public class Lahan : MonoBehaviour
{

    public bool udahDisiram {get; private set;} = false;
    private CanvasGroup LahanGroup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject LahanGroupDiCanvas = GameObject.Find("LahanBGroup");
        if (LahanGroupDiCanvas != null)
        {
            
            LahanGroup = LahanGroupDiCanvas.GetComponent<CanvasGroup>();
            LahanGroup.alpha =0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && SceneControl.InstanceSceneControl.actNow >= 39 && SceneControl.InstanceSceneControl.actNow <= 49 && gameObject.transform.parent.name.Contains("Beefroot Bu Nia") && !udahDisiram)
        {
            Debug.Log("yyyy");
            LahanGroup.alpha = 0f;
            LeanTween.alphaCanvas(LahanGroup, 1f, 0.5f).setEase(LeanTweenType.easeInOutQuad);
            udahDisiram = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && LahanGroup.alpha > 0)
        {
            LahanGroup.alpha = 1f;
            LeanTween.alphaCanvas(LahanGroup, 1f, 0.5f).setEase(LeanTweenType.easeInOutQuad);
        }


    }

    public void SiramLahan()
    {
        udahDisiram = true;
    }
}
