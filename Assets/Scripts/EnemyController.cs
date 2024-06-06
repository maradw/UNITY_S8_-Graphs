using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float currentTime = 0f;
    public float timer;
    public GameObject objective;
    public Vector2 speedReference;
    public float energy;

    [SerializeField] private TextMeshProUGUI lifeState;
    void Update()
    {
        
        if (energy > 0)
        {
            transform.position = Vector2.SmoothDamp(transform.position, objective.transform.position, ref speedReference, 0.5f);
        }
        else if(energy <= 0)
        {
            transform.position = Vector2.zero;
            currentTime = currentTime + Time.deltaTime;
            if (currentTime >= timer)
            {

                energy = 30;
                currentTime = 0;
            }
        }

        SetLifeText();
    }
    public void SetLifeText()
    {
        lifeState.text = " Energy: " + energy;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Node") 
        {
            objective = collision.gameObject.GetComponent<NodeController>().SelecRandomAdjancent().gameObject;
            float weight = objective.GetComponent<NodeController>().GetNodeWeight();
            RestLife(weight);
        }
    }
    public void RestLife(float weight)
    {
        energy = energy - weight;

    }
}