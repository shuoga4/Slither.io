using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    // Start is called before the first frame update
    [System.NonSerialized] public bool updateGenesis = false;
    public Canvas button;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
     * 求められる挙動
     * update系をここで止めている、この関数が動くと他のupdate系を起動できる
     * カーソルに沿って動き始める
     * しっぽが生え始める
     * しっぽが追い始める
     */
    public void OnClick()
    {
        updateGenesis = true;
        button.gameObject.SetActive(false);
    }
}
