using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : UIScreen
{
    [SerializeField] private Button tapToStandby;

    public override void Init()
    {
        tapToStandby.onClick.AddListener(() => GameManager.Instance.UpdateState(GameState.STANDBY));
    }
}
