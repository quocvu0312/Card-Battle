using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

public class BattleControls : MonoBehaviour {

	// Use this for initialization

    public static BattleControls It;
    TextAsset databattle;

    public Dictionary<int, GameObject> lstCharater;

    private ThuocTinh[] startdata;
    private StepData[] stepdata;

    void Awake()
    {
        databattle = Resources.Load("data_battle") as TextAsset;
        Debug.Log(databattle);

        lstCharater = new Dictionary<int, GameObject>();

        JObject data= JObject.Parse(databattle.ToString());

        startdata = JsonConvert.DeserializeObject<ThuocTinh[]>(data["data"]["startData"].ToString());
        stepdata = JsonConvert.DeserializeObject<StepData[]>(data["data"]["stepData"].ToString());
    }

	void Start () {

        It = this;

        Init();
	}
	

    public void Init()
    {
       // GameObject _chrter = ControlsCharater.It.get_charater(0);
        StartCoroutine(_add_Charater());
        StartCoroutine(handle_start_attack(3.0f));
        
    }


    #region setup charater
    IEnumerator _add_Charater()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < startdata.Length; i++)
        {

            StartCoroutine(create_charater(startdata[i]));
        }
      
    }


    IEnumerator create_charater(ThuocTinh _thuoctinh)
    {

            GameObject _chrter = ControlsCharater.It.get_charater();
            _chrter.GetComponent<Charater>().Init(_thuoctinh);
            lstCharater[_thuoctinh.chaBattleId] = _chrter;
            
            yield return 0;
    }

    
    #endregion
    #region attack
    public int step_attack = 0;

    IEnumerator handle_start_attack(float _delay)
    {
        yield return new WaitForSeconds(_delay);

        start_attack();
    }

    void start_attack()
    {
        if (step_attack < stepdata.Length)
        {
            StartCoroutine(attack_flow_step(2.0f, stepdata[step_attack]));
        }
        else
        {
            return;
        }
    }

    IEnumerator attack_flow_step( float delay, StepData _stdata)
    {
        yield return new WaitForSeconds(delay);
        Charater chrt_attack = lstCharater[_stdata.chaBattleId].GetComponent<Charater>();
        chrt_attack.Attack(_stdata);
        step_attack++;
        start_attack();
    }
    #endregion
}

public class Enemy
{
    public int enemyBattleId { get; set; }
    public int enemyChaId { get; set; }
    public int enemyActionId { get; set; }
    public int enemyPowerPercent { get; set; }
    public int enemyChangeHp { get; set; }
    public int enemyBuff { get; set; }
    public int enemyCurrentHp { get; set; }
    public int enemyTotalHp { get; set; }
}

public class chaDefenseBuff
{

}

public class chaAttackBuff
{

}

public class StepData
{
    public int chaBattleId { get; set; }
    public Enemy[] enemyChaArr { get; set; }
    public chaDefenseBuff[] chaDefenseBuff { get; set; }
    public int chaBuff { get; set; }
    public int chaExpendHp { get; set; }
    public int chaId { get; set; }
    public int txtEffectId { get; set; }
    public chaDefenseBuff[] chaAttackBuff { get; set; }
    public int actionId { get; set; }
    public int chaTotalPower { get; set; }
    public int chaCurrentHp { get; set; }
    public int chaTotalHp { get; set; }
    public int chaPowerPercent { get; set; }
    public int skill { get; set; }
    public int chaCurrentPower { get; set; }

}
