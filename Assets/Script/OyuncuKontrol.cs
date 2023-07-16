using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuKontrol : MonoBehaviour
{
    public float playerSpeed;
    [SerializeField] float xSpeed;
    [SerializeField] float limitx;

    float touchXDelta = 0;
    float newX = 0;


    void Start()
    {
        
    }

   

    
    void Update()
    {
        SwipeCheck();

    }



    /// <summary>
    /// Ekrana dokunup dokunulmad�g� test edilip ayr�ca karakteri haraket ettirdik
    /// </summary>
    void SwipeCheck()
    {

        //Dokunup dokunmad�g�n� kontrol i�in 
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {

            //Parmag�m�z�n de�ip degmedigini kontrol ediyoruz
            //Debug.Log("Finger is moved!!...");

            //x de ki hareki test ediyoruz
            //Debug.Log(Input.GetTouch(0).deltaPosition.x / Screen.width); //degerler b�y�k rakamalr oldugu i�in screen.width b�ld�k k���lmesi i�in


            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;

        }
        //E�er telefon bagl� degilse test edebilmek i�in mouse kullanmam�za yarar
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }
        else
        {
            touchXDelta = 0;
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;

        //Karekterin sag ve sola giderken platformdan d��memesi i�in
        newX = Mathf.Clamp(newX, -limitx, limitx);

        //�leriye dogru ko�mas� i�in 
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + playerSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
}
