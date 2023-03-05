using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset = 0f;
    public GameObject smoke;
    public bool lookAtCursor;
    public PlayerScript Player;
    public GameObject posOfGun;
    public GameObject bullet;

    private float angle;
    private bool isFacingRight;
    private void Update()
    {
        isFacingRight = Player.isFacingRight;
        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        if (lookAtCursor)
        	{
        		Vector3 lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
                lookPos = lookPos - transform.position;
        		angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Vector3 LocalScale = Vector3.one;

            if (angle > 90 || angle < -90)
            {
                LocalScale.y = -0.5f;
                LocalScale.x = +0.5f;
            }
            else
            {
                LocalScale.y = +0.5f;
                LocalScale.x = +0.5f;
            }
            transform.localScale = LocalScale;
        if (Input.GetKey(KeyCode.Mouse0)) 
            {
                Instantiate(smoke, new Vector3 (transform.position.x, transform.position.y), Quaternion.Euler(-transform.rotation.eulerAngles.z, 90f, 0f));
                Instantiate(bullet, transform);
            }    

        if (isFacingRight)
            {
                isFacingRight = !isFacingRight;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
        if (!isFacingRight)
            {
                isFacingRight = !isFacingRight;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
        }
    }
}