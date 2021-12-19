﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.PixelCrew.Creatures.Hero;
using Assets.PixelCrew.Model;

namespace Assets.PixelCrew.Components.LevelManagment
{
    public class ExitLevelComponent : MonoBehaviour
    {
        [SerializeField] private string _sceneName;

        public void Exit()
        {
            StartCoroutine(FadeOut());
        }

        private IEnumerator FadeOut()
        {
            var hero = FindObjectOfType<Hero>();
            var renderer = hero.GetComponent<Renderer>();
            for (float f = 1f; f >= 0; f -= 0.1f)
            {
                Color c = renderer.material.color;
                c.a = f;
                renderer.material.color = c;
                yield return new WaitForSeconds(.1f);
            }
            var session = FindObjectOfType<GameSession>();
            session.SavePlayerData();
            SceneManager.LoadScene(_sceneName);
        }
    }
}