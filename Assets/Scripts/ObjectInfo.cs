using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    public enum GameObjectType
{
    None=0,
    desk,
    table,
    UI_ExitButton,
    UI_PancelOut,
    Move1,
    Move2,
    Move3,
    Locker1,
    Key1,
    Door,
    EndObject,
    desk2,
    chair1,
    chair2,
    bed,

}

public class ObjectInfo : MonoBehaviour
{
    public bool OutLine = false;
    public GameObjectType ObjectType;

    public void OnPointerEnter()
    {
        if (OutLine)
        {
            GetComponent<Outline>().enabled = true;
        }
        switch (ObjectType)
        {
            case GameObjectType.None:
                break;
            case GameObjectType.desk:
                break;
            case GameObjectType.table:
                break;
            case GameObjectType.UI_ExitButton:
                GameManager.instance.UIButton1.GetComponent<Image>().color = GameManager.instance.color2;
                break;
            case GameObjectType.UI_PancelOut:
                GameManager.instance.InfoCanvasNo();
                //GameManager.instance.pointer.ObReset();
                break;
            default:
                break;
        }
    }
    public void OnPointerExit()
    {
        if (OutLine)
        {
            GetComponent<Outline>().enabled = false;
        }
        switch (ObjectType)
        {
            case GameObjectType.None:
                break;
            case GameObjectType.desk:
                break;
            case GameObjectType.table:
                break;
            case GameObjectType.UI_ExitButton:
                GameManager.instance.UIButton1.GetComponent<Image>().color = GameManager.instance.color1;
                break;
            case GameObjectType.UI_PancelOut:
                GameManager.instance.InfoCanvasNo();
                //GameManager.instance.pointer.ObReset();
                break;
            default:
                break;
        }
    }
    public void OnPointerClick()
    {
        
        switch (ObjectType)
        {
            case GameObjectType.None:
                break;
            case GameObjectType.desk:
                GameManager.instance.TextSet(0);
                ObjectClick();
                break;
            case GameObjectType.table:
                GameManager.instance.TextSet(1);
                ObjectClick();
                break;
            case GameObjectType.UI_ExitButton:
                GameManager.instance.InfoCanvasNo();
                break;
            case GameObjectType.Move2:
                GameManager.instance.MoveOb[0].SetActive(true);
                GameManager.instance.MoveOb[1].SetActive(false);
                GameManager.instance.MoveOb[2].SetActive(true);
                GameManager.instance.MoveOb[1].GetComponent<Outline>().enabled = false;
                GameManager.instance.Player2.transform.position=new Vector3(0,1,0);
                break;
            case GameObjectType.Move1:
                GameManager.instance.MoveOb[0].SetActive(false);
                GameManager.instance.MoveOb[1].SetActive(true);
                GameManager.instance.MoveOb[2].SetActive(true);
                GameManager.instance.MoveOb[0].GetComponent<Outline>().enabled = false;
                GameManager.instance.Player2.transform.position=new Vector3(0,1,-3f);
                break;
            case GameObjectType.Move3:
                GameManager.instance.MoveOb[0].SetActive(true);
                GameManager.instance.MoveOb[1].SetActive(true);
                GameManager.instance.MoveOb[2].SetActive(false);
                GameManager.instance.MoveOb[2].GetComponent<Outline>().enabled = false;
                GameManager.instance.Player2.transform.position = new Vector3(0, 1, 2);
                break;
            case GameObjectType.Locker1:
                GameManager.instance.LockerFunc();
                break;
            case GameObjectType.Key1:
                GameManager.instance.TextSet(2);
                ObjectClick(1);

                break;
            case GameObjectType.Door:
                GameManager.instance.DoorFunc();

                break;
            case GameObjectType.EndObject:
                GameManager.instance.TextSet(5);
                ObjectClick(2);

                break;
            case GameObjectType.chair1:
                GameManager.instance.TextSet(9);
                ObjectClick();

                break;
            case GameObjectType.chair2:
                GameManager.instance.TextSet(7);
                ObjectClick();

                break;
            case GameObjectType.desk2:
                GameManager.instance.TextSet(8);
                ObjectClick();

                break;
            case GameObjectType.bed:
                GameManager.instance.TextSet(6);
                ObjectClick();

                break;
            default:
                break;
        }
    }
    public void ObjectClick(int idx = 0)
    {
        GameManager.instance.InfoCanvasShow(idx);
    }
}
