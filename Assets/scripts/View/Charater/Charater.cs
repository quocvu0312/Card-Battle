using UnityEngine;
using System.Collections;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class Charater : MonoBehaviour {

	// Use this for initialization
    public ThuocTinh _thuoctinh { get; set; }
 public Vector3 _myPos { get; set; }
 public GameObject _mau;

	void Start () {
	
	}

    public void Init(ThuocTinh _dtCharater)
    {
     //   this._mau.SetActive(false);
        _thuoctinh = _dtCharater;
        show_charater();
        show_direction_charater();
    }
    #region show charater
    protected void show_charater()
    {
        this.GetComponent<Animator>().runtimeAnimatorController = ControlsCharater.It.lstAnimator[Random.Range(0, 2)];
    }

    protected void show_direction_charater()
    {
        if(_thuoctinh.chaDirection==1)
        {
            switch (_thuoctinh.chaPos)
            {
                case 1:
                    this.transform.localPosition = new Vector3(-3.5f, -1.70f);
                    break;
                case 2:
                    this.transform.localPosition = new Vector3(-3.5f, -1.2f);
                    break;
                case 3:
                    this.transform.localPosition = new Vector3(-3.5f, -0.70f);
                    break;
                case 4:
                    this.transform.localPosition = new Vector3(-1.5f, -1.70f);
                    break;
                case 5:
                    this.transform.localPosition = new Vector3(-1.5f, -1.2f);
                    break;
                case 6:
                    this.transform.localPosition = new Vector3(-1.5f, -0.5f);
                    break;
            }
        }
        else if (_thuoctinh.chaDirection == 2)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
            switch (_thuoctinh.chaPos)
            {
                case 1:
                    this.transform.localPosition = new Vector3(3.5f, -1.70f);
                    break;
                case 2:
                    this.transform.localPosition = new Vector3(3.5f, -1.2f);
                    break;
                case 3:
                    this.transform.localPosition = new Vector3(3.5f, -0.50f);
                    break;
                case 4:
                    this.transform.localPosition = new Vector3(1.5f, -1.70f);
                    break;
                case 5:
                    this.transform.localPosition = new Vector3(1.5f, -1.2f);
                    break;
                case 6:
                    this.transform.localPosition = new Vector3(1.5f, -0.5f);
                    break;
            }
        }

        this._myPos = this.transform.localPosition;
    }

    protected void show_positon_charater()
    {
        if(_thuoctinh.chaDirection==1)
        {
            
        }
    }
    #endregion
    #region Attack
    public void Attack(StepData _stData)
    {
        AttackProtocol attk = new Attack1();
        attk.ID_SKILL_ATTACK = _stData.skill;

        StartCoroutine(attk.handle_move_enemy(this.gameObject, BattleControls.It.lstCharater[_stData.enemyChaArr[0].enemyBattleId]));
       // attk.Attack();
    }

    public void IsAttack(int _hpChange)
    {
        //this._mau.SetActive(true);
        //this._mau.GetComponentInChildren<TextMesh>().text = _hpChange.ToString();
    }

    public void hidemau()
    {
        this._mau.SetActive(false);
    }
    #endregion
}

public class ThuocTinh
{
    public int chaBattleId { get; set; }
    public int chaDirection { get; set; }
    public int chaIcon { get; set; }
    public int chaId { get; set; }
    public string chaName { get; set; }
    public int chaPos { get; set; }
    public int chaLevel { get; set; }
    public int baseQuality { get; set; }
    public int chaCurrentHp { get; set; }
    public int chaTotalHp { get; set; }
    public int chaPz { get; set; }
}