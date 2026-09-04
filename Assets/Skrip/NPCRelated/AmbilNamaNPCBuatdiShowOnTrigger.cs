using TMPro;
using UnityEngine;
using Yarn.Unity;

public class AmbilNamaNPCBuatdiShowOnTrigger : MonoBehaviour
{

    private bool SudahKenal = false;
    [SerializeField] private TMP_Text teksNama;
    [SerializeField] private GameObject KotakNama;
    // [SerializeField] private DialogueRunner dialogRunner;
    // [SerializeField] private DialogueRunner dialogRunner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        KotakNama.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void KeluarinNama()
    {
        KotakNama.SetActive(true);
        if (SudahKenal == true)
            teksNama.text =  transform.parent.name;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            KeluarinNama();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        KotakNama.SetActive(false);
    }


    private void MasukDialog()
    {
        
    }
}
