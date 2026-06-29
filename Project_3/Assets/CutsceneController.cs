
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneController : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject player;
    public MonoBehaviour playerController;
    public Cinemachine.CinemachineBrain brain;

    private bool cutsceneActive = true;

    void Start()
    {
        // Disable player control during cutscene
        playerController.enabled = false;

        director.Play();
    }

    void Update()
    {
        if (cutsceneActive && Input.GetKeyDown(KeyCode.Escape))
        {
            SkipCutscene();
        }
    }

    public void SkipCutscene()
    {
        if (!cutsceneActive) return;

        director.Stop();
        EndCutscene();
    }

    // Called at end of timeline via Signal OR PlayableDirector event
    public void EndCutscene()
    {
        cutsceneActive = false;

        // Switch to gameplay camera automatically
        // (Timeline should already activate CM_PlayerCam last)

        playerController.enabled = true;
    }
}

