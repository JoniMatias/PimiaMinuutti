using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {
    private HitpointTimer player1Timer;
    private HitpointTimer player2Timer;

    public GameState state;

    public int winnerPlayerIndex = -1;

    public enum GameState {
        starting, ongoing, ended
    };

    private void Start() {

        HitpointTimer[] timers = FindObjectsOfType<HitpointTimer>();
        player1Timer = timers[0];
        player2Timer = timers[1];

        state = GameState.starting;

        Invoke("BeginGame", 1);
    }

    private void BeginGame() {
        state = GameState.ongoing;
    }

    void Update() {

        if (player1Timer.time <= 0 || player2Timer.time <= 0) {
            state = GameState.ended;
            winnerPlayerIndex = player1Timer.time <= 0 ? 1 : 2;
        }

    }
}
