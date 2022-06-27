using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; set; }
    int sceneToLoad=1;
    int tempScene;
    public Slider timer;
    public float time;
    public GameObject frame;
    public GameObject endPanel;
    public Transform startPanel;
    private bool waitForSpace = false;

    private void Awake()
    {
        Time.timeScale = 1;
        Instance = this;
        sceneToLoad = SceneManager.GetActiveScene().buildIndex;
        timer.maxValue = time;
       
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !waitForSpace)
        {
            waitForSpace = true;
            startPanel.gameObject.SetActive(false);
        }

        if (!waitForSpace) return;

        timer.value += Time.deltaTime;
        if (timer.value == timer.maxValue)
        {
            frame.SetActive(true);
            
        }
        if (frame.activeSelf)
        {
            Time.timeScale = 0;
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

   
    public void AnotherLevel()
    {
        endPanel.SetActive(true);
        timer.value = 0;
        //2 saniye sonra sahne değiştir
        Invoke(nameof(toAnotherLevel), 2);
        
    }
    public void toAnotherLevel()
    {
        //tempScene = Random.Range(1, 5);

       // while (tempScene == sceneToLoad)
       // {
       //     tempScene = Random.Range(1, 5);
       // }
       // sceneToLoad = tempScene;
       // SceneManager.LoadScene(sceneToLoad);
        SceneManager.LoadScene("Dragmasker");
    }

}
