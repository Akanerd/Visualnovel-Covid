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
        //İlk maske dışındaki maskeleri etkisiz hale getiriyoruz.
        for(int i = 1; i < masks.Length; i++)
        {
            masks[i].SetActive(false);
        }
    }
    private void Update()
    {
        if (masks[a].GetComponent<Mask>().isDragging == false) {
            Debug.Log(masks[a].transform.rotation.eulerAngles.z);
            //1 - 5 arası maske için ideal pozisyon
            if (masks[a].transform.rotation.eulerAngles.z < 5 && masks[a].transform.rotation.eulerAngles.z > 1)
            {
            Debug.Log(masks[a].transform.rotation.eulerAngles.z);
            masks[a].GetComponent<Mask>().setRotationSpeed(0f);
            tiks[a].SetActive(true);
            Debug.Log("Maske düzeltildi.");
            //Düzeltilen maske son maske değilse if içine giriyoruz.
                if (a != masks.Length - 1)
                {
                //1 saniyenin ardından sağdaki kafaya geçiyoruz.
                Invoke("slideHead", 1);
                //Bir sonraki kafanın maskesini aktifleştiriyoruz.
                masks[a + 1].SetActive(true);
                a += 1;
                }
            //Son maske takılınca else içine giriyoruz
                else
                {
                Debug.Log("Level Completed");
                    SceneController.Instance.AnotherLevel();
                }
                
            
                
            }
        }

    }
    //Kamerayı bir sonraki yüze çevirmek için kullanılan method
    private void slideHead()
    {
        Vector3 v3 = h.transform.position - Vector3.right * 3;
        h.transform.SetPositionAndRotation(v3, Quaternion.identity);

    }
        
        
}
    

