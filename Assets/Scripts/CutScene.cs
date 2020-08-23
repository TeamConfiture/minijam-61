using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutScene : MonoBehaviour
{
    public string NextScene = "Hub";

    // Start is called before the first frame update
    void Awake()
    {
        VideoPlayer vp = GetComponent<VideoPlayer>();
        vp.loopPointReached += EndReached;
    }

    private void Start()
    {
        GameManager.Instance.GetComponent<AudioSource>().mute = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            EndReached(null);
    }

    void EndReached(VideoPlayer vp)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(NextScene);
        GameManager.Instance.GetComponent<AudioSource>().mute = false;
    }
}
