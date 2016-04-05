using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game : MonoBehaviour
{
	//don't need ": Monobehaviour" because we are not attaching it to a game object

	public static Game current;
	public Character player;

	public Game () {
		player = new Character();
	}
		
}
