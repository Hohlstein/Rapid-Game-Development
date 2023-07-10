/*
Author: Klaus Wiegmann
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSample_Main : MonoBehaviour
{
    public SmoothMove move;
    public int spawn_index;
    private int spawn_x;
    private int spawn_y;

    private int number_of_columns = 5;

    private void CalcSpawnLocation(){
        spawn_x = ((spawn_index % number_of_columns) - 2) * 256;
        spawn_y = spawn_index/number_of_columns;
    }

    public void GetReady(int x){
        spawn_index = x;
        CalcSpawnLocation();
        move.setCurrentX(spawn_x);
        move.setCurrentY(spawn_y);
    }

}
