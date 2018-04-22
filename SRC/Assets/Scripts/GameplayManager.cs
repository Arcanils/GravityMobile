using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour {

	public GameObject PrefabPlayer;
	public Cinemachine.CinemachineVirtualCamera Cam;


	private Transform _startAnchor;
	private GameObject _player;

	public IEnumerator Start()
	{
		yield return InitGameplay();
		RespawnPlayer();
	}

	public IEnumerator InitGameplay()
	{
		SceneManager.LoadScene(UIMain.GlobalParamSet + 2, LoadSceneMode.Additive);
		yield return null;
		var triggers = FindObjectsOfType<Trigger>();
		var start = triggers.FirstOrDefault(item => item.Type == Trigger.ETriggerType.START);

		if (start == null)
		{
			Debug.LogError("No start");
			yield break;
		}
		_startAnchor = start.transform;

		var end = triggers.FirstOrDefault(item => item.Type == Trigger.ETriggerType.END);

		if (end == null)
		{
			Debug.LogError("No end");
			yield break;
		}

		end.OnTriggerEnter += FinishGame;
	}

	public void RespawnPlayer()
	{
		SpawnPlayer();
	}
	

	public void FinishGame()
	{
		SceneManager.LoadScene(0, LoadSceneMode.Single);
	}

	public void PauseGame()
	{

	}

	public void ResumeGame()
	{

	}

	private void LoadLevel()
	{

	}
	
	private void SpawnPlayer()
	{
		_player = Object.Instantiate<GameObject>(PrefabPlayer, _startAnchor.position, Quaternion.identity);
		_player.GetComponent<PlayerPawn>().OnDeath += RespawnPlayer;
		Cam.Follow = _player.transform;
	}
}
