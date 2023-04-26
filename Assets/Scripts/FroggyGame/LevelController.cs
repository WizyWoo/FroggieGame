using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public int DistanceMoved
    {
        get { return distanceMoved; }
    }
    public bool FrogGone
    {
        get { return frogGone; }
    }
    public int FliesCollected
    {
        get { return fliesCollected; }
    }
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject lilliPadPrefab, flyPrefab;
    [SerializeField]
    private int lilliPadsToSpawn;
    [SerializeField]
    private float lilliSize, lilliPadDistance;
    private List<Transform> lilliPads;
    private GameObject fly;
    private int distanceMoved, fliesCollected;
    private float newLilliPadY;
    private bool frogGone;
    private Transform targetLilli;

    private void Start()
    {

        Application.targetFrameRate = 60;

        lilliPads = new List<Transform>();

        for(int i = 0; i < lilliPadsToSpawn; i++)
        {

            LilliPadPlatform _p = GameObject.Instantiate(lilliPadPrefab).GetComponent<LilliPadPlatform>();
            _p.PlatformSped = Random.Range(4f, 10f);
            _p.Lemings = 5;
            _p.transform.position = new Vector3(0, newLilliPadY, 0);
            _p.transform.localScale = Vector3.one * (lilliSize * 2);

            if(i == 0)
                _p.HelloLeaf();

            lilliPads.Add(_p.transform);

            newLilliPadY += lilliPadDistance;

        }

        if(flyPrefab)
            fly = GameObject.Instantiate(flyPrefab, new Vector2(0, Random.Range(lilliPads[0].position.y, lilliPads[lilliPads.Count-1].position.y)), Quaternion.identity);

        targetLilli = lilliPads[1];
        player.gameObject.GetComponent<FrogController>().SittinHard(new Vector2(0, targetLilli.position.y));

        if(PlayerPrefs.HasKey("FliesCollected"))
            fliesCollected = PlayerPrefs.GetInt("FliesCollected", 0);

    }

    private void FixedUpdate()
    {

        if(frogGone)
            return;

        if(fly)
            if(player.position.y >= fly.transform.position.y - 1)
            {

                fliesCollected++;
                PlayerPrefs.SetInt("FliesCollected", fliesCollected);
                fly.transform.position = new Vector2(0, Random.Range(lilliPads[lilliPads.Count-2].position.y, lilliPads[lilliPads.Count-1].position.y));

            }

        if(player.position.y >= targetLilli.position.y)
        {

            if(Mathf.Abs(targetLilli.position.x) > lilliSize)
                FrogPlopped();
            else
            {

                LilliPadPlatform _lilli = lilliPads[0].GetComponent<LilliPadPlatform>();
                _lilli.GoodByeLeaf();
                _lilli.PlatformSped = Random.Range(4f + (distanceMoved / 200), 10f + (distanceMoved / 200));
                lilliPads[0].position = new Vector2(0, newLilliPadY);
                newLilliPadY += lilliPadDistance;
                
                lilliPads.Add(lilliPads[0]);
                lilliPads.RemoveAt(0);

                targetLilli.GetComponent<LilliPadPlatform>().HelloLeaf();
                targetLilli = lilliPads[1];

                player.gameObject.GetComponent<FrogController>().SittinHard(new Vector2(0, targetLilli.position.y));
                distanceMoved = (int)player.position.y;

            }

        }

    }

    private void FrogPlopped()
    {

        frogGone = true;
        if(PlayerPrefs.HasKey("DistanceHighscore") && PlayerPrefs.GetInt("DistanceHighscore") >= distanceMoved)
            return;
        
        PlayerPrefs.SetInt("DistanceHighscore", distanceMoved);

    }
    
}
