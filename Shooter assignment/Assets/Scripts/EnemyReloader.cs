using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReloader : MonoBehaviour
{

    public float offsetTime = 2f;
    private float timer = 0f;
    private GameObject collObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (collObj != null) {
            if (!collObj.active)
            {
                timer += Time.deltaTime;
                if (timer > offsetTime)
                {
                    timer = 0f;
                    collObj.SetActive(true);
                }
            }
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            ScoreKeeper.score++;
            collObj = other.gameObject;
            collObj.SetActive(false);
        }

    }



}