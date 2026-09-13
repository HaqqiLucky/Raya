using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class RayaInputManagement : MonoBehaviour
{
    [Header("Masalah UI")]
    [SerializeField] private GameObject UIObjektif;
    [SerializeField] private CanvasGroup KotakNamaCanvas;
    [SerializeField] private CinemachineCamera cinemachineCamera;
    [SerializeField] private TMP_Text teksObjektif;
    [SerializeField] private TMP_Text teksKotakNama;
    [SerializeField] private GameObject CatsAroundHouse;
    [SerializeField] private CanvasGroup SumurGroupIM;
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
    // [SerializeField] private DialogueRunner dialogRunner;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RayaColliderTrigger = GetComponentInChildren<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
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

    private IEnumerator Objektif()
    {
        SceneControl.InstanceSceneControl.ShowObjektifDiperbarui();
        Debug.Log("sampe siniqqqq");
        yield return new WaitForSeconds(2f);
        SceneControl.InstanceSceneControl.HideObjektifDiperbarui();
        Debug.Log("sampe tutup");
    }
    public void ActManagement()
    {
        SceneControl.InstanceSceneControl.ShowObjektifDiperbarui();

        teksObjektif.text = QuestData.GetQuestDenganId(SceneControl.InstanceSceneControl.actNow)?.objektif;
        teksKotakNama.text = QuestData.GetQuestDenganId(SceneControl.InstanceSceneControl.actNow)?.idNPC.ToString();

        StartCoroutine(Objektif());
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
        
        playerInput.enabled = true;
        UIObjektif.SetActive(true);

        ActManagement();
        Debug.Log("Sampe sini");

        // semua kondisi mengenai act
        switch (SceneControl.InstanceSceneControl.actNow)
        {
            case (3) :
                SceneControl.InstanceSceneControl.Act3Kucing();
                break;
            case (8): 
                SumurTrigger.SetActive(true);
                break;
            case (13):
                SumurTrigger.SetActive(false);
                CanvasSumurGroup.SetActive(false);
                pActionRef.action.Disable();
                qActionRef.action.Disable();
                break;
        }
    }
    public void MulaiDialog()
    {
        // SceneControl.InstanceSceneControl.HideObjektifDiperbarui();
        playerInput.enabled = false;
        UIObjektif.SetActive(false);
        SceneControl.InstanceSceneControl.HideKotakNama();
        // KameraTurunPasDialog();
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
                            DialogSelesai(); 
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

    public void PSumurInteraction(InputAction.CallbackContext context)
    {
        // p pressed
        if (context.performed && SumurGroupIM.alpha > 0 && SceneControl.InstanceSceneControl.EmberTaken <= 5)
        {
            moveSpeed -= 0.5f;
        //    SceneControl.InstanceSceneControl.EmberTaken +=1;
            DialogSelesai();
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
           DialogSelesai(false);
        }        
    }


    // untuk post buat data baru, interact pake z aja
}