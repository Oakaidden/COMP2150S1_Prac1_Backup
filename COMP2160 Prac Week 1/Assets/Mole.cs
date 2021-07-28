using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Mole : MonoBehaviour
{
    private SpriteRenderer Sprite;
    public Color Down = new Color(1, 1, 1);
    public Color Up = new Color(1, 1, 0);
    public Color Missed = new Color(1, 0, 0);
    private float timer = 3;
    private float randomTimer;

    // Start is called before the first frame update
    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        randomTimer = Random.Range(2f, 10f);
    }


    // Update is called once per frame
    void Update()
    {
        if (Sprite.color == Down)
        {
            Debug.Log("rand " + randomTimer);
            randomTimer -= Time.deltaTime;
            
            if(randomTimer <= 0)
            {
                Sprite.color = Up;
                randomTimer = Random.Range(2f, 10f);
            }
        }
        if(Sprite.color == Up)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Sprite.color = Missed;
                timer = 2;
            }
        }
        if(Sprite.color == Missed)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                Sprite.color = Down;
                timer = 3;
            }
        }
        
    }

    void OnMouseDown()
    {
        if(Sprite.color == Up)
        {
            Sprite.color = Down;
            timer = 5;
        }
    }
}
