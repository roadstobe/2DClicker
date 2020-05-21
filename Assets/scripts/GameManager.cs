using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playerGold;
    public int _damage;
    public Text goldUI;
    public GameObject Player;
    public GameObject[] _enemys;
    public Transform _spawnPosition;

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayerGold"))
        {
            playerGold = (int)PlayerPrefs.GetFloat("PlayerGold");
        }

       
    }
    private void Update()
    {
        goldUI.text = "GOLD: " + playerGold.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //PlayerPrefs.DeleteKey("PlayerGold");
            Time.timeScale = 0;
        }
        
    }
    public void EnemyDeath(int gold)
    {
        playerGold += gold;
        Invoke("SpawnEnemy", 1f);
        PlayerPrefs.SetFloat("PlayerGold", playerGold);
    }
    public void SpawnEnemy()
    {
        int index = Random.Range(0, _enemys.Length);

        GameObject enemy = Instantiate(_enemys[index]);
        enemy.transform.position = _spawnPosition.position;
    }
}
