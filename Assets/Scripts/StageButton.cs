using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    
    public void TitleScene()
    {
        SceneManager.LoadScene("OpeningScenes");
    }

    public void GameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
