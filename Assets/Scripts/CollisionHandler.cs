using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    float waitTime = 1f;
    [SerializeField] AudioClip sucsses;
    [SerializeField] AudioClip fail;
    [SerializeField] ParticleSystem sucssesAnimation;
    [SerializeField] ParticleSystem failAnimation;

    Movement mv;
    AudioSource audioSource;
    bool isTransition;
    bool isCollisionDisabled;

     void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        isTransition = false;
        isCollisionDisabled = false;
    }

    void Update() 
    {
        RespondToDebugKeys();
        CheckIfPlayerAround();
    }

    void RespondToDebugKeys() {
        if (Input.GetKeyDown(KeyCode.L)) {
        StartNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C)) {
            isCollisionDisabled = !isCollisionDisabled;
        }
    }

  void CheckIfPlayerAround()
  {

    float playerX = transform.position.x;
    float gameAreaX = GameObject.FindGameObjectWithTag("GameArea").transform.position.x;
    float gameAreaWidth = GameObject.FindGameObjectWithTag("GameArea").transform.localScale.x;
    if (playerX < gameAreaX - gameAreaWidth / 2 || playerX > gameAreaX + gameAreaWidth / 2)
    {
        ReloadLevel();
    }
  }
   void OnCollisionEnter(Collision other) {

    if(isTransition || isCollisionDisabled){ return; }
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

   void StartCrash() {
   isTransition = true;
   sucssesAnimation.Play();
   audioSource.Stop();
   audioSource.PlayOneShot(fail,1f);
   mv = GetComponent<Movement>();
   mv.enabled = false;
   Invoke("ReloadLevel", waitTime);
   }

   void StartNextLevel() {
   isTransition = true;
   failAnimation.Play();
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
   if (nextIndex == SceneManager.sceneCountInBuildSettings) {
    SceneManager.LoadScene(0);
   } else {
    SceneManager.LoadScene(nextIndex);
   }
   }
}
