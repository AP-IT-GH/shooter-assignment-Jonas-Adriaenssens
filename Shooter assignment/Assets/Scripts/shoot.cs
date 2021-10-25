using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    public GameObject projectile;
    public AudioClip audioClip;

    // keeping track of the clones to clean after
    private List<GameObject> clones = new List<GameObject>();
    public float projectileLifeTime = 4f;
    private float lifeTimeTimer = 0f;

    // Use this for initialization
    void Start () {
       
    }

    // Update is called once per frame
    float timer = 10f;
    bool start = false;
    public float shootRate = 3f;



	void Update () {
        float shoot = Input.GetAxis("Fire1");
        print(shoot);

        if (shoot == 1 && timer >= shootRate)//shoot{
        {
          
            GameObject newProjectile = Instantiate(projectile, transform.position+transform.forward,transform.rotation) ;
            newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward*5,ForceMode.VelocityChange);

            // Add clone object to list
            clones.Add(newProjectile); 

            start = true;
            timer = 0f;

            

            if (audioClip)
            {
                if (gameObject.GetComponent<AudioSource>())
                {
                    //gameobject has audiosource
                    gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
                }
                else
                {
                    //add audiosource to gameobject: dynamically create object with audiosource,it will remove itself
                    AudioSource.PlayClipAtPoint(audioClip, transform.position);
                }
            }
        }

        if (start)
        {
            if (timer< shootRate)
                timer += Time.deltaTime;
            else
            {
                timer = shootRate;
                start = false;
            }
           
        }


        // check if it's time to remove a clone
        if (lifeTimeTimer < projectileLifeTime)
            lifeTimeTimer += Time.deltaTime;
        else
        {
            // if first item is not empty 
            if (clones.Count > 0)
            {
                // destroy clone object
                Destroy(clones[0]);
                // remove from list
                clones.RemoveAt(0); 
            }
            // reset timer
            lifeTimeTimer = 0; 
        }

        // if more than 10 projectiles are in game
        // destroy all projectiles and clean list (performance improvement)
        if (clones.Count > 10)
        {
            clones.ForEach(e => Destroy(e)); 
            clones.Clear(); 
        }



    }
}
