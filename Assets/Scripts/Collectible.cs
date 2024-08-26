using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement player=other.GetComponent<PlayerMovement>();
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            AudioManager.instance.PlaySfx(AudioManager.instance.sfx[1]);
            player.coins += 1;
            UIManager.Instance.coinCollectedText.text=player.coins.ToString();
        }
    }
}
