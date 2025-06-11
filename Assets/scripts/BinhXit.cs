using UnityEngine;

public class BinhXit : MonoBehaviour
{
    public GameObject BinhXitCay;
    public Transform BinhXitCayT;
    public static bool isBinhXit = false;
    public AnimationController1 animationController;
    public GameObject BinhXitPoint;
    void Start()
    {
        if (BinhXitCay != null)
            BinhXitCay.SetActive(true);
    }

    void Update()
    {
        if (isBinhXit == true)
        {
            Vector2 mousePos = Input.mousePosition;
            BinhXitCayT.position = mousePos;
        }
        if (isBinhXit == false)
        {
            BinhXitCayT.position = new Vector2(1500, 300);
        }
    }

    public void SelectBinhXitHoiCay()
    {
        isBinhXit = true;
    }

    public void BinhXitPointClicked()
    {
        if (isBinhXit == true && animationController.isLeft == true && animationController.image1.enabled == true)
        {
            animationController.image1.enabled = false;
            animationController.image1_cay.enabled = true;
            isBinhXit = false;
            StartCoroutine(animationController.PlayLeftAnimationAndShowChat());
            AnimationController1.isTrueChoice = false;
        }
        else if (isBinhXit == true && animationController.isLeft2 == true && animationController.image2.enabled == true)
        {
            animationController.image2.enabled = false;
            animationController.image2_cay.enabled = true;
            isBinhXit = false;
            StartCoroutine(animationController.PlayLeftAnimationAndShowChat());
        }
        else if (isBinhXit == true && animationController.isLeft3 == true && animationController.image3.enabled == true)
        {
            animationController.image3.enabled = false;
            animationController.image3_cay.enabled = true;
            isBinhXit = false;
            AnimationController1.isTrueChoice = false;
            StartCoroutine(animationController.PlayLeftAnimationAndShowChat());
        }
    }
}
