using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next_pause : MonoBehaviour
{
    public GameObject panel;

    public void naxtgame()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
    }
}
