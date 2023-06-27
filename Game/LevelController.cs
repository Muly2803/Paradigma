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
        private  Time _time;


        public void Initialization()
    {

        _time.Initialize();
            enemyGenerationTimer = 0f;
            Vector2 minBounds = new Vector2(350, 100);
            Vector2 maxBounds = new Vector2(1000, 650);
            _player = new Character("Textures/auto/Jugador.png", new Vector2(500, 300), new Vector2(.10f, .10f), 0, 1000, minBounds,maxBounds);
            
        }

        public void Update()
    {
            enemyGenerationTimer += Time.DeltaTime;
            if (enemyGenerationTimer >= enemyGenerationInterval)
            {
                CustomVector2 minEnemyPosition = new CustomVector2(300, 0);
                CustomVector2 maxEnemyPosition = new CustomVector2(1000, 100);
                float minSpeed = 300; 
                float maxSpeed = 800;
                enemies.Add(new Enemy("Textures/auto/enemigo.png", Class1.RandomPosition(minEnemyPosition, maxEnemyPosition), new Vector2(.20f, .20f), 0, 500, minEnemyPosition, maxEnemyPosition, minSpeed, maxSpeed));
                enemies.Add(new Enemy("Textures/auto/enemigo.png", Class1.RandomPosition(minEnemyPosition, maxEnemyPosition), new Vector2(.20f, .20f), 0, 500, minEnemyPosition, maxEnemyPosition, minSpeed, maxSpeed));
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
