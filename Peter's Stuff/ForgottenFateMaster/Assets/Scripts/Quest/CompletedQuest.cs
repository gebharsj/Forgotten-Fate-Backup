using UnityEngine;
using System.Collections;

public class CompletedQuest : MonoBehaviour {

    public GameObject NPCFinished;
    public int NPCFinishedIndex;
    public GameObject[] NPCDialogue;
    public int[] targetIndexCompleted;
    public GameObject moveNPC;
    public Transform locationNPC;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (NPCFinished.GetComponent<TriggerText>().index == NPCFinishedIndex)
        {
            for (int i = 0; i < NPCDialogue.Length; i++)
            {
                NPCDialogue[i].GetComponent<TriggerText>().index = targetIndexCompleted[i];
            }

            if (moveNPC != null)
            {
                moveNPC.transform.position = locationNPC.position;
            }
            this.gameObject.SetActive(false);
        }

    }
}