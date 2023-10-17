using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RankingUI : MonoBehaviour
{
    public RankingManager rankingManager;
    public TextMeshProUGUI rankingText;

    void Start()
    {
        UpdateRankingUI();
    }

    void UpdateRankingUI()
    {
        string rankingString = "Ranking:\n";
        int rank = 1;

        foreach (PlayerData player in rankingManager.rankingData)
        {
            rankingString += $"{rank}. Retry Count: {player.retryCount}, Real Time: {player.realTime}\n";
            rank++;
        }

        rankingText.text = rankingString;
    }
}
