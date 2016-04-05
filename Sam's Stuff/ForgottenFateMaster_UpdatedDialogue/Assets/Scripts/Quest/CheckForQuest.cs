using UnityEngine;
using System.Collections;

public class CheckForQuest : MonoBehaviour {

    public GameObject[] _NPCArray;
	public int[] targetIndexArray;
    public GameObject[] list;
    public int counter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
        counter = 0;
        foreach (GameObject item in list)
        {
            if (item.activeInHierarchy == false)
            {
                counter++;
                if (counter == list.Length)
                {
					for(int i = 0; i < _NPCArray.Length; i++)
					{
						_NPCArray[i].GetComponent<TriggerText>().index = targetIndexArray[i];
					}
                }
            }
        }
	}
}
