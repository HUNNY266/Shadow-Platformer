using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level : MonoBehaviour
{
    [SerializeField] float LoadDelay = 1f;
   void OnTriggerEnter2D(Collider2D other) 
   {
     StartCoroutine(LoadNextLevel());

     
   }
   IEnumerator LoadNextLevel()
   {
      yield return new WaitForSeconds(LoadDelay);
      int CurrentScene = SceneManager.GetActiveScene().buildIndex;
      int nextScene = CurrentScene + 1;
      if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
     SceneManager.LoadScene(nextScene);
   }
}
