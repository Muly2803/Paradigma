﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;
using CustomVector2 = Game.CustomVector2;

namespace Game
{
    public class Enemy : GameObject
    {

        /* Character Properties */


        private Character _player;
        private float GetX;
        /* Speed Values */
        private float _movementSpeed;
        private float _rotationSpeed;
        private float _minSpeed;
        private float _maxSpeed;
        private Random _random;
        private float _currentSpeed;
        private int v;
        private bool _isMovingHorizontally;
        private bool _isMovingVertically;
        #region PUBLIC_METODS

        public Enemy(string texturePath, Vector2 position, Vector2 scale, float angle, float movementSpeed, CustomVector2 minPosition, CustomVector2 maxPosition, float minSpeed, float maxSpeed, bool isMovingHorizontally, bool isMovingVertically) : base(position, scale, angle)
        {
            _player = LevelController.Player;
            _random = new Random();
            _transform = new Transform((Vector2)Class1.RandomPosition(minPosition, maxPosition), scale, angle);
            _movementSpeed = movementSpeed;
            _rotationSpeed = 0f;
            _minSpeed = minSpeed;
            _maxSpeed = maxSpeed;
            _renderer = new Renderer(currentAnimation, scale);
            _currentSpeed = (float)_random.NextDouble() * (_maxSpeed - _minSpeed) + _minSpeed;
            _isMovingHorizontally = isMovingHorizontally;
            _isMovingVertically = isMovingVertically;

        }

        public Enemy(Vector2 position, Vector2 scale, float angle, int v) : base(position, scale, angle)
        {
            this.v = v;
        }

        protected override void CreateAnimations()
        {
            List<Texture> idleTextures = new List<Texture>();
            for (int i = 0; i < 4; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/auto/Enemigos/Enemigo vertical.png");
                idleTextures.Add(frame);
            }
            currentAnimation = new Animation("Idle", idleTextures, 0.1f, true);
            //float randomSpeed = (float)_random.NextDouble() * (_maxSpeed - _minSpeed) + _minSpeed;

        }


        public void Initialize() { }

        public void Update()
        {

            //_transform.Translate(new Vector2(0, 1), _currentSpeed);
            //_transform.Rotate(1, _rotationSpeed);

            //if (_transform.Position.X >= 1280 + _renderer.Texture.Width)
            //    _transform.SetPositon(new Vector2(-_renderer.Texture.Width, _transform.Position.Y));

            //currentAnimation.Update();
            //CheckCollision();

            if (_isMovingHorizontally)
            {
                _transform.Translate(new Vector2(1, 0), _currentSpeed); // Movimiento horizontal

                if (_transform.Position.X >= 1280 + _renderer.Texture.Width)
                    _transform.SetPositon(new Vector2(-_renderer.Texture.Width, _transform.Position.Y));
            }

            if (_isMovingVertically)
            {
                _transform.Translate(new Vector2(0, 1), _currentSpeed); // Movimiento vertical

                if (_transform.Position.Y >= 720 + _renderer.Texture.Height)
                    _transform.SetPositon(new Vector2(_transform.Position.X, -_renderer.Texture.Height));
            }
            currentAnimation.Update();
            CheckCollision();
        }

        public void CheckCollision()
        {

            float distanceX = Math.Abs(_player.Transform.Position.X - _transform.Position.X);
            float distanceY = Math.Abs(_player.Transform.Position.Y - _transform.Position.Y);

            float sumHalfWidths = _player.Renderer.Texture.Width / 30 + _renderer.Texture.Width / 30;
            float sumHalfHeights = _player.Renderer.Texture.Height / 30 + _renderer.Texture.Height / 30;

            if (distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
            {
                GameManager.Instance.ChangeGameState(GameState.GameOverScreen);
            }
        }

        public void Render()
        {
            _renderer.Render(_transform);
        }

        #endregion


    }
}
