using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{

   public int lifes;
   public int pontos;

   private GameManager()
   {
       lifes = 5;
       pontos = 0;
   }

   private static GameManager _instance;

   public static GameManager GetInstance()
   {
       if(_instance == null)
       {
           _instance = new GameManager();
       }

       return _instance;
   }

}