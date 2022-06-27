using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageMask : MonoBehaviour
{
    int a = 0;
    private GameObject h;
    public GameObject[] masks;
    public GameObject[] tiks;
    private void Start()
    {
        
        h = GameObject.Find("Heads");
        //Disable masker kecuali masker pertama
        for (int i = 1; i < masks.Length; i++)
        {
            masks[i].SetActive(false);
        }
    }
    private void Update()
    {
        if (masks[a].GetComponent<Mask>().isDragging == false) {
            Debug.Log(masks[a].transform.rotation.eulerAngles.z);
            // poisisi letak masker 1-5
            if (masks[a].transform.rotation.eulerAngles.z < 5 && masks[a].transform.rotation.eulerAngles.z > 1)
            {
            Debug.Log(masks[a].transform.rotation.eulerAngles.z);
            masks[a].GetComponent<Mask>().setRotationSpeed(0f);
            tiks[a].SetActive(true);
            Debug.Log("Mask Fixed");
                //Jika masker yang dikoreksi bukan masker terakhir, masukan if
                if (a != masks.Length - 1)
                {
                //Setelah 1 detik, kami pindah ke kepala di sebelah kanan.
                Invoke("slideHead", 1);
                //Mengaktifkan masker kepala berikutnya.
                masks[a + 1].SetActive(true);
                a += 1;
                }
            //Saat masker terakhir dipakai, masuk ke scene lain
                else
                {
                Debug.Log("Level Completed");
                    SceneController.Instance.AnotherLevel();
                }
                
            
                
            }
        }

    }
    //Metode yang digunakan untuk memindahkan kamera ke wajah berikutnya
    private void slideHead()
    {
        Vector3 v3 = h.transform.position - Vector3.right * 3;
        h.transform.SetPositionAndRotation(v3, Quaternion.identity);

    }
        
        
}
    

