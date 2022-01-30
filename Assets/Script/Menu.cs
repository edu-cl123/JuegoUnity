using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
 
 public void personvsia(){
    SceneManager.LoadScene("Seleccion");
 }

 public void personvsperson(){
     SceneManager.LoadScene("Seleccion2");
 }
}
