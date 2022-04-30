using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobyButton : MonoBehaviour
{
    public void OnPointerClick()
    {
        SceneManager.LoadScene("02_Main");
    }
}
