using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExpSystemPlayer : MonoBehaviour {

	[HideInInspector]
	public float exp;
	[HideInInspector]
	public int playerLevel = 1;
	[HideInInspector]
	public float maxExp = 0f;

	public GameObject _player;
	public GameObject CBTPrefab;

	[HideInInspector]
	public bool	levelUp;
	
	// Use this for initialization
	void Start () 
	{
		maxExp = 100 * playerLevel;
	}
	
	// Update is called once per frame
	void Update () 
	{
		maxExp = 100 * playerLevel;

		if (levelUp)
		{
			InitCBT("LEVEL UP").GetComponent<Animator>().SetTrigger("LevelUp");
			levelUp = false;
		}
	}

	GameObject InitCBT(string text)
	{
		GameObject temp = Instantiate(CBTPrefab) as GameObject;
		RectTransform tempRect = temp.GetComponent<RectTransform>();
		temp.transform.SetParent(transform.FindChild("PlayerCanvas"));
		tempRect.transform.localPosition = CBTPrefab.transform.localPosition;
		tempRect.transform.localScale = CBTPrefab.transform.localScale;
		tempRect.transform.localRotation = CBTPrefab.transform.localRotation;
		
		  Debug.Log("LEVEL UP");
		
		temp.GetComponent<Text>().text = text;
		Destroy(temp.gameObject, 3);
		//temp.GetComponent<Animator>().SetTrigger("Hit");
		return temp;
	}
}
