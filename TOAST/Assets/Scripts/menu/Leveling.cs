using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leveling : MonoBehaviour {

    private PlayerStats player;//Needs to get the right player

    private void Start()
    {
        //ui stuff to get the correct player here
       player = player.GetComponent<PlayerStats>();
    }

    private void levelUp()
    {
        //TODO put anything that need to happen on level up here, also consider everything here unbalenced
        //TODO level up screen needs to happen at fire place each level you get x stats to allocate based on levels gained

    }
}
