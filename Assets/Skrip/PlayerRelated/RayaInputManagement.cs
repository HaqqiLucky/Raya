using System.Collections;
using TMPro;
using Unity.Cinemachine;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class RayaInputManagement : MonoBehaviour
{
    [Header("Masalah UI")]
    [SerializeField] private CanvasGroup KotakNamaCanvas;
    [SerializeField] private CinemachineCamera cinemachineCamera;

    [SerializeField] private GameObject CatsAroundHouse;
    [SerializeField] private CanvasGroup SumurGroupIM;
    [SerializeField] private TMP_Text GantiPeringatan;
    [SerializeField] private CanvasGroup LahanGroup;
    [SerializeField] private CanvasGroup PatungGroup;
    [SerializeField] private TMP_Text teksKotakNama;
    private PlayerInput playerInput;

    [Header("Masalah Player")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private BoxCollider2D RayaColliderTrigger;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    [SerializeField] private DialogueRunner dialogRunner;
    [SerializeField] private GameObject SumurTrigger;
    [SerializeField] private GameObject CanvasSumurGroup;
    [SerializeField] private InputActionReference pActionRef;
    [SerializeField] private InputActionReference qActionRef;
    [SerializeField] private InputActionReference bActionRef;
    [SerializeField] private InputActionReference mActionRef;
    // [SerializeField] private DialogueRunner dialogRunner;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RayaColliderTrigger = GetComponentInChildren<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0f,180f,0f);
        }
        else if (moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0f,0f,0f);
        }
        if (context.performed)
        {
            animator.SetFloat("Blend", 1);
            
        }
        if (context.canceled)
        {
            animator.SetFloat("Blend", 0);
        }

    }




    public void InteractionWithNPC(InputAction.CallbackContext context)
    {
        // Debug.Log("hdfwf");
        // pencet f
        if (context.performed && KotakNamaCanvas.interactable)
        {

            if (!teksKotakNama.text.Contains("Ambil"))
            {
                if (!dialogRunner.IsDialogueRunning)
                {
                    _ = dialogRunner.StartDialogue(QuestData.GetQuestDenganId(SceneControl.InstanceSceneControl.actNow).namaAct); // ini tar ganti
                }
            }
            else
            {
                foreach (Collider2D hit in Physics2D.OverlapBoxAll(RayaColliderTrigger.bounds.center, RayaColliderTrigger.bounds.size, 0f))
                {

                    if (hit.CompareTag("Hewani"))
                        {
                            Destroy(hit.gameObject);
                            // SceneControl.InstanceSceneControl.ThisQuestNeedSecondObjective("Kucing yang di ambil: " + SceneControl.InstanceSceneControl.CatsTaken);
                            SceneControl.InstanceSceneControl.CatsTaken += 1;
                            SceneControl.InstanceSceneControl.DialogSelesai(); 
                            // if (SceneControl.InstanceSceneControl.CatsTaken == 3)
                            //     {
                            //         CatsAroundHouse.SetActive(true);
                                    
                                    
                            //     }
                            // Debug.Log("udah berhasil di tambah 1 sekarang ada "+ SceneControl.InstanceSceneControl.CatsTaken);
                            break;                            
                        }
                }
                
            }

        }

    }

    

    public void KameraTurunPasDialog()
    {
        
        LeanTween.cancel(cinemachineCamera.gameObject);
        LeanTween.value(cinemachineCamera.gameObject, cinemachineCamera.Lens.OrthographicSize, 3f, 1f)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnUpdate((float val) =>
            {
                cinemachineCamera.Lens.OrthographicSize = val;
            });
        // Debug.Log("kok sampe sini");
    }
    

    public void KameraNaikSelesaiDialog()
    {
        
        // Debug.Log("harusnya ga sampe sini dlu");
        LeanTween.cancel(cinemachineCamera.gameObject);
        LeanTween.value(cinemachineCamera.gameObject, cinemachineCamera.Lens.OrthographicSize, 4f, 1f)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnUpdate((float val) =>
            {
                cinemachineCamera.Lens.OrthographicSize = val;
            });
        
    }
    public void sumurOff()
    {
        SumurTrigger.SetActive(false);
        CanvasSumurGroup.SetActive(false);
        pActionRef.action.Disable();
        qActionRef.action.Disable();
        moveSpeed = 5;
    }

    public void CariChestOn()
    {
        mActionRef.action.Enable();
    }

    public void CariChestOff()
    {
        mActionRef.action.Disable();
    }

    public void sumurOn()
    {
        SumurTrigger.SetActive(true);
        CanvasSumurGroup.SetActive(true);
        pActionRef.action.Enable();
        qActionRef.action.Enable();
        moveSpeed = 5;
    }


    public void PSumurInteraction(InputAction.CallbackContext context)
    {
        // p pressed
        if (context.performed && SumurGroupIM.alpha > 0 && SceneControl.InstanceSceneControl.EmberTaken <= 5)
        {
            moveSpeed -= 0.2f;
        //    SceneControl.InstanceSceneControl.EmberTaken +=1;
            SceneControl.InstanceSceneControl.DialogSelesai();
        }        
    } 
    // tambah variabel ember

    public void QSumurInteraction(InputAction.CallbackContext context)
    {
        // q pressed
        if (context.performed && SumurGroupIM.alpha > 0 && SceneControl.InstanceSceneControl.EmberTaken >= 0)
        {
           moveSpeed += 0.5f;
           SceneControl.InstanceSceneControl.EmberTaken -=1;
           SceneControl.InstanceSceneControl.DialogSelesai(false);
        }        
    }


    // untuk post buat data baru, interact pake z aja
    public void ZMail(InputAction.CallbackContext context)
    {
        // z pressed
        if (context.performed && !dialogRunner.IsDialogueRunning)
        {
            switch (SceneControl.InstanceSceneControl.actNow)
            {
                case (15) :
                    _ = dialogRunner.StartDialogue("Act2_1");
                    break;

                case (24) :
                    _ = dialogRunner.StartDialogue("Act4_2");
                    break;
                

                default :
                    // Debug.Log("masuk def");
                    GantiPeringatan.text = "Tidak ada surat yang ada saat ini";
                    StartCoroutine(SceneControl.InstanceSceneControl.Objektif());
                    break;

            }

            // dialogRunner.StartDialogue(QuestData.GetQuestDenganId(Sc));
        }        
    }

        public void KPatung(InputAction.CallbackContext context)
    {
        // k pressed
        if (context.performed && SceneControl.InstanceSceneControl.actNow == 63 && PatungGroup.alpha > 0)
        {
            SceneControl.InstanceSceneControl.DialogSelesai();
            PatungGroup.alpha = 0;
        }        
    }


    public void YNgomongSendiri (InputAction.CallbackContext context)
    {
        // z pressed
        if (context.performed && !dialogRunner.IsDialogueRunning)
        {
            switch (SceneControl.InstanceSceneControl.actNow)
            {
                case (22) :
                    _ = dialogRunner.StartDialogue("Act4_0");
                    break;
                case (26) :
                    _ = dialogRunner.StartDialogue("Act5_0");
                    break;
                case (50) :
                    _ = dialogRunner.StartDialogue("Act5_4");
                    break;
                case (55) :
                    _ = dialogRunner.StartDialogue("Act6_2");
                    break;
                case (64) :
                    _ = dialogRunner.StartDialogue("Act6_3");
                    break;
                case (69) :
                    _ = dialogRunner.StartDialogue("Act6_3");
                    break;
                

                default :
                    // Debug.Log("masuk def");
                    GantiPeringatan.text = "Tidak ada yang perlu di diskusikan saat ini";
                    StartCoroutine(SceneControl.InstanceSceneControl.Objektif());
                    break;

            }

            // dialogRunner.StartDialogue(QuestData.GetQuestDenganId(Sc));
        }        
    }


    public void LahanOff()
    {
        // SumurTrigger.SetActive(false);
        LahanGroup.gameObject.SetActive(false);
        bActionRef.action.Disable();
        // qActionRef.action.Disable();
        moveSpeed = 5;
    }

    public void LahanOn()
    {
        // SumurTrigger.SetActive(true);
        LahanGroup.gameObject.SetActive(true);
        bActionRef.action.Enable();
        moveSpeed = 5;
    }

    public void BLahanInteraction(InputAction.CallbackContext context)
    {
        // Jika tombol B ditekan
        if (context.performed)
        {
            // Cek semua collider yang bersentuhan dengan Trigger Player
            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(RayaColliderTrigger.bounds.center, RayaColliderTrigger.bounds.size, 0f);

            foreach (Collider2D hit in hitColliders)
            {
                // Ambil script Lahan dari object yang terkena trigger
                Lahan lahan = hit.GetComponent<Lahan>();

                // Jika object tersebut adalah Lahan DAN belum disiram
                if (lahan != null && !lahan.udahDisiram)
                {
                    // 1. Panggil fungsi di Script Lahan untuk mengubah bool-nya
                    lahan.SiramLahan();

                    // 2. Tambahkan progress/data di Player
                    SceneControl.InstanceSceneControl.WaterTakenForLahan -= 1;
                    SceneControl.InstanceSceneControl.DialogSelesai();
                    
                    break; // Keluar dari loop setelah ketemu 1 lahan
                }
            }
        }        
    }    


    public void MChestInteraction(InputAction.CallbackContext context)
    {
        // Jika tombol m ditekan
        if (context.performed)
        {
            // Cek semua collider yang bersentuhan dengan Trigger Player
            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(RayaColliderTrigger.bounds.center, RayaColliderTrigger.bounds.size, 0f);

            foreach (Collider2D hit in hitColliders)
            {
                // Ambil script Lahan dari object yang terkena trigger
                Chest chest = hit.GetComponent<Chest>();

                // Jika object tersebut adalah Lahan DAN belum disiram
                if (chest != null && !chest.udahDiambil)
                {
                    // 1. Panggil fungsi di Script Lahan untuk mengubah bool-nya
                    chest.DestroyChest();
                    SceneControl.InstanceSceneControl.DialogSelesai();
                    
                    break; // Keluar dari loop setelah ketemu 1 lahan
                }
            }
        }        
    }          

}