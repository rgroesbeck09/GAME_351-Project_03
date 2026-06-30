using UnityEngine;
using UnityEngine.Playables;


public class CutsceneManager : MonoBehaviour
{
    public PlayableDirector director;
    public PlayerController playerController;


    private bool cutsceneEnded = false;


    void Start()
    {  
        director.stopped += OnCutsceneFinished;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            director.Stop();
        }
    }


    public void startCutscene()
    {
        playerController.canMove = false;
        director.Play();
    }




    public void OnCutsceneFinished(PlayableDirector pd)
    {
        playerController.canMove = true;
    }
}
