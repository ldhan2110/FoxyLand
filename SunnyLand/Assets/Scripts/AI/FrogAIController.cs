using UnityEngine;
using SunnyLand;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class FrogAIController : MonoBehaviour
{
    private PlatformerCharacter2D _character;
    private IState _state;

    private void Awake()
    {
        _character = GetComponent<PlatformerCharacter2D>();
        _state = new IdleState(this);
    }

    private void Update()
    {
        _state.Update();
    }

    private interface IState
    {
        void Update();
    }

    private abstract class State<TOwner> : IState
    {
        protected State(TOwner owner)
        {
            Owner = owner;
        }

        protected TOwner Owner { get; private set; }

        public abstract void Update();
    }

    private class IdleState : State<FrogAIController>
    {
        private readonly float _time = 2.5f;
        private float _elapsed;

        public IdleState(FrogAIController owner)
            : base(owner)
        {
            _elapsed = _time;
        }

        public override void Update()
        {
            _elapsed -= Time.deltaTime;

            if (_elapsed <= 0)
            {
                Owner._state = new ThinkState(Owner);
            }
        }
    }

    private class FlipState : State<FrogAIController>
    {
        public FlipState(FrogAIController owner)
            : base(owner)
        {
        }

        public override void Update()
        {
            Owner._character.Flip();
            Owner._state = new ThinkState(Owner);
        }
    }

    private class ThinkState : State<FrogAIController>
    {
        public ThinkState(FrogAIController owner)
           : base(owner)
        {
        }

        public override void Update()
        {
            var state = Random.Range(0, 7);

            if (state <= 1)
            {
                Owner._state = new IdleState(Owner);
            }
            else if (state <= 3)
            {
                Owner._state = new FlipState(Owner);
            }
            else
            {
                Owner._state = new JumpState(Owner);
            }
        }
    }

    private class JumpState : State<FrogAIController>
    {
        public bool _jumpNow;
        private float _flyElapsed;

        public JumpState(FrogAIController owner) 
            : base(owner)
        {
            _jumpNow = true;
            _flyElapsed = 0.3f;
        }

        public override void Update()
        {
            _flyElapsed -= Time.deltaTime;

            if (_flyElapsed < 0 && Owner._character.IsGrounded)
            {
                Owner._state = new ThinkState(Owner);
            }
            else
            {
                var velocity = Owner._character.m_FacingRight ? 0.5f : -0.5f;
                Owner._character.Move(velocity, false, _jumpNow);
                _jumpNow = false;
            }
        }
    }
}
