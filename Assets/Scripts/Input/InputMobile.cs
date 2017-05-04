using UnityEngine;

public class InputMobile : IInput
{
    public Vector3 dir = Vector3.zero;
    public Vector3 vist = Vector3.zero;
    public bool fire = false;

    public Vector3 GetAxis()
    {       
        dir.Normalize();
        return dir;
    }

    public bool GetFire()
    {
        return fire;
    }

    public Vector3 LookAt()
    {
        return vist;
    }

    public void Update()
    {
        //NOTHING TO DO
    }

}
