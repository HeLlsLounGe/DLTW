using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaulScript : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canvas.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvas.gameObject.SetActive(false);
        }
    }
}
