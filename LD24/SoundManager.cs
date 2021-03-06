﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace LD24
{
    static class SoundManager
    {
        static SoundManager()
        {
            MediaPlayer.IsRepeating = true;
        }

        public static Camera camera;

        public static void PlaySound(SoundEffect sound, float volume)
        {
            sound.Play(volume, 0F, 0F);
        }

        public static void PlaySound(SoundEffect sound, Vector2 position, float volume)
        {
            if (camera.IsOnScreen(position))
            {
                sound.Play(volume, 0F, 0F);
            }
            else
            {
                //Sound is offscreen, don't play it
            }
        }

        public static void PlayMusic()
        {
            if (MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(GameAssets.Music);
            }
        }

        public static void PlayMusicVictory()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(GameAssets.VictoryMusic);
        }

        public static void StopMusic()
        {
            if (MediaPlayer.State != MediaState.Stopped)
            {
                MediaPlayer.Stop();
            }
        }

        public static void ToggleMusic()
        {
            if (MediaPlayer.State == MediaState.Playing)
            {
                MediaPlayer.Pause();
            }
            else
            {
                MediaPlayer.Play(GameAssets.Music);
            }
        }
    }
}
