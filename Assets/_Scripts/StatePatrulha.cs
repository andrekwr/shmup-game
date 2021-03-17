﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrulha : State
{
    SteerableBehaviour steerable;
    float angle = 0;
    GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
        
    }
   public override void Awake()
   {
       base.Awake();

              // Criamos e populamos uma nova transição
       Transition ToAtacando = new Transition();
       ToAtacando.condition = new ConditionDistLT(transform,
           GameObject.FindWithTag("Player").transform,
           2.0f);
       ToAtacando.target = GetComponent<StateAtaque>();
       // Adicionamos a transição em nossa lista de transições
       transitions.Add(ToAtacando);

       steerable = GetComponent<SteerableBehaviour>();
   }

    //Verificar
   public void Update()
   {
       //if (gm.gameState != GameManager.GameState.GAME) return;
       angle += 0.04f;
       Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
       float x = Mathf.Sin(angle);
       float y = Mathf.Cos(angle);

       steerable.Thrust(x, y);
   }
}
