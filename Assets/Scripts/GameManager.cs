using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject InfoCanvas;
    public GameObject InfoCanvasPos;
    public GameObject Player;
    public GameObject Player2;
    public GameObject UIButton1;
    public Color color1;
    public Color color2;
    public CameraPointer pointer;
    private bool IsLocker = false;
    public Animator lockerani;
    public GameObject Key1;
    public GameObject EndObject;
    public int PlayerIdx = 0;
    public string TextString;
    public TextMeshProUGUI Text1;
    public GameObject Key1Image;
    public bool IsKey=false;
    public bool IsLock=false;
    public GameObject[] MoveOb;

    public List<string> GameTexts;
    private void Awake()
    {
        instance = this;
    }
    public void TextSet(int i)
    {
        TextString = GameTexts[i];
    }
    public void InfoCanvasShow(int idx = 0)
    {
        PlayerIdx = idx;
        UIButton1.GetComponent<Image>().color = color1;
        Text1.text = TextString;
        InfoCanvas.SetActive(true);
        InfoCanvas.transform.SetPositionAndRotation(InfoCanvasPos.transform.position, InfoCanvasPos.transform.rotation);
    }   
    public void InfoCanvasNo()
    {
        InfoCanvas.SetActive(false);

        switch (PlayerIdx)
        {
            case 1:
                Destroy(Key1);
                Key1Image.SetActive(true);
                IsKey = true;
                break;
            case 2:
                Destroy(EndObject);
                IsLock = true;
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;
        }
    }

    public void LockerFunc()
    {
        if (IsKey)
        {
            Key1Image.SetActive(false);
            EndObject.SetActive(true);
            if (IsLocker)
            {
                lockerani.Play("LockerClose");
                IsLocker = false;
            }
            else
            {
                lockerani.Play("LockerOpen");
                IsLocker = true;

            }
        }
        else
        {
            TextSet(4);
            InfoCanvasShow();
        }

    }
    public void DoorFunc()
    {
        if (IsLock)
        {
            SceneManager.LoadScene("03_End");
        }
        else
        {
            TextSet(3);
            InfoCanvasShow();
        }
    }

}
