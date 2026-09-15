using UnityEngine;
using UnityEngine.Splines;

public class Raka_Splines : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.2f;
    [SerializeField] private float t;
    [SerializeField] private SplineContainer splineContainer;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Ambil komponen SpriteRenderer di NPC
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (splineContainer == null) return;

        Spline spline = splineContainer.Spline;
        t += Time.deltaTime * moveSpeed;
        t %= 1f;

        // Update posisi
        Vector3 localSplinePos = spline.EvaluatePosition(t);
        transform.position = splineContainer.transform.TransformPoint(localSplinePos);

        // Cek arah jalan (tangent.x)
        Vector3 tangent = spline.EvaluateTangent(t);
        
        if (spriteRenderer != null)
        {
            // Jika jalan ke kiri (tangent.x negatif), flip sprite
            if (tangent.x < -0.1f)
            {
                spriteRenderer.flipX = true;
            }
            // Jika jalan ke kanan (tangent.x positif), kembalikan sprite
            else if (tangent.x > 0.1f)
            {
                spriteRenderer.flipX = false;
            }
        }
    }
}