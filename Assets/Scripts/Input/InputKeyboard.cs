using UnityEngine;

public class InputKeyboard : IInput
{
    Ray ray;
    RaycastHit hit;

    public Vector3 GetAxis()
    {
        Vector3 dir = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
            dir.x -= 1;

        if (Input.GetKey(KeyCode.D))
            dir.x += 1;

        if (Input.GetKey(KeyCode.W))
            dir.z += 1;

        if (Input.GetKey(KeyCode.S))
            dir.z -= 1;

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
