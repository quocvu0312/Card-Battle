using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ControlsSkill : MonoBehaviour {

	// Use this for initialization
    public GameObject _skill;
    public Queue<GameObject> lstSkill;

    public static ControlsSkill It;

    public RuntimeAnimatorController[] lstAnimationSkill;
    void Awake()
    {
        lstSkill = new Queue<GameObject>();
        It = this;
        for( int i=0;i<20;i++)
        {
            GameObject _skOj = Instantiate(_skill) as GameObject;
            _skOj.transform.parent = this.transform;

            _skOj.SetActive(false);
            lstSkill.Enqueue(_skOj);
        }
    }

	void Start () {
	
	}

    public GameObject get_skill()
    {
        GameObject _ski = null;
        if(lstSkill.Count>0)
        {
            _ski = lstSkill.Dequeue();
        }
        else
        {
          _ski=  Instantiate(_skill) as GameObject;
        }

        return _ski;
    }

    public void set_skill(GameObject _ski)
    {
        _ski.transform.parent = this.transform;
        _ski.GetComponent<Animator>().runtimeAnimatorController = null;
        _ski.SetActive(false);
        lstSkill.Enqueue(_ski);
    }

	
	// Update is called once per frame
    //void Update () {
	
    //}
}
