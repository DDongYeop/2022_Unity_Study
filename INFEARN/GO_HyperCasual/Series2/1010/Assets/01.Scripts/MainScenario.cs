using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainScenario : MonoBehaviour
{
	[SerializeField]
	private	TextMeshProUGUI	textHighScore;

	private void Awake()
	{
		// ����Ǿ� �ִ� �ְ� ���� �����͸� �ҷ��ͼ� ���
		textHighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
	}

	public void BtnClickGameStart()
	{
		SceneManager.LoadScene("02Game");
	}

	public void BtnClickGameExit()
	{
		#if UNITY_EDITOR
		//UnityEditor.EditorApplication.isPlaying = false;
		UnityEditor.EditorApplication.ExitPlaymode();
		#else
		Application.Quit();
		#endif
	}
}
