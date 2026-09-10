using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    public int actNow = 0;    // ini sama dengan id di data
    
    [Header("UI")]
    [SerializeField] private CanvasGroup LayarHitamUI;
    [SerializeField] private GameObject ParentCats;
    [SerializeField] private CanvasGroup KotakNamaCanvas;
    [SerializeField] private CanvasGroup ObjektifDiPerbarui;
    


    [Header("Cats")]
    [SerializeField] private GameObject Gradle;
    [SerializeField] private GameObject Musi;
    [SerializeField] private GameObject Doker;


    [Header("Variable")]
    public int CatsTaken;
    // public string actSaatIni;
    // public string[] objektifAll;



    public static SceneControl InstanceSceneControl {get; private set;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ObjektifDiPerbarui.gameObject.SetActive(false);
        HideKotakNama();
        ParentCats.SetActive(false);
        
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

    public void ShowObjektifDiperbarui()
    {
        ObjektifDiPerbarui.alpha = 0f;
        LeanTween.alphaCanvas(ObjektifDiPerbarui, 1f, 0.5f).setEase(LeanTweenType.easeInOutQuad);
    }

    public void HideObjektifDiperbarui()
    {
        ObjektifDiPerbarui.alpha = 1f;
        LeanTween.alphaCanvas(ObjektifDiPerbarui, 0f, 0.5f).setEase(LeanTweenType.easeInOutQuad);
    }

    public void ShowKotakNama()
    {
        KotakNamaCanvas.alpha = 1f;
        KotakNamaCanvas.interactable = true;
        KotakNamaCanvas.blocksRaycasts = true;
        // Debug.Log("aku di panggil");
    }


    public LTDescr LayarHitam(bool Tampilkan)
    {
        float alphaTarget = Tampilkan ? 1f : 0f;
        LayarHitamUI.blocksRaycasts = Tampilkan;
        LayarHitamUI.interactable = Tampilkan;
        return LeanTween.alphaCanvas(LayarHitamUI, alphaTarget, 1f)
                .setEase(LeanTweenType.easeOutQuad);
    }

    public void HideKotakNama()
    {
        KotakNamaCanvas.alpha = 0f;
        KotakNamaCanvas.interactable = false;
        KotakNamaCanvas.blocksRaycasts = false;
        // Debug.Log("udah kehide dari " + gameObject.name);
    }

    public void Act3Kucing()
    {
        if (!ParentCats.activeSelf)
        {
            LayarHitam(true).setOnComplete(() =>
            {
                ParentCats.SetActive(true);
                LayarHitam(false);
            });
        }


 
    }

}
