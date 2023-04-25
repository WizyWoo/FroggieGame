using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Leaderboard : MonoBehaviour
{
    public GameObject leaderboardEntryPrefab;
    public List<GameObject> leaderboardEntries = new List<GameObject>();

    public void OpenLeaderboard()
    {
        foreach (GameObject g in leaderboardEntries) Destroy(g);
        leaderboardEntries.Clear();
        
        MockUpUser[] users = TheHutOfTheWitch.Users;

        users = users.OrderBy(x => x.highscore).Reverse().ToArray();

        for (int i = 0; i < 10; ++i)
        {
            GameObject entry = Instantiate(leaderboardEntryPrefab, transform);
            LeaderboardEntry entryScript = entry.GetComponent<LeaderboardEntry>();
            entryScript.name.text = users[i].name;
            entryScript.score.text = users[i].highscore.ToString();
            entryScript.frog.color = users[i].color;

            entry.transform.Translate(new Vector3(0, -22 * i, 0));

            leaderboardEntries.Add(entry);
        }

        gameObject.SetActive(true);
    }
    public void CloseLeaderboard()
    {
        gameObject.SetActive(false);
    }
}
