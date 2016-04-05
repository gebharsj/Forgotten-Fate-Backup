using UnityEngine;
using System.Collections;

public class CompletedQuest : MonoBehaviour {

	public GameObject NPCFinished;
	public int NPCFinishedIndex;
	public GameObject[] NPCDialogue;
	public int[] targetIndexCompleted;
	public GameObject questItem;
	public Transform questItemLocation;
	public GameObject moveNPC;
	public Transform locationNPC;

	// Use this for initialization
	void Start () 
	{
		if (questItem != null) 
		{
			questItem.transform.position = new Vector2 (-1000, -1000);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (NPCFinished.GetComponent<TriggerText>().index == NPCFinishedIndex)
		{
			for(int i = 0; i < NPCDialogue.Length; i++)
			{
				NPCDialogue[i].GetComponent<TriggerText>().index = targetIndexCompleted[i];
			}

			if (questItem != null)
			{
				questItem.transform.position = questItemLocation.position;
			}
			if (moveNPC != null)
			{
				moveNPC.transform.position = locationNPC.position;
			}
			this.gameObject.SetActive(false);
		}
	
	}
}
