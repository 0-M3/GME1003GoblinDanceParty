using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Media;

namespace GME1003GoblinDanceParty
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Declare some variables
        private int _numStars;          //how many stars?
        private List<int> _starsX;      //list of star x-coordinates
        private List<int> _starsY;      //list of star y-coordinate
        private List<float> _starsR;    //list of star rotation values
        private List<float> _starsT;    //list of star transparency values
        private List<float> _starsS;    //list of star scale values
        private List<Color> _starsC;    //list of star colors

        private Texture2D _starSprite;  //the sprite image for our star

        private Random _rng;            //for all our random number needs
        private Color _starColor;       //let's have fun with colour!!
        private float _starScale;       //star size
        private float _starTransparency;//star transparency
        private float _starRotation;    //star rotation


        //***This is for the goblin. Ignore it.
        Goblin goblin;
        Song music;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _rng = new Random();        //finish setting up our Random 
            _numStars = _rng.Next(50,300);              //this would be better as a random number between 100 and 300
            _starsX = new List<int>();  //stars X coordinate
            _starsY = new List<int>();  //stars Y coordinate
            _starsR = new List<float>();   //stars rotation
            _starsT = new List<float>();   //stars transparency
            _starsS = new List<float>();   //stars scale
            _starsC = new List<Color>();   //stars color

            _starColor = new Color(128 + _rng.Next(0,129), 128 + _rng.Next(0, 129), 128 + _rng.Next(0, 129));                   //this is a "relatively" easy way to create random colors
            _starScale = _rng.Next(50, 100) / 200f; //this will affect the size of the stars
            _starTransparency = _rng.Next(25, 101)/100f;   //star transparency

            //use a separate for loop for each list - for practice

            //list of star rotation values
            for (int i = 0; i < _numStars; i++)
            {
                _starsR.Add(_rng.Next(0, 101) / 100f);       //star rotation
            }

            //list of star transparency values
            for (int i = 0; i < _numStars; i++)
            {
                _starsT.Add(_rng.Next(25, 101)/100f);       //star transparency
            }

            //list of star scale values
            for (int i = 0; i < _numStars; i++)
            {
                _starsS.Add(_rng.Next(50, 100) / 200f); //star scale
            }

            //list of star colors
            for (int i = 0; i < _numStars; i++)
            {
                _starsC.Add(new Color(128 + _rng.Next(0, 129), 128 + _rng.Next(0, 129), 128 + _rng.Next(0, 129))); //star color
            }

            //List of X coordinates
            for (int i = 0; i < _numStars; i++) 
            { 
                _starsX.Add(_rng.Next(0, 801)); //all star x-coordinates are between 0 and 801
            }

            //List of Y coordinates
            for (int i = 0; i < _numStars; i++)
            {
                _starsY.Add(_rng.Next(0, 481)); //all star y-coordinates are between 0 and 480
            }

            //ToDo: List of Colors
            
            //ToDo: List of scale values

            //ToDo: List of transparency values

            //ToDo: List of rotation values


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //load out star sprite
            _starSprite = Content.Load<Texture2D>("starSprite");


            //***This is for the goblin. Ignore it for now.
            goblin = new Goblin(Content.Load<Texture2D>("goblinIdleSpriteSheet"), 400, 400);
            music = Content.Load<Song>("chiptune");
            
            //if you're tired of the music player, comment this out!
            MediaPlayer.Play(music);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

   
            //***This is for the goblin. Ignore it for now.
            goblin.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            
            _spriteBatch.Begin();

            //it would be great to have a background image here! 
            //you could make that happen with a single Draw statement.

            //this is where we draw the stars...
            for (int i = 0; i < _numStars; i++) 
            {
                _spriteBatch.Draw(_starSprite, 
                    new Vector2(_starsX[i], _starsY[i]),    //set the star position
                    null,                                   //ignore this
                    _starsC[i] * _starsT[i],         //set colour and transparency
                    _starsR[i],                          //set rotation
                    new Vector2(_starSprite.Width / 2, _starSprite.Height / 2), //ignore this
                    new Vector2(_starsS[i], _starsS[i]),    //set scale (same number 2x)
                    SpriteEffects.None,                     //ignore this
                    0f);                                    //ignore this
            }
            _spriteBatch.End();



            //***This is for the goblin. Ignore it for now.
            goblin.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
