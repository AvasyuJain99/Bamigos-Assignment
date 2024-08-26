using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera cam;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cam.Follow = null;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cam.Follow = other.gameObject.transform;
        }
    }
}
