using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game
{
    public class LevelController
    {
        private static List<Enemy> enemies = new List<Enemy>();
        private float enemyGenerationTimer;
        private float enemyGenerationInterval = 2f;

        private static Character _player;

        public static Character Player => _player;

        /// Timeframe Calculation Properties
        private Time _time;


        public void Initialization()
        {

            _time.Initialize();
            enemyGenerationTimer = 0f;
            Vector2 minBounds = new Vector2(350, 100);
            Vector2 maxBounds = new Vector2(1000, 650);
            _player = new Character("Textures/auto/Jugador.png", new Vector2(500, 300), new Vector2(.10f, .10f), 0, 1000, minBounds, maxBounds);

        }

        public void Update()
        {
            enemyGenerationTimer += Time.DeltaTime;
            if (enemyGenerationTimer >= enemyGenerationInterval)
            {
                CustomVector2 minHorizontalPosition = new CustomVector2(0, 100);
                CustomVector2 maxHorizontalPosition = new CustomVector2(100, 720);
                CustomVector2 minVerticalPosition = new CustomVector2(200, 0);
                CustomVector2 maxVerticalPosition = new CustomVector2(1000, 100);
                float minSpeed = 400;
                float maxSpeed = 900;

                Random random = new Random();
                bool isMovingHorizontally = random.Next(2) == 0; // Aleatoriamente determinamos si el enemigo se mueve horizontalmente
                bool isMovingVertically = !isMovingHorizontally; // Si no se mueve horizontalmente, entonces se moverá verticalmente

                CustomVector2 minPosition;
                CustomVector2 maxPosition;

                if (isMovingHorizontally)
                {
                    minPosition = minHorizontalPosition;
                    maxPosition = maxHorizontalPosition;
                }
                else
                {
                    minPosition = minVerticalPosition;
                    maxPosition = maxVerticalPosition;
                }

                enemies.Add(new Enemy("Textures/auto/Enemigos/Enemigo vertical.png", Class1.RandomPosition(minPosition, maxPosition), new Vector2(0.050f, 0.050f), 0, 500, minPosition, maxPosition, minSpeed, maxSpeed, isMovingHorizontally, isMovingVertically));

                // Reinicia el temporizador
                enemyGenerationTimer = 0f;
            }
            _time.Update();
            _player.Update();
            foreach (Enemy enemy in enemies) enemy.Update();


        }


        public void Render()
        {
            Engine.Clear();
            Engine.Draw("Textures/Screens/level.png");
            _player.Render();
            foreach (Enemy enemy in enemies) enemy.Render();


            Engine.Show();
        }
    }
}
