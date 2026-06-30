using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    public PlayableDirector director;
    public PlayerController playerController;

    private bool cutsceneEnded = false;

    void Start()
    {
        playerController.canMove = false;

        director.Play();
        director.stopped += OnCutsceneFinished;
    }

    void Update()
    {
        if (!cutsceneEnded && Input.GetKeyDown(KeyCode.Escape))
        {
            director.Stop();
        }
    }

    void OnCutsceneFinished(PlayableDirector pd)
    {
        if (cutsceneEnded) return;

        cutsceneEnded = true;
        playerController.canMove = true;
    }
}
