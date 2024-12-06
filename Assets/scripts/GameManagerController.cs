using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{
     private GameData gData;
    private GameDataRepository gDataRepository;
    private TMP_Text bulletText;

    void Start()
    {
        gDataRepository = new GameDataRepository();
        gData = gDataRepository.LoadGame();

        bulletText = GameObject.Find("NumBullets").GetComponent<TextMeshProUGUI>();
    }

    public void ReduceBullets()
    {
        gData.NumBullets--;
        gDataRepository.SaveGame(gData);
    }
    public void RemoveLife()
    {
        gData.Life-=10;
        gDataRepository.SaveGame(gData);

        if(gData.Life<=0){
            // Destroy(play);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
            gData.Life=10;
            gData.NumBullets=5;
            gDataRepository.SaveGame(gData);
        }
    }
    public int getBullets()
    {
        return gData.NumBullets;
    }
    public int getLife()
    {
        return gData.Life;
    }
    
    void Update()
    {
        bulletText.text="Numero balas: "+gData.NumBullets;
    }
}
