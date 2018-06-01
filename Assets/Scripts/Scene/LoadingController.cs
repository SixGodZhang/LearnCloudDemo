using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour {

    public Scrollbar loadingBar;

    private AsyncOperation aysn;
    private float process = 0.0f;

	void Start ()
    {
        StartCoroutine(LoadingThirdScene(GameScene.GameLobbyScene));
	}

    private IEnumerator LoadingThirdScene(GameScene scene)
    {
        aysn = SceneManager.LoadSceneAsync("Scenes/" + scene);
        aysn.allowSceneActivation = false;

        yield return new WaitForSeconds(2.0f);

        aysn.allowSceneActivation = true;

        yield return aysn;
    }

    void Update ()
    {
        loadingBar.size = 1.25f * (aysn.progress - 0.1f);
    }
}
