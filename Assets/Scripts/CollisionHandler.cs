using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    float waitTime = 1f;
    [SerializeField] AudioClip sucsses;
    [SerializeField] AudioClip fail;

    Movement mv;
    AudioSource audioSource;

    bool isTransition;

     void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        isTransition = false;
    }

   void OnCollisionEnter(Collision other) {

    if(!isTransition){
    switch (other.gameObject.tag) {
    case "Friendly":
        Debug.Log("Friendly");
        break; 
    case "Feul":
        Debug.Log("Feul");
        break;
    case "Finish":
       StartNextLevel();
        break;
    default:
       StartCrash();
        break;
    }
    }
   }

   void StartCrash() {
   isTransition = true;
   audioSource.Stop();
   audioSource.PlayOneShot(fail,1f);
   mv = GetComponent<Movement>();
   mv.enabled = false;
   Invoke("ReloadLevel", waitTime);
   }

   void StartNextLevel() {
   isTransition = true;
   audioSource.Stop();
   audioSource.PlayOneShot(sucsses,1f);
   mv = GetComponent<Movement>();
   mv.enabled = false;
   Invoke("ReloadNextLevel", waitTime);
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
