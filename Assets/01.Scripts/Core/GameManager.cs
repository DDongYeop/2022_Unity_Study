using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Transform _cannonTrm;


    public Transform CannonTrm
    {
        get { return _cannonTrm; }
    }

    private CanonController _cannonController;

    #region 박스 스코어 관련 코드 
    private int _totalBoxCount = 0, _currentBoxCount = 0;
    #endregion

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Multiple GameManager instance is running");
        }
        Instance = this;

        UIManager.Instance = new UIManager();

        _cannonController = _cannonTrm.GetComponent<CanonController>();

        GameObject timeController = new GameObject("TimeController");
        timeController.transform.parent = transform;
        TimeController.Instance = timeController.AddComponent<TimeController>();

        GameObject cameraManager = new GameObject("CameraManager");
        cameraManager.transform.parent = transform;
        CameraManager.Instance = cameraManager.AddComponent<CameraManager>();
        CameraManager.Instance.Init();

        LoadStage(1);
    }

    public void LoadStage(int idx)
    {
        Stage stagePrefab = Resources.Load<Stage>($"Stage{idx}");
        Stage stage = Instantiate(stagePrefab, Vector3.zero, Quaternion.identity);
        
        CameraManager.Instance.SetConfiner(stage.CamBound);

        _cannonTrm.position = stage.CannonPosition;

        _currentBoxCount = _totalBoxCount = stage.BoxCount;
        stage.Init(() =>
        {
            _currentBoxCount--;
            UIManager.Instance.SetBoxScore(_currentBoxCount, _totalBoxCount);
        });
    }
}
