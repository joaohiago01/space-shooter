using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int crystalPlayer;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCrytalPlayer(int gold)
    {
        crystalPlayer = gold;
    }
    public int getCrystalPlayer()
    {
        return crystalPlayer;
    }
}
