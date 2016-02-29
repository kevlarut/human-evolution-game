﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public enum Direction
    {
        Right,
        Left
    }

    public enum PersonState
    {
        Standing,
        Sitting,
        Running
    }

    public class Person : MonoBehaviour
    {
        public float MinStateChangeDelay = 1f;
        public float MaxStateChangeDelay = 10f;
        public PersonState PersonState = PersonState.Standing;
        public Direction Direction = Direction.Right;
        public float Speed = 1.0f;

        private float _currentStateChangeDelay;
        private Animator _animator;
        private Vector3 _target;

        void Start()
        {
            _currentStateChangeDelay = Random.Range(MinStateChangeDelay, MaxStateChangeDelay);
            _animator = this.GetComponent<Animator>();
            _animator.SetInteger("State", Convert.ToInt32(PersonState));
        }

        void Update()
        {
            if (PersonState == PersonState.Running)
            {
                float step = Speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, _target, step);
                if (transform.position == _target)
                {
                    ChangeState(PersonState.Standing);
                }
            }
            else
            {
                _currentStateChangeDelay -= Time.deltaTime;

                if (_currentStateChangeDelay <= 0)
                {
                    _currentStateChangeDelay = Random.Range(MinStateChangeDelay, MaxStateChangeDelay);

                    var rand = Random.Range(1, 5);
                    switch (rand)
                    {
                        case 1:
                            var direction = Direction == Direction.Right ? Direction.Left : Direction.Right;
                            ChangeDirection(direction);
                            break;
                        case 2:
                            PersonState = PersonState.Running;
                            _animator.SetInteger("State", Convert.ToInt32(PersonState));
                            _target = new Vector3(Random.Range(-2.75f, 2.75f), transform.position.y);
                            if (_target.x > transform.position.x)
                            {
                                ChangeDirection(Direction.Right);
                            }
                            else
                            {
                                ChangeDirection(Direction.Left);
                            }
                            break;
                        case 3:
                            ChangeState(PersonState.Sitting);
                            break;
                        case 4:
                            _animator.Play("Scratching");
                            break;
                    }
                }
            }
        }

        private void ChangeDirection(Direction direction)
        {
            if (Direction != direction)
            {
                if (direction == Direction.Left)
                {
                    transform.eulerAngles = new Vector3(0, 180);
                    Direction = Direction.Left;
                }
                else if (direction == Direction.Right)
                {
                    transform.eulerAngles = new Vector3(0, 0);
                    Direction = Direction.Right;
                }
            }
        }

        private void ChangeState(PersonState personState)
        {
            PersonState = personState;
            _animator.SetInteger("State", Convert.ToInt32(PersonState));
        }
    }
}