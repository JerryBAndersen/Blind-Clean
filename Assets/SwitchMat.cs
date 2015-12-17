using UnityEngine;
using System.Collections;

public class SwitchMat : MonoBehaviour {

    public Material mat1,mat2;
    bool toggle = true;
     
	void Start () {
	
	}
	
	void Update () {
        if (Manager.MANAGERINSTANCE) {
            if (GetComponent<Renderer>() && SixenseInput.GetController(SixenseHands.RIGHT)!=null) {
                if (SixenseInput.GetController(SixenseHands.RIGHT).GetButtonDown(SixenseButtons.ONE)) {
                    //GetComponent<Renderer>().material = toggle ? mat1 : mat2;
                    Material[] mats = GetComponent<Renderer>().materials;
                    mats[0] = toggle ? mat1 : mat2;
                    GetComponent<Renderer>().materials = mats;
                    toggle = !toggle;
                }
            }
        }

	}
}
