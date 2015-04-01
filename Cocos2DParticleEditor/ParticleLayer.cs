using System;
using Cocos2D;
using Microsoft.Xna.Framework;

namespace Cocos2DParticleEditor
{
    public class ParticleLayer : CCLayerColor
    {
        public static int layerTag = 1;
        public static int emitterTag = 10;
        public static CCSprite background;
        public static CCParticleSystem emitter;
        private static bool isMoveOn;
        private static CCSequence moveSequence;
        private static float moveDuration;
        private static MoveDirections moveDirection;

        public ParticleLayer()
        {
            this.Tag = layerTag;

            var windowSize = CCDirector.SharedDirector.WinSize;
        
            background = new CCSprite();
            background.AnchorPoint = CCPoint.AnchorLowerLeft;
            background.Position = CCPoint.Zero;
            background.ContentSize = windowSize;
            AddChild(background, 10);

            // setup our color for the background
            Color = new CCColor3B(Microsoft.Xna.Framework.Color.Black);
            Opacity = 255;

            isMoveOn = false;
            moveDirection = MoveDirections.NONE;
            moveDuration = 5.0f;

            this.ScheduleUpdate();
        }

        public static CCScene Scene
        {
            get
            {
                // 'scene' is an autorelease object.
                var scene = new CCScene();

                // 'layer' is an autorelease object.
                var layer = new ParticleLayer();

                // add layer as a child to scene
                scene.AddChild(layer);

                // return the scene
                return scene;

            }
        }

        public static CCParticleSystem SetEmitter(CCParticleSystem system)
        {
            var windowSize = CCDirector.SharedDirector.WinSize;
            
            //Remove existing emitter is one exist
            background.RemoveChildByTag(emitterTag);

            //Add new emitter in center screen
            emitter = system;
            emitter.Tag = emitterTag;
            emitter.Position = windowSize.Center;
            background.AddChild(emitter);

            if (isMoveOn)
            {
                SetMove(true);
            }

            return system;
        }

        public static void StopEmitter()
        {
            background.RemoveChild(emitter);
        }

        public static void UpdateEmitter(
            float gravityX, float gravityY, float speed, float speedVar, float tangencialAccel, float tangencialAccelVar, float radialAccel, float radialAccelVar,
            float startRadius, float startRadiusVar, float endRadius, float endRadiusVar, float rotatePerSecond, float rotatePerSecondVar,
            float startSize, float startSizeVar, float endSize, float endSizeVar, CCColor4F startColor, CCColor4F startColorVar, CCColor4F endColor, CCColor4F endColorVar,
            float life, float lifeVar, float angle, float angleVar, CCPoint position, CCPoint positionVar, float startSpin, float startSpinVar, float endSpin, float endSpinVar,
            float emissionRate, float duration, CCBlendFunc blendFunc, CCEmitterMode emitterMode, int totoalParticles)
        {
            emitter.Gravity = new CCPoint(gravityX, gravityY);
            emitter.Speed = speed;
            emitter.SpeedVar = speedVar;
            emitter.TangentialAccel = tangencialAccel;
            emitter.TangentialAccelVar = tangencialAccelVar;
            emitter.RadialAccel = radialAccel;
            emitter.RadialAccelVar = radialAccelVar;
            emitter.StartRadius = startRadius;
            emitter.StartRadiusVar = startRadiusVar;
            emitter.EndRadius = endRadius;
            emitter.EndRadiusVar = endRadiusVar;
            emitter.RotatePerSecond = rotatePerSecond;
            emitter.RotatePerSecondVar = rotatePerSecondVar;
            emitter.StartSize = startSize;
            emitter.StartSizeVar = startSizeVar;
            emitter.EndSize = endSize;
            emitter.EndSizeVar = endSizeVar;
            emitter.StartColor = startColor;
            emitter.StartColorVar = startColorVar;
            emitter.EndColor = endColor;
            emitter.EndColorVar= endColorVar;
            emitter.Life = life;
            emitter.LifeVar = lifeVar;
            emitter.Angle = angle;
            emitter.AngleVar = angleVar;
            emitter.Position = position;
            emitter.PosVar = positionVar;
            emitter.StartSpin = startSpin;
            emitter.StartSpinVar = startSpinVar;
            emitter.EndSpin = endSpin;
            emitter.EndSpinVar = endSpinVar;
            emitter.EmissionRate = emissionRate;
            emitter.Duration = duration;
            emitter.BlendFunc = blendFunc;
            emitter.EmitterMode = emitterMode;
            emitter.TotalParticles = totoalParticles;
        }

        public static void SetMove(bool moveOn)
        {
            var windowSize = CCDirector.SharedDirector.WinSize;

            isMoveOn = moveOn;

            if (emitter != null) 
            {
                emitter.StopAllActions();
                emitter.Position = windowSize.Center;

                if (moveOn)
                {
                    moveDirection = MoveDirections.UP;
                    moveSequence = new CCSequence(
                        new CCMoveTo(moveDuration, new CCPoint(windowSize.Center.X, windowSize.Height * 0.9f)),
                        new CCMoveTo(moveDuration, windowSize.Center));
                    emitter.RunAction(moveSequence);
                }
                else
                {
                    moveDirection = MoveDirections.NONE;
                }
            }
        }

        public override void Update(float dt)
        {
            if (isMoveOn)
            {
                var windowSize = CCDirector.SharedDirector.WinSize;               

                var system = background.GetChildByTag(emitterTag);

                if (system != null && moveSequence != null)
                {
                    if (moveSequence.IsDone)
                    {
                        switch (moveDirection)
                        {
                            case MoveDirections.UP:
                                moveDirection = MoveDirections.LEFT;
                                moveSequence = new CCSequence(
                                    new CCMoveTo(moveDuration, new CCPoint(windowSize.Width * 0.1f, windowSize.Center.Y)),
                                    new CCMoveTo(moveDuration, windowSize.Center));
                                break;
                            case MoveDirections.LEFT:
                                moveDirection = MoveDirections.DOWN;
                                moveSequence = new CCSequence(
                                    new CCMoveTo(moveDuration, new CCPoint(windowSize.Center.X, windowSize.Height * 0.1f)),
                                    new CCMoveTo(moveDuration, windowSize.Center));
                                break;
                            case MoveDirections.DOWN:
                                moveDirection = MoveDirections.RIGHT;
                                moveSequence = new CCSequence(
                                    new CCMoveTo(moveDuration, new CCPoint(windowSize.Width * 0.9f, windowSize.Center.Y)),
                                    new CCMoveTo(moveDuration, windowSize.Center));
                                break;
                            case MoveDirections.RIGHT:
                                moveDirection = MoveDirections.UP;
                                moveSequence = new CCSequence(
                                    new CCMoveTo(moveDuration, new CCPoint(windowSize.Center.X, windowSize.Height * 0.9f)),
                                    new CCMoveTo(moveDuration, windowSize.Center));
                                break;
                            default:
                                break;
                        }

                        emitter.RunAction(moveSequence);
                    }
                }
            }

            base.Update(dt);
        }
    }
}

