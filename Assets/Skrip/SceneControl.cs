using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{

    [SerializeField] private CanvasGroup KotakNamaCanvas;
    // public string actSaatIni;
    // public string[] objektifAll;



    public static SceneControl InstanceSceneControl {get; private set;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HideKotakNama();
        
    }

    private void Awake()
    {
        if (InstanceSceneControl != null && InstanceSceneControl != this)
        {
            Destroy(gameObject);
            return;
        }
        InstanceSceneControl = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowKotakNama()
    {
        KotakNamaCanvas.alpha = 1f;
        KotakNamaCanvas.interactable = true;
        KotakNamaCanvas.blocksRaycasts = true;
        // Debug.Log("aku di panggil");
    }

    public void HideKotakNama()
    {
        KotakNamaCanvas.alpha = 0f;
        KotakNamaCanvas.interactable = false;
        KotakNamaCanvas.blocksRaycasts = false;
        // Debug.Log("udah kehide dari " + gameObject.name);
    }
}
