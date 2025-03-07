using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuff : MonoBehaviour
{
    private Player playerData;
    private void Start()
    {
        playerData = PlayerManager.Instance.playerData;
    }

    public void UseBuff(BuffData buffData)
    {
        if (buffData == null || playerData == null)
            return;

        StartCoroutine(Buff(buffData));
    }

    private IEnumerator Buff(BuffData buffData)
    {
        float defaultValue = playerData.buffValues[(int)buffData.type];
        playerData.buffValues[(int)buffData.type] = buffData.value;
        
        yield return new WaitForSeconds(buffData.duration);

        playerData.buffValues[(int)buffData.type] = defaultValue;
    }
}
