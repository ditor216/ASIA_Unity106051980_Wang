 using UnityEngine;

public class player : MonoBehaviour
{
    #region 欄位區域
    public int speed = 10;
    [Tooltip("移動速度"), Range(1, 2000)]
    public float turn = 20.5f;
    [Tooltip("旋轉"),Range(1f,500f)]
    public string _name = "玩家";
    public bool mission;

    public Transform tran;
    public Rigidbody rig;
    public Animator ani;
    #endregion



    public Rigidbody rigCatch;
 

   

    private void Update()
    {
        Turn();
        Run();
        Attack();
        Damage();
        Catch();
    }

    private void OnTriggerStay(Collider other)
    {
        print(other.name);
        if(other.name == "Wooden Crate" && ani.GetCurrentAnimatorStateInfo(0).IsName("catch"))
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());
            other.GetComponent<HingeJoint>().connectedBody = rigCatch;
        }
        if (other.name == "地板" && ani.GetCurrentAnimatorStateInfo(0).IsName("catch"))
        {
           
            GameObject.Find("Wooden Crate").GetComponent<HingeJoint>().connectedBody = null;
        }
        if (other.name == "終點")
        {

            ani.SetTrigger("IsDead");
        }
    }



    private void Run()
    {
       if (ani.GetCurrentAnimatorStateInfo(0).IsName("catch")) return;

       if (ani.GetCurrentAnimatorStateInfo(0).IsName("attack")) return;

       if (ani.GetCurrentAnimatorStateInfo(0).IsName("damage")) return;

        float v = Input.GetAxis("Vertical");
        rig.AddForce(tran.forward * speed * v * Time.deltaTime);

        ani.SetBool("run", v != 0);
    }

    private void Jump()
    {

    }


    private void Attack()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ani.SetTrigger("attack");
           
        }

      
    }


    private void Damage()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ani.SetTrigger("damage");
            
        }
    }

    private void Turn()
    {
        float h = Input.GetAxis("Horizontal");
        tran.Rotate(0, turn * h * Time.deltaTime, 0);
    }

    private void Catch()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ani.SetTrigger("catch");
        }
    }

    
}
