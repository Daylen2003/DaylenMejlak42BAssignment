using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthDisplay : MonoBehaviour
{
    Text texthealth;
    Player player; 


    // Start is called before the first frame update
    void Start()
    {
        texthealth = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        texthealth.text = player.GetHealth().ToString();
    }
}
