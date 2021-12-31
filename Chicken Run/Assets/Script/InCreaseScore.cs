using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCreaseScore : MonoBehaviour
{

    GameController gco;
    public static int dem = 0;
    int stt;
    // Start is called before the first frame update
    void Start()
    {
        stt = dem;
        gco = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stt != 0 && gco.IsGameover != true) transform.position -= new Vector3(0.07f, 0, 0);

        if (transform.position.x < -12) Destroy(gameObject);
        if (gco.IsReplay)
        {
            if (transform.position.x < 9.46 && transform.position.y > -3) Destroy(gameObject);

        }
    }
}
