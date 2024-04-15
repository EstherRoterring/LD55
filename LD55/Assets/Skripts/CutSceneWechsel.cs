using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    public float changeTime = 40;

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(changeTime);
        Debug.Log(Time.deltaTime);
        changeTime -= Time.deltaTime;
        if(changeTime <= 0){
            Debug.Log(changeTime <= 0);
            Debug.Log(changeTime);
            ScenenWechsel.NextScene();
        }


        
    }
}
