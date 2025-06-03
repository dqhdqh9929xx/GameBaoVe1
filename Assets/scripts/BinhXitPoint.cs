using UnityEngine;
using UnityEngine.EventSystems;

public class BinhXitPoint : MonoBehaviour, IPointerClickHandler
{
    public GameClickManeger GameClickManeger1;
    public AnimationController1 Controller;




    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Da click vao nhan vat");
        if (GameClickManeger1.isBinhXit == true && Controller.isLeft == true && Controller.image1.enabled == true)
        {
            Debug.Log("Da du dieu kien de xit");
            Controller.image1.enabled = false;
            Controller.image1_cay.enabled = true;
            GameClickManeger1.isBinhXit = false;
        }
        else if (GameClickManeger1.isBinhXit == true && Controller.isLeft2 == true && Controller.image2.enabled == true)
        {
            Controller.image2.enabled = false;
            Controller.image2_cay.enabled = true;
            GameClickManeger1.isBinhXit = false;
        }
        else if (GameClickManeger1.isBinhXit == true && Controller.isLeft3 == true && Controller.image3.enabled == true)
        {
           Controller.image3.enabled = false;
            Controller.image3_cay.enabled = true;
            GameClickManeger1.isBinhXit = false;
        }
        else if (GameClickManeger1.isBinhXit == false)
        {
            Debug.Log("GameClickManeger1.isBinhXit == false");
        }
        else if (Controller.isLeft == false)
        {
            Debug.Log("Controller.isLeft == false");
        }
        else if (Controller.image1.enabled == false)
        {
            Debug.Log("Controller.image1.enabled == false");
        }


    }

}
