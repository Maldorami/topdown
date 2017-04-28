using UnityEngine;

public interface IInput {
    
    bool GetFire();
    Vector3 GetAxis();
    Vector3 LookAt();
    void Update();

}
