public float maxSpeed = 3;
public float speed = 50f;
public float jumpPower = 150f;
private Animator anim;
public bool grounded;

private RigidBody2D rb2d;

void Start()
{
rb2d = gameObject.GetComponent<RigidBody2D>();
anim = gameObject.GetComponent<Animator>();
}

void Update()
{
anim.SetBool("Grounded",grounded);
anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
   
  if(Input.GetAxis("Horizontal") < -0.1f)
  {
    transform.localScale = new Vector3(-1, 1, 1);
  }
  if(Input.GetAxis("Horizontal") > 0.1f)
  {
    transform.localScale = new Vector3(1, 1, 1);
  }
  if(Input.GetButtonDown("Jump") && grounded)
  {
    rb2d.AddForce(Vector2.up * jumpPower);
  }
}

void FixedUpdate()
{
float h = Input.GetAxis("Horizontal");
//Moving the player
rb2d.AddForce((Vector2.right * speed) * h);
//Limiting the speed of the player
if (rb2d.velocity.x > maxSpeed)
{
rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
}

if(rb2d.velocity.x < -maxSpeed)
{
rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
}
}
