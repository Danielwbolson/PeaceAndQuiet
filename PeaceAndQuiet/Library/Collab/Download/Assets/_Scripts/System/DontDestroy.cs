using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {


	public static DontDestroy instance = null;

	public void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);

		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy(gameObject);
		}
	}
}
