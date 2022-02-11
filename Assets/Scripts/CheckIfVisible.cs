using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfVisible : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        SignalBus<SignalOnBecomeVisible>.Fire(new SignalOnBecomeVisible(false));
    }

    private void OnBecameVisible()
    {
        SignalBus<SignalOnBecomeVisible>.Fire(new SignalOnBecomeVisible(true));
    }
}
