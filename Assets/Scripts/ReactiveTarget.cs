using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>(); // доступ к WanderingAI
        if (behavior != null) behavior.SetAlive(false);     // если сценарий присоеденен к персонажу то 
                                                            // то меняем состояние 
            
        StartCoroutine(Die());
    }

    private IEnumerator Die() // карутина "смерти"
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}
