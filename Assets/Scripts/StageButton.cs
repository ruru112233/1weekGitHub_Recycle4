using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    
    public void TitleScene()
    {
        StartCoroutine(SceneButton(1));
    }

    public void GameScene()
    {
        StartCoroutine(SceneButton(2));
    }

    IEnumerator SceneButton(int num)
    {
        AudioManager.instance.PlaySE(0);

        yield return new WaitForSeconds(0.5f);

        switch (num)
        {
            case 1:
                SceneManager.LoadScene("OpeningScenes");
                break;
            case 2:
                SceneManager.LoadScene("SampleScene");
                break;
        }
    }

}
