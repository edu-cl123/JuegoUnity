using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
   public GameObject selectedSkin;
   public GameObject Player;
   private Sprite playerSprite;
   
   public GameObject selectedSkin2;
   public GameObject Player2;
   private Sprite playerSprite2;
    // Start is called before the first frame update
    void Start()
    {
        playerSprite=selectedSkin.GetComponent<SpriteRenderer>().sprite;
        Player.GetComponent<SpriteRenderer>().sprite=playerSprite; 
    }

    void Update()
    {
        
    }
}
