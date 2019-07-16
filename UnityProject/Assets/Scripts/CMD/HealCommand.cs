using UnityEngine;
using IngameDebugConsole;

public class TestScript : MonoBehaviour
{
	[ConsoleMethod( "heal", "Set full hp" )]
	public static void Heal(int value = 4)
	{
		Debug.Log("Healing ...");
        GameObject.FindGameObjectWithTag("Life")
            .GetComponent<Animator>()
            .SetInteger("Stage", value);
	}
}