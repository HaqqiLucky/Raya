using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.Splines;

public class Haqi_Splines : MonoBehaviour
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

        
        // t += Time.deltaTime * moveSpeed;
        // t %= 1f; ini yg buat looping, karena t itu 1 kalo udah sampe akhir, maka 1 modulo 1 hasilnya 0 makanya balik lagi t nya ke 0

        // Update posisi


        // Cek arah jalan (tangent.x)
        // Vector3 tangent = spline.EvaluateTangent(t);
        if (t >= 0f && SceneControl.InstanceSceneControl.actNow == 52)
        {
            t += Time.deltaTime * moveSpeed;
        }


        Spline spline = splineContainer.Spline;
        Vector3 localSplinePos = spline.EvaluatePosition(t);
        transform.position = splineContainer.transform.TransformPoint(localSplinePos);

        // if (spriteRenderer != null)
        // {
        //     // Jika jalan ke kiri (tangent.x negatif), flip sprite
        //     if (tangent.x < -0.1f)
        //     {
        //         spriteRenderer.flipX = true;
        //     }
        //     // Jika jalan ke kanan (tangent.x positif), kembalikan sprite
        //     else if (tangent.x > 0.1f)
        //     {
        //         spriteRenderer.flipX = false;
        //     }
        // }
    }
}