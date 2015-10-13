using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlsCharater : MonoBehaviour {

	// Use this for initialization

    public static ControlsCharater It;
    public GameObject gob_Charater;

    public Queue<GameObject> _charaters;
    public RuntimeAnimatorController[] lstAnimator;


    void Awake()
    {
        It = this;
      
    }

	void Start () {
        _charaters = new Queue<GameObject>();
        for (int i = 0; i < 12; i++)
        {
            GameObject gob = Instantiate(gob_Charater) as GameObject;
            gob.transform.parent = this.transform;

           gob.SetActive(false);
           _charaters.Enqueue(gob);

        }
       
	}
	

    public GameObject get_charater()
    {
        Debug.Log("show ABC");
        GameObject _charReturn = _charaters.Dequeue() ;
        _charReturn.SetActive(true);
       
        return _charReturn;
    }

	// Update is called once per frame
	
}
