using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool _isPaused;
    public GameObject _pauseText;

    //Using this to have a bool shared between scripts
    public bool _canPause = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _isPaused = false;
        _pauseText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //If there's an way to do this with Input System just change this line
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //_canPause checks if you're in a conversation
            if(_isPaused == false && _canPause == true)
            {
                Time.timeScale = 0f;
                _isPaused = true;
                _pauseText.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                _isPaused = false;
                _pauseText.SetActive(false);
            }
        }
    }
}
