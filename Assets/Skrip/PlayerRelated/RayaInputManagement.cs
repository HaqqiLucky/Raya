using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayaInputManagement : MonoBehaviour
{
    [Header("Masalah UI")]
    [SerializeField] private GameObject UIObjektif;
    [SerializeField] private GameObject KotakNama;
    [SerializeField] private CinemachineCamera cinemachineCamera;
    private PlayerInput playerInput;

    [Header("Masalah Player")]
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

    public void DialogSelesai()
    {
        playerInput.enabled = true;
        UIObjektif.SetActive(true);
        // KameraNaikSelesaiDialog();
    }
    public void MulaiDialog()
    {
        playerInput.enabled = false;
        UIObjektif.SetActive(false);
        // KameraTurunPasDialog();
    }

    public void InteractionWithNPC(InputAction.CallbackContext context)
    {
        // Debug.Log("hdfwf");
        if (context.performed && KotakNama.activeSelf)
        {
            Debug.Log("hai");
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
}
