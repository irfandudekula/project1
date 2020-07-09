using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OptionsScript : MonoBehaviour
{
    public GameObject Opt,OptUp,OptDown;
    int s = 0,i;
    private void Start()
    {
        Options();
    }

    public void Options()
    {
        Vector3 res = Opt.transform.localScale;
        if (s==0)
        {
            while (res.z >0f)
            {
                res.z -= 0.1f;
                Opt.transform.localScale = res;
            }
            res.z = 0f;
            Opt.transform.localScale = res;
            s = 1;
            OptUp.SetActive(true);
            OptDown.SetActive(false);
        }
        else
        {        
            while (res.z < 4f)
            {
                
                res.z += 0.1f;
                Opt.transform.localScale = res;
            }
            res.z = 4f;
            Opt.transform.localScale = res;
            s = 0;
            OptUp.SetActive(false);
            OptDown.SetActive(true);
        }
    }
   

    public void exit()
    {
        Application.Quit();
    }

    

}
