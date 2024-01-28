using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomiseCentreDinteret : MonoBehaviour
{
    public Image[] CentreDinterets;

    void Start(){
        Randomiser();
    }

    // Start is called before the first frame update
    public void Randomiser(){
        Sprite[] save = {CentreDinterets[0].sprite,CentreDinterets[1].sprite,CentreDinterets[2].sprite};


        int ran = Random.Range(0,3);

        CentreDinterets[0].sprite= save[ran<3?ran:ran-3];
        CentreDinterets[1].sprite= save[ran+1<3?ran+1:ran-2];
        CentreDinterets[2].sprite= save[ran+2<3?ran+2:ran-1];
    }
}
