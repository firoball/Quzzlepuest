﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Behaviours
{
    [RequireComponent(typeof(UIFader))]
    public class DefaultUI : MonoBehaviour, IMenuEventTarget
    {
        UIFader m_fader;

        protected virtual void Awake()
        {
            m_fader = GetComponent<UIFader>();
        }

        public virtual void OpenMenu(GameObject newMenu)
        {
            if (newMenu != null)
            {
                StartCoroutine(OpenMenuDelayed(newMenu));
            }
        }

        public virtual void LoadLevel(int sceneIndex)
        {
            StartCoroutine(LoadLevelDelayed(sceneIndex));
        }

        public virtual void ExitGame()
        {
            StartCoroutine(ExitGameDelayed());
        }

        public virtual void OnShow(bool immediately)
        {
            m_fader.Show(immediately);
        }

        public virtual void OnHide(bool immediately)
        {
            m_fader.Hide(immediately);
        }

        private IEnumerator OpenMenuDelayed(GameObject newMenu)
        {
            OnHide(false);
            yield return new WaitForSeconds(0.2f);
            ExecuteEvents.Execute<IMenuEventTarget>(newMenu, null, (x, y) => x.OnShow(false));
        }

        private IEnumerator LoadLevelDelayed(int sceneIndex)
        {
            OnHide(false);
            yield return new WaitForSeconds(0.3f);
            SceneManager.LoadScene(sceneIndex);
        }

        private IEnumerator ExitGameDelayed()
        {
            OnHide(false);
            yield return new WaitForSeconds(0.2f);
            Application.Quit();
            Debug.Log("Application.Quit()");
        }

    }
}
