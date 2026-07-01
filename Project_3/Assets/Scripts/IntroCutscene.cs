using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class IntroCutscene : MonoBehaviour
{
    [Header("Cutscene")]
    public PlayableDirector director;

    [Header("Player Control")]
    public MonoBehaviour playerMovementScript;

    [Header("Cameras")]
    public GameObject cutsceneCamerasParent;
    public GameObject playerCamera;

    private bool cutsceneFinished = false;

    private void Start()
    {
        StartCutscene();
    }

    private void Update()
    {
        if (!cutsceneFinished && Input.GetKeyDown(KeyCode.Escape))
        {
            EndCutscene();
        }
    }

    private void StartCutscene()
    {
        cutsceneFinished = false;

        if (playerMovementScript != null)
            playerMovementScript.enabled = false;

        if (playerCamera != null)
            playerCamera.SetActive(false);

        if (cutsceneCamerasParent != null)
            cutsceneCamerasParent.SetActive(true);

        director.stopped += OnCutsceneStopped;
        director.Play();
    }

    private void OnCutsceneStopped(PlayableDirector playableDirector)
    {
        EndCutscene();
    }

    private void EndCutscene()
    {
        if (cutsceneFinished) return;

        cutsceneFinished = true;

        director.stopped -= OnCutsceneStopped;
        director.Stop();

        if (cutsceneCamerasParent != null)
            cutsceneCamerasParent.SetActive(false);

        if (playerCamera != null)
            playerCamera.SetActive(true);

        if (playerMovementScript != null)
            playerMovementScript.enabled = true;
    }
}
