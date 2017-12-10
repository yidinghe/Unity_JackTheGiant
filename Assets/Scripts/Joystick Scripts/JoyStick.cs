using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

	private PlayerJoyStick playerJoyStick;

	void Start ()
	{
		playerJoyStick = GameObject.Find ("Player").GetComponent<PlayerJoyStick> ();
	}

	public void OnPointerUp (PointerEventData data)
	{
		playerJoyStick.StopMoving ();
	}

	public void OnPointerDown (PointerEventData data)
	{
		if (gameObject.name == "Left") {
			playerJoyStick.SetMoveLeft (true);
		} else {
			playerJoyStick.SetMoveLeft (false);
		}
	}
}
