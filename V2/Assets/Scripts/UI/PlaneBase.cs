using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBase : MonoBehaviour
{
    private  void OnEnable() {
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnDisable() {
      //  Cursor.lockState = CursorLockMode.Locked;
    }
}
