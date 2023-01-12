using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Convery : MonoBehaviour
{
    public PlayerControl player;
    public GameManager gameManager;
    public TextMeshProUGUI text;
    int score = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collect" || other.tag == "Collected")
        {
            Destroy(player.stackList[player.stackList.Count - 1]);
            player.stackList.RemoveAt(player.stackList.Count - 1);
            score += 1;
            text.text = score.ToString();
        }
        else if (other.tag == "Player" && score == 0)
        {
            gameManager.fail();
        }
    }
}
