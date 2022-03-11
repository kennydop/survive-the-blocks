using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transanim : MonoBehaviour
{
    
    public Animator transition;

  public void start_anim()
    {
        LoadGameScene();
        
    } 

    void LoadGameScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadScene(int levelIndex)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }
}
