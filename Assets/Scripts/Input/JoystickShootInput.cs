using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickShootInput : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    Image bgImg;
    Image joystickImg;

    private Vector3 inputVector;

    IInput inputOr;
    InputMobile input;

    GameObject player;
    bool changeVist = false;
    Vector3 lastVist;


    private void Start()
    {
        inputOr = InputManager.instance.getInput();

        if(!(inputOr is InputMobile))
        {
            gameObject.SetActive(false);
        }
        else
        {
            input = (InputMobile)inputOr;
            bgImg = GetComponent<Image>();
            joystickImg = transform.GetChild(0).GetComponent<Image>();
        }

        player = GameObject.FindGameObjectWithTag("Player");
        lastVist = new Vector3(0, 0, .1f);
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        changeVist = true;

        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform
                       , ped.position
                       , ped.pressEventCamera
                       , out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);



            //Debug.LogError("<color=red>" + pos + "</color>");

            inputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            joystickImg.rectTransform.anchoredPosition =
             new Vector2(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3)
              , inputVector.z * (bgImg.rectTransform.sizeDelta.y / 3));
        }
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        changeVist = false;
        lastVist = inputVector;        
        inputVector = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }
    public void getJoystickInput()
    {
        if (changeVist)
        {
            //inputVector.Normalize();
            input.vist = inputVector + player.transform.position;
            Debug.Log(input.vist);

            if (inputVector.magnitude > .9f)
            {
                input.fire = true;
            }
            else
            {
                input.fire = false;
            }
        }
        else
        {
            lastVist.Normalize();
            input.vist = lastVist + player.transform.position;
            Debug.Log(input.vist);

            input.fire = false;
        }
    }
    private void Update()
    {
        getJoystickInput();
    }
}