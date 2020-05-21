using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int _maxHealth;
    public int _health;
    public int _gold;
    GameManager _gameManager;
    public bool hasDead = false;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    private void OnMouseDown()
    {
        _gameManager.Player.GetComponent<Animator>().SetTrigger("Attack");  
        GetComponent<Animator>().SetTrigger("Hurt");
        GetHurt(_gameManager._damage);
    }

    private void GetHurt(int damage)
    {
        int health = _health - damage;
        if(health <= 0 && !hasDead)
        {
            hasDead = true;
            GetComponent<Animator>().SetTrigger("Death");
            Destroy(gameObject, 0.7f);
            _gameManager.EnemyDeath(_gold);
           
        }
        _health = health;
        Debug.Log(_health);
    }
}
