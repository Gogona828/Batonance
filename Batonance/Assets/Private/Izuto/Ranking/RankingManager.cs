using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RankingManager : MonoBehaviour
{
    public int maxRankingEntries = 10;
    public List<PlayerData> rankingData = new List<PlayerData>(); // ランキングデータを保持するリスト

    // ランキングデータをPlayerPrefsからロード
    public List<PlayerData> LoadRankingData()
    {
        List<PlayerData> rankingData = new List<PlayerData>();
        for (int i = 0; i < maxRankingEntries; i++)
        {
            string key = "RankingEntry" + i;
            if (PlayerPrefs.HasKey(key))
            {
                PlayerData playerData = new PlayerData();
                playerData.retryCount = PlayerPrefs.GetInt(key + "RetryCount");
                playerData.realTime = PlayerPrefs.GetFloat(key + "RealTime");
                rankingData.Add(playerData);
            }
        }
        return rankingData.OrderBy(player => player.retryCount).ToList();
    }

    // ランキングデータをPlayerPrefsに保存
    public void SaveRankingData(List<PlayerData> rankingData)
    {
        for (int i = 0; i < rankingData.Count; i++)
        {
            string key = "RankingEntry" + i;
            PlayerPrefs.SetInt(key + "RetryCount", rankingData[i].retryCount);
            PlayerPrefs.SetFloat(key + "RealTime", rankingData[i].realTime);
        }
        PlayerPrefs.Save();
    }

    public void AddToRanking(PlayerData newData)
    {
        List<PlayerData> rankingData = LoadRankingData();
        rankingData.Add(newData);
        rankingData = rankingData.OrderBy(player => player.retryCount).ToList();

        if (rankingData.Count > maxRankingEntries)
        {
            rankingData.RemoveAt(rankingData.Count - 1);
        }

        SaveRankingData(rankingData);
    }
}
