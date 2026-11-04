using UnityEngine;

public class CreatingAndDestroying : MonoBehaviour
{

    public GameObject UIToSpawn;
    public GameObject canvas;
    [HideInInspector]
    public GameObject spawnedUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnedUI = Instantiate(UIToSpawn);
        spawnedUI.transform.SetParent(canvas.transform, false);
        //assign the manager on spawn
        if(spawnedUI.TryGetComponent<MainMenu>(out MainMenu menu))
        {
            menu.manager = this;
        }

        Destroy(spawnedUI);
    }

    // Update is called once per frame
    void Update()
    {

        spawnedUI.SetActive(true);
    }
}
