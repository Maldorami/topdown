using UnityEngine;

public class InputMobile : IInput
{
    Ray ray;
    RaycastHit hit;

    
    public Vector3 dir = Vector3.zero;

    public Vector3 GetAxis()
    {       
        dir.Normalize();
        return dir;
    }

    public bool GetFire()
    {
        return Input.GetButton("Fire1");
    }

    public Vector3 LookAt()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }

        return Vector3.zero;
    }

    public void Update()
    {
        //NOTHING TO DO
    }

}
