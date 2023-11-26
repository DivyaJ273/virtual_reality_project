using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
Public class SkipScene: MonoBehaviour
{
	void Update()
	{
		if(Input.GetKeyDown(KeyCoe.A))
{
SceneManager.LoadScene(“relax_room”);
}
else if(Input.GetKeyDown(KeyCoe.B))
{
	SceneManager.LoadScene(“rage_room”);
}
	}
}
void ExitGame()
{
	#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying=false;
	#else
		Application.Quit();
	#endif
}
