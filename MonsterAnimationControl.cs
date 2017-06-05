using UnityEngine;
using System.Collections;
using MonsterLove.StateMachine;

public class MonsterAnimationControl : MonoBehaviour {

    public enum State
    {
        Moving, Idle
    }

    public float HorizontalThreshold = .0001f;
    public float FlipXThreshold = .1f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

//    private Vector3 lastPosition;
    private Vector3 lastChangePosition;
    private int direction = 1;

    private StateMachine<State> fsm;

//    private NavMeshAgent parentAgent;

    private Vector3 lastPos;

	private PowerUpController powerUpController;


	void Start () {
        fsm = StateMachine<State>.Initialize(this);
//        lastPosition = transform.position;
        lastChangePosition = transform.position;

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

//        parentAgent = GetComponentInParent<NavMeshAgent>();

        lastPos = transform.position;

		powerUpController = GameObject.Find("GameController").GetComponent<PowerUpController>();

	}
	
	void Update () {

        Vector3 currentPosition = transform.position;

        float xVelocity = (currentPosition.x - lastPos.x)*Time.deltaTime;

//        float diff = Mathf.Abs(currentPosition.x - lastPos.x);

        if (Mathf.Abs(xVelocity) > HorizontalThreshold)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
            
        int prevDirection = direction;
        if (lastPos.x > transform.position.x)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }

        if (prevDirection != direction)
        {
            lastChangePosition = transform.position;
        }
	    

        if (Mathf.Abs(lastChangePosition.x - transform.position.x) > FlipXThreshold)
        {
            if (lastPos.x > transform.position.x)
            {
                // left
                spriteRenderer.flipX = false;

            }
            else
            {
                // right
                spriteRenderer.flipX = true;
            }

            lastChangePosition = transform.position;
        }

//        lastPosition = transform.position;
        lastPos = currentPosition;

	}

    public void SetMoving()
    {
        fsm.ChangeState(State.Moving);
//        animator.SetBool("Walking", true);

    }

    public void SetIdle()
    {
        fsm.ChangeState(State.Idle);
//        animator.SetBool("Walking", false);

    }

	public void SetFlick()
	{
		//animator.SetBool ("Flicking", true);
		if (powerUpController.GownActive == false) {
			animator.SetBool ("Flicking", true);
			animator.Play ("FlickState", 0, 0f);
		}
	}

	public void EndFlick()
	{
		animator.SetBool ("Flicking", false);

	}
}
