using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Character : IDamageable
    {
        /* Character Properties */
        private Transform _transform;
        private Renderer _renderer;
        private Animation idleAnimation;
        private Animation currentAnimation;
        private LifeController _lifeController;

        public LifeController LifeController => _lifeController;
       
        public Transform Transform => _transform; 
        public Renderer Renderer => _renderer;

        /* Speed Values */
        private float _movementSpeed;
        private float _rotationSpeed;
        private Vector2 _minBounds;
        private Vector2 _maxBounds;


        #region PUBLIC_METODS

        public Character(string texturePath, Vector2 position, Vector2 scale, float angle, float movementSpeed, Vector2 minBounds, Vector2 maxBounds)
        {
            
            
            _lifeController = new LifeController(100);
            _lifeController.onGetDamage += OnGetDamageHandler;
            

            CreateAnimations();
            currentAnimation = idleAnimation;
            _movementSpeed = movementSpeed;
            _rotationSpeed = 100f;
            
            
            _minBounds = minBounds;
            _maxBounds = maxBounds;
        }

        private void OnGetDamageHandler()
        {
            Engine.Debug("aca puedo hacer una animacion de que el personaje recibe daño");
        }

        public void GetDamage(int damage)
        {

        }

        public void Destroy()
        {

        }
        private void CreateAnimations()
        {
            List<Texture> idleTextures = new List<Texture>();
            for (int i = 0; i < 4; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/auto/Jugador.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation("Idle", idleTextures, 0.1f, true);
            currentAnimation = idleAnimation;
        }



        public void Update()
        {
            InputReading();

            if (_transform.Position.X >= 1280 + _renderer.Texture.Width)
                _transform.SetPositon(new Vector2(-_renderer.Texture.Width, _transform.Position.Y));

            currentAnimation.Update();
        }

        public void Render()
        {


            _renderer.Render(_transform);
        }

        #endregion

        #region PRIVATE_METHODS


        private void InputReading()
        {
            if (Engine.GetKey(Keys.W)) MoveUp();
            if (Engine.GetKey(Keys.S)) MoveDown();
            if (Engine.GetKey(Keys.A)) MoveLeft();
            if (Engine.GetKey(Keys.D)) MoveRight();
        }

        //private void MoveUp() => _transform.Translate(new Vector2(0, -1), _movementSpeed);
        //private void MoveDown() => _transform.Translate(new Vector2(0, 1), _movementSpeed);
        //private void MoveLeft() => _transform.Translate(new Vector2(-1, 0), _movementSpeed);
        //private void MoveRight() => _transform.Translate(new Vector2(1, 0), _movementSpeed);
        private void MoveUp()
        {
            _transform.Translate(new Vector2(0, -1), _movementSpeed);
            ClampPosition();
        }

        private void MoveDown()
        {
            _transform.Translate(new Vector2(0, 1), _movementSpeed);
            ClampPosition();
        }

        private void MoveLeft()
        {
            _transform.Translate(new Vector2(-1, 0), _movementSpeed);
            ClampPosition();
        }

        private void MoveRight()
        {
            _transform.Translate(new Vector2(1, 0), _movementSpeed);
            ClampPosition();
        }

        //private void ClampPosition()
        //{
        //    float clampedX = _transform.Position.X;
        //    float clampedY = _transform.Position.Y;

        //    if (_transform.Position.X < _minBounds.X)
        //        clampedX = _minBounds.X;
        //    else if (_transform.Position.X > _maxBounds.X)
        //        clampedX = _maxBounds.X;

        //    if (_transform.Position.Y < _minBounds.Y)
        //        clampedY = _minBounds.Y;
        //    else if (_transform.Position.Y > _maxBounds.Y)
        //        clampedY = _maxBounds.Y;

        //    _transform.SetPosition(new Vector2(clampedX, clampedY));
        //}

        private void ClampPosition()
        {
            float clampedX = _transform.Position.X;
            float clampedY = _transform.Position.Y;

            if (_transform.Position.X < _minBounds.X)
                clampedX = _minBounds.X;
            else if (_transform.Position.X > _maxBounds.X)
                clampedX = _maxBounds.X;

            if (_transform.Position.Y < _minBounds.Y)
                clampedY = _minBounds.Y;
            else if (_transform.Position.Y > _maxBounds.Y)
                clampedY = _maxBounds.Y;

            _transform = new Transform(new Vector2(clampedX, clampedY), _transform.Scale, _transform.Angle);
        }
        #endregion
    }




}
