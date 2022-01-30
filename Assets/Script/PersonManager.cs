using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class PersonManager : MonoBehaviour
{
    
    //Necesito llevar un dato en la otra escena para poder cambiar la skin y encima utilizar esas animaciones.

    
    public SpriteRenderer sr;
    public SpriteRenderer sr2;
    public List<Sprite> Skins=new List<Sprite>();
    public List<Sprite> Skins2=new List<Sprite>();
    private int selectedSkin=0;
    private int selectedSkin2=0;
    public GameObject playerskin;
     public GameObject playerskin2;

      public void NextOption2(){
        selectedSkin2=selectedSkin2+1;
        if(selectedSkin2==Skins2.Count){
            selectedSkin2=0;
        }
        sr2.sprite=Skins2[selectedSkin2];

    }

      public void BackOption2(){
        selectedSkin2=selectedSkin2-1;
        if(selectedSkin2<0){
            selectedSkin2=Skins2.Count-1;
        }
        sr2.sprite=Skins2[selectedSkin2];

    }

    public void NextOption(){
        selectedSkin=selectedSkin+1;
        if(selectedSkin==Skins.Count){
            selectedSkin=0;
        }
        sr.sprite=Skins[selectedSkin];

    }
        public void BackOption(){
        selectedSkin=selectedSkin - 1;
        if(selectedSkin<0){
            selectedSkin=Skins.Count-1;
        }
        sr.sprite=Skins[selectedSkin];
    }

    public void Playgame(){
       // PrefabUtility.SaveAsPrefabAsset(playerskin,"Assets/selectedskin.prefab");
        SceneManager.LoadScene("SampleScene");
        PlayerPrefs.SetInt("Personaje",selectedSkin);
        PlayerPrefs.SetInt("IA",1);
        PlayerPrefs.Save();
        
    }

     public void Playgame2(){
        //PrefabUtility.SaveAsPrefabAsset(playerskin,"Assets/selectedskin.prefab");
       // PrefabUtility.SaveAsPrefabAsset(playerskin2,"Assets/selectedskin2.prefab");
        SceneManager.LoadScene("Lucha");
        PlayerPrefs.SetInt("Personaje",selectedSkin);
        PlayerPrefs.SetInt("Personaje2",selectedSkin2);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("IA",2);
        Debug.Log(PlayerPrefs.GetInt("Personaje"));
        Debug.Log(PlayerPrefs.GetInt("Personaje2"));
        
    }


}
