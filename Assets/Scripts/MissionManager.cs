using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionManager : Singleton<MissionManager>
{
    public GameFlow gameFlow;
    public int requiredKill;
    public TMP_Text missionText;

    private int currentKill;

    private void Start()
    {
        StartCoroutine(VerifyMissions());
    }

    private IEnumerator VerifyMissions()
    {
        yield return VerifyZombieKill();
        gameFlow.OnMissionCompleted();
    }

    private IEnumerator VerifyZombieKill()
    {
        currentKill = 0;
        missionText.text = $"Kill {requiredKill} zombies";
        yield return new WaitUntil(() => currentKill >= requiredKill);
    }

    public void OnZombieKilled(GameObject zombie)
    {
        currentKill++;
        //missionText.text = $"Kill {requiredKill - currentKill} zombies";
        Debug.Log($"OnZombieKilled: {currentKill}");
    }
}
