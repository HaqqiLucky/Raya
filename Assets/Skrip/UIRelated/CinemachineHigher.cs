using Unity.Cinemachine;
using UnityEngine;

public class CinemachineHigher : MonoBehaviour
{

    [SerializeField] private CinemachineCamera cinemachineCamera;
    private float targetSekarang;
    private float targetHigh = 6f;
    private float defaultHigh = 4f;
    private BoxCollider2D boxCollider2DPatung;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetSekarang = defaultHigh;
        boxCollider2DPatung = GetComponent<BoxCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            LeanTween.cancel(cinemachineCamera.gameObject);
            LeanTween.value(cinemachineCamera.gameObject, cinemachineCamera.Lens.OrthographicSize, 6f, 1f)
                .setEase(LeanTweenType.easeInOutQuad)
                .setOnUpdate((float val) =>
                {
                    cinemachineCamera.Lens.OrthographicSize = val;
                });
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LeanTween.cancel(cinemachineCamera.gameObject);
            LeanTween.value(cinemachineCamera.gameObject, cinemachineCamera.Lens.OrthographicSize, 4f, 1f)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnUpdate((float val) =>
                {
                    cinemachineCamera.Lens.OrthographicSize = val;
                });
        }
    }
    // Update is called once per frame
    void Update()
    {
        // cinemachineCamera.Lens.OrthographicSize = Mathf.Lerp(cinemachineCamera.Lens.OrthographicSize, targetSekarang, Time.deltaTime * 2f);
    }
}
