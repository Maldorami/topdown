using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickInput : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Image bgImg;
    public Image joystickImg;

    private Vector3 inputVector;

    IInput inputOr;
    InputMobile input;


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
    }

    public virtual void OnDrag(PointerEventData ped)
    {
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
        inputVector = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }

    public void getJoystickInput()
    {
        input.dir = inputVector;
    }

    private void Update()
    {
        getJoystickInput();
    }
}