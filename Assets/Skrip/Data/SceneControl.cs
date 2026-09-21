using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class SceneControl : MonoBehaviour
{
      // ini sama dengan id di data
    
    [Header("Variable")]
    public int actNow = 0;  
    public int CatsTaken;
    public int EmberTaken = 0;
    public int WaterTakenForLahan = 0;
    


    [Header("UI")]
    [SerializeField] private CanvasGroup LayarHitamUI;
    [SerializeField] private GameObject ParentCats;
    [SerializeField] private CanvasGroup KotakNamaCanvas;
    [SerializeField] private CanvasGroup ObjektifDiPerbarui;
    [SerializeField] private GameObject SumurTrigger;
    [SerializeField] private TMP_Text GantiDayText;

    [SerializeField] private CanvasGroup SumurGroupIM;
    [SerializeField] private TMP_Text GantiPeringatan;
    [SerializeField] private CanvasGroup LahanGroup;
    [SerializeField] private CanvasGroup PatungGroup;
    [SerializeField] private GameObject UIObjektif;
    [SerializeField] private TMP_Text teksObjektif;
    [SerializeField] private TMP_Text teksKotakNama;
    // private CanvasGroup GantiDayCanvas;
    // [SerializeField] private TMP_Text ObjektifPerAct;
    
    [Header("People")]
    [SerializeField] private GameObject AllPeople;
    [SerializeField] private GameObject Raya;
    [SerializeField] private GameObject Liam;
    [SerializeField] private GameObject Haqi;
    [SerializeField] private GameObject Sakinah;


    [Header("Enviroment")]
    [SerializeField] private Light2D light2D;
    



    // public string actSaatIni;
    // public string[] objektifAll;


    [Header("Raya Input Control")]
    private PlayerInput playerInput;
    [SerializeField] private RayaInputManagement rayaInputManagement;
    [SerializeField] private PlayerInput RayaPlayerInput;



    public static SceneControl InstanceSceneControl {get; private set;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ObjektifDiPerbarui.gameObject.SetActive(false);
        HideKotakNama();
        ParentCats.SetActive(false);
        SumurTrigger.SetActive(false);
        playerInput = Raya.GetComponent<PlayerInput>();
        // GantiDayCanvas = GantiDay.GetComponent<CanvasGroup>();
        
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
    private void OnDestroy()
    {
        if (InstanceSceneControl == this)
        {
            InstanceSceneControl = null;
        }
    }

    public void ShowObjektifDiperbarui()
    {
        LeanTween.cancel(ObjektifDiPerbarui.gameObject);
        ObjektifDiPerbarui.alpha = 0f;
        LeanTween.alphaCanvas(ObjektifDiPerbarui, 1f, 0.3f).setEase(LeanTweenType.easeInOutQuad);
    }

    public void HideObjektifDiperbarui()
    {
        LeanTween.cancel(ObjektifDiPerbarui.gameObject);
        ObjektifDiPerbarui.alpha = 1f;
        LeanTween.alphaCanvas(ObjektifDiPerbarui, 0f, 0.3f).setEase(LeanTweenType.easeInOutQuad);
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


    public IEnumerator Act7Liam1()
    {
        yield return null;
        RayaPlayerInput.enabled = false;
        LayarHitam(true).setOnComplete(() =>
        {
            Liam.transform.localPosition = new Vector3(-6.11592102f,17.0515289f,0);
            

            StartCoroutine(TutupGantiDay(3));
        });
    }

    public IEnumerator BlackScreenBiasa()
    {
        yield return null;
        RayaPlayerInput.enabled = false;
        LayarHitam(true).setOnComplete(() =>
        {
            StartCoroutine(TutupGantiDay(3));
        });
    }

    public IEnumerator Act7Liam2()
    {
        yield return null;
        RayaPlayerInput.enabled = false;
        LayarHitam(true).setOnComplete(() =>
        {
            Liam.transform.localPosition = new Vector3(-7.11592102f,-24.9484711f,0);
            

            StartCoroutine(TutupGantiDay(3));
        });
    }

    public IEnumerator Act5Haqi()
    {
        yield return null;
        RayaPlayerInput.enabled = false;
        LayarHitam(true).setOnComplete(() =>
        {
            // Liam.transform.position = new Vector3(10.88408f, -3.94847f, 0f);
            Haqi.SetActive(true);

            StartCoroutine(TutupGantiDay(3));
        });
    }

    public IEnumerator GantiDayCorotine(string tulisanGanti)
    {
        yield return null;
        RayaPlayerInput.enabled = false;
        LayarHitam(true).setOnComplete(() =>
        {
            GantiDayText.gameObject.SetActive(true);
            GantiDayText.text = tulisanGanti;
            Raya.transform.position = new Vector3(-66f, -10.5f, 0f);

            StartCoroutine(TutupGantiDay(7));
        });
    }
    
    IEnumerator TutupGantiDay(float time)
    {
        yield return new WaitForSeconds(time);
        GantiDayText.gameObject.SetActive(false);
        LayarHitam(false);
        RayaPlayerInput.enabled = true;
    }



    public void DialogSelesai( bool actMaju = true )
    {
        if (actMaju)
        {
            SceneControl.InstanceSceneControl.actNow +=1;
        }
        else
        {
            SceneControl.InstanceSceneControl.actNow -=1;
        }
        GantiPeringatan.text = "Objektif berhasil diperbarui";
        playerInput.enabled = true;
        UIObjektif.SetActive(true);

        ActManagement();
        // Debug.Log("Sampe sini");

        // semua kondisi mengenai act
        switch (SceneControl.InstanceSceneControl.actNow)
        {
            case (3) :
                SceneControl.InstanceSceneControl.Act3Kucing();
                break;
            case (8): 
                rayaInputManagement.sumurOn();
                break;
            case (13):
                rayaInputManagement.sumurOff();
                break;
            case (16):
                StartCoroutine(SceneControl.InstanceSceneControl.GantiDayCorotine("Kau kembali ke pusat dan beristirahat untuk hari ini. Ketika kau bangun tidur kau menyadari hari ini adalah hari ke-2"));
                break;
            // ini ganti
            case (26):
                StartCoroutine(SceneControl.InstanceSceneControl.GantiDayCorotine("Kau kembali ke pusat dan beristirahat untuk hari ini. Ketika kau bangun tidur kau menyadari hari ini adalah hari ke-3"));
                break;
            case (29):
                rayaInputManagement.sumurOn();
                break;
            case (39):
                rayaInputManagement.sumurOff();
                rayaInputManagement.LahanOn();
                break;
            case (49):
                rayaInputManagement.LahanOff();
                break;
            case (51):
                SceneControl.InstanceSceneControl.Act5Haqi();
                break;
            case (52):
                Haqi.SetActive(false);
                break;
            case (56):
                rayaInputManagement.CariChestOn();
                break;
            case (63):
                rayaInputManagement.CariChestOff();
                break;
            case (65):
                StartCoroutine(SceneControl.InstanceSceneControl.GantiDayCorotine("Kau kembali ke pusat dan beristirahat untuk hari ini. Ketika kau bangun tidur kau menyadari hari ini adalah hari ke-4"));
                Liam.SetActive(true);
                break;
            case (67) :
                StartCoroutine(Act7Liam1());
                break;
            case (68) :
                StartCoroutine(Act7Liam2());
                break;
            case (69) :
                StartCoroutine(BlackScreenBiasa());
                Liam.SetActive(false);
                Sakinah.SetActive(true);
                break;
            case (71) :
                StartCoroutine(BlackScreenBiasa());
                light2D.color = Color.red;
                AllPeople.SetActive(false);
                break;
        }
    }

    public IEnumerator Objektif()
    {
        ShowObjektifDiperbarui();
        // Debug.Log("sampe siniqqqq");
        yield return new WaitForSeconds(2f);
        HideObjektifDiperbarui();
        // Debug.Log("sampe tutup");
    }

    public void ActManagement()
    {
        ShowObjektifDiperbarui();

        teksObjektif.text = QuestData.GetQuestDenganId(SceneControl.InstanceSceneControl.actNow)?.objektif;
        teksKotakNama.text = QuestData.GetQuestDenganId(SceneControl.InstanceSceneControl.actNow)?.idNPC.ToString();

        StartCoroutine(Objektif());
    }



    public void MulaiDialog()
    {
        // SceneControl.InstanceSceneControl.HideObjektifDiperbarui();
        playerInput.enabled = false;
        UIObjektif.SetActive(false);
        HideKotakNama();
        // KameraTurunPasDialog();
    }

// 

}
