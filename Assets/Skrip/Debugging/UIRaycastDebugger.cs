using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIRaycastDebugger : MonoBehaviour
{
    private GraphicRaycaster raycaster;
    private EventSystem eventSystem;

    void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = EventSystem.current;

        if (raycaster == null)
        {
            Debug.LogError("[UI Debugger] Script ini HARUS dipasang di GameObject yang memiliki komponen Canvas & GraphicRaycaster!");
        }
    }

    void Update()
    {
        // Cek klik/sentuhan menggunakan New Input System
        bool wasPressed = false;
        Vector2 screenPosition = Vector2.zero;

        if (Pointer.current != null)
        {
            wasPressed = Pointer.current.press.wasPressedThisFrame;
            screenPosition = Pointer.current.position.ReadValue();
        }
        else if (Mouse.current != null)
        {
            wasPressed = Mouse.current.leftButton.wasPressedThisFrame;
            screenPosition = Mouse.current.position.ReadValue();
        }

        if (wasPressed)
        {
            DetectUIUnderCursor(screenPosition);
        }
    }

    void DetectUIUnderCursor(Vector2 position)
    {
        if (raycaster == null || eventSystem == null) return;

        PointerEventData pointerData = new PointerEventData(eventSystem)
        {
            position = position
        };

        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(pointerData, results);

        if (results.Count > 0)
        {
            Debug.LogWarning($"<color=yellow>[UI Hit Count]:</color> Ada {results.Count} objek UI di bawah kursor!");

            for (int i = 0; i < results.Count; i++)
            {
                GameObject hitObject = results[i].gameObject;
                string status = (i == 0) ? "👈 INI YANG MENGHALANGI KLIK (Paling Depan)" : "";

                Debug.Log($"[{i + 1}] <color=cyan>{hitObject.name}</color> (Layer: {LayerMask.LayerToName(hitObject.layer)}) {status}", hitObject);
            }
        }
        else
        {
            Debug.Log("<color=green>[UI Debugger]:</color> Tidak ada UI yang tertembak Raycast (Klik tembus ke game/world).");
        }
    }
}