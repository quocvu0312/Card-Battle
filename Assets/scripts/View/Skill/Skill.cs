using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour {

	// Use this for initialization

    public bool isLoop;
	void Start () {
	
	}

   public void Init( int sk_id,bool _isLoop=false)
    {
        isLoop = _isLoop;
    }
	
	// Update is called once per frame
	public void hideSkill()
    {
        if(isLoop)
        {
            ControlsSkill.It.set_skill(this.gameObject);
        }
    }
}
