using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MockUpUser
    {
        public int id;
        public string name;
        public int cosmeticsTotal;
        public Color color;
        public string tombStoneMessage;
        public int tomStoneScore;
        public int highscore;
        public int coinCount;
        public bool hasBattlePass;
    }
public class TheHutOfTheWitch : MonoBehaviour
{
    public static MockUpUser[] Users 
    {
        get
        {
            if (backingUsers == null)
            {
                backingUsers = CreateUsers();
            }
            return backingUsers;
        }
    }
    private static MockUpUser[] backingUsers = null;
    private static MockUpUser[] CreateUsers()
    {
        string[] names = new string[] {
            "Franklin", "Kermit", "KrazyFrog", "Froggo", "Amphibius",
            "Croagunk", "Toxicroak", "Greninja", "Froakie", "HypnoToad",
            "Pepe", "FrogoBaggins", "Jiraya", "Jim", "Dwight",
            "FrankReynolds", "Legs", "Rune", "TahmKench", "Aogaeru",
            "Jumpy", "Rana", "Frosk", "FrogLee", "Kikker",
            "Beka", "Frosch", "Vatraxos"};
        MockUpUser[] users = new MockUpUser[names.Length];

        var random = new System.Random();

        for (int i = 0; i < names.Length; ++i)
        {
            MockUpUser user;

            user.id = i;
            user.name = names[i];
            user.cosmeticsTotal = (int)Mathf.Sqrt(random.Next(0, 6));
            user.tombStoneMessage = "if you see this pretend its really funny and laugh out loud";
            user.tomStoneScore = (int)Mathf.Sqrt(random.Next(0, 45));
            user.highscore = 0;
            while (user.highscore < user.tomStoneScore) user.highscore = (int)Mathf.Sqrt(random.Next(0, 46));
            user.coinCount = (int)Mathf.Sqrt(random.Next(0, 222));
            user.hasBattlePass = random.Next(0, 10) == 0;
            user.color = new Color((float)random.NextDouble() * 1.5f, (float)random.NextDouble() * 1.5f, (float)random.NextDouble() * 1.5f);

            users[i] = user;
        }

        return users;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
