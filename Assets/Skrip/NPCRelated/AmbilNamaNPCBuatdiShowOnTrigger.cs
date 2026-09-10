using System;
using TMPro;
using UnityEngine;
using Yarn.Unity;

public class AmbilNamaNPCBuatdiShowOnTrigger : MonoBehaviour
{

    private string teksNamaAsliBuatCompare;
    private bool SudahKenal = false;
    [SerializeField] private TMP_Text teksNama;
    [SerializeField] private TMP_Text namaAsliGO;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        teksNamaAsliBuatCompare = transform.parent.name;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void KeluarinNama()
    {
        SceneControl.InstanceSceneControl.ShowKotakNama();
        if (SudahKenal == true)
            teksNama.text =  transform.parent.name;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && teksNamaAsliBuatCompare.Contains(QuestData.GetQuestDenganId(SceneControl.InstanceSceneControl.actNow)?.idNPC.ToString()))
        {
            KeluarinNama();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SceneControl.InstanceSceneControl.HideKotakNama();
    }

    public void DestroyThisNPC()
    {
        Destroy(transform.parent);
    }


}
