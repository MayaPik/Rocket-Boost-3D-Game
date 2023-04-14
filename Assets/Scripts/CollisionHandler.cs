using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
   void OnCollisionEnter(Collision other) {
    switch (other.gameObject.tag) {
    case "Friendly":
        Debug.Log("Friendly");
        break; 
    case "Feul":
        Debug.Log("Feul");
        break;
    case "Finish":
       ReloadNextLevel();
        break;
    default:
        ReloadLevel();
        break;
    }
   }
   void ReloadLevel() {
    int currentIndex = SceneManager.GetActiveScene().buildIndex;
   SceneManager.LoadScene(currentIndex);
   }
   void ReloadNextLevel() {
    int nextIndex = SceneManager.GetActiveScene().buildIndex +1;
   SceneManager.LoadScene(nextIndex);
   if (nextIndex == SceneManager.sceneCountInBuildSettings) {
    Debug.Log("game over");
   }
   }
}
