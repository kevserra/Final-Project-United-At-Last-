using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePrincessWIn : MonoBehaviour
{
    [SerializeField] private Text successText;

    


    void Start()
    {
        successText.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            successText.enabled = true;
        }
    }

    void Update()
    {
        
    }
}
