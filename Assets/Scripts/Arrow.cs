using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Arrow : MonoBehaviour
{
    [SerializeField]
    private Transform initialPos;
    public float speed = 5f;
    private int damageAmmout = 25;
    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement player=other.GetComponent<PlayerMovement>();
        if (other.gameObject.CompareTag("Player"))
        {
            player.health -= damageAmmout;
            if (player.health <= 0)
            {
                player.health = 0;
                UIManager.Instance.ActivateGameOverPanel();
                player.gameObject.SetActive(false);
            }
            UIManager.Instance.healthSlider.value = player.health;
            gameObject.SetActive(false);
            gameObject.transform.position = initialPos.transform.position;
            gameObject.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Blocker"))
        {
            gameObject.SetActive(false);
            gameObject.transform.position = initialPos.transform.position;
            gameObject.SetActive(true);
            
        }
    }
}
