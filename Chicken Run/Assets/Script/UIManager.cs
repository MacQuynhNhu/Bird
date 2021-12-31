using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Text TextScore;
    public GameObject Gameover;
     public void SetTextScore(string txt)
    {
        TextScore.text = txt;
    }

    public void SetGameoverState(bool state)
    {
        Gameover.SetActive(state);
    }
}
