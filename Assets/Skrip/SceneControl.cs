using System.Collections.Generic;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    public int actNow = 0;
    


    [SerializeField] private CanvasGroup KotakNamaCanvas;
    // public string actSaatIni;
    // public string[] objektifAll;



    public static SceneControl InstanceSceneControl {get; private set;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HideKotakNama();
        
    }
    // public void QuestDataControl(int idNPC, string objektif, string acting)
    // {
    //     QuestVariable questNow = QuestData.GetQuestDenganId(actNow);
    //     if (questNow != null)
    //     {
    //         // idNPC  = questNow.idNPC;
    //         objektif = questNow.objektif;
    //         acting = questNow.namaAct;
    //     }
    //     return;
    // }

    private void Awake()
    {
        if (InstanceSceneControl != null && InstanceSceneControl != this)
        {
            Destroy(gameObject);
            return;
        }
        InstanceSceneControl = this;
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
