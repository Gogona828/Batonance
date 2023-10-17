using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RankingManager rankingManager;

    void EndGame(int retryCount, float realTime)
    {
        PlayerData newPlayerData = new PlayerData();
        newPlayerData.retryCount = retryCount;
        newPlayerData.realTime = realTime;

        rankingManager.AddToRanking(newPlayerData);
    }
}
