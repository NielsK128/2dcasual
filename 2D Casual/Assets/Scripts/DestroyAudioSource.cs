using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAudioSource : MonoBehaviour
{
    void Start() {
            Destroy(this.gameObject, 0.6f);
    }
}
