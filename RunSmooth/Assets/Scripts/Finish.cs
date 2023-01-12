using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    //public Movement movement;
    public PlayerControl player;
    public Animator anim;
    public Vector3 pos;
    public InputControl control;
    public int score = 0;
    public GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collect" || other.tag == "Collected")
        {
            Destroy(other.GetComponent<Movement>());
            //Destroy(player.stackList[player.stackList.Count - 1]);
            //player.stackList.RemoveAt(player.stackList.Count - 1);
            other.transform.parent = null;
            other.transform.position = new Vector3(transform.position.x + 4,
            other.transform.position.y, transform.position.z) + new Vector3(0, 0, 1.2f * score);
            score += 1;
            Debug.Log(score);
        }
        else if (other.tag == "Player")
        {
            Debug.Log("score: " + score);
            control.gameStart = false;
            other.transform.parent = null;
            other.transform.position = new Vector3(other.transform.position.x,
            other.transform.position.y, transform.position.z);
            player.pos();
            player.stop();
            player.set = true;
            anim.SetBool("finish", true);
        }
    }
}
