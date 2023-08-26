﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SkibidiRunner.Managers;
using UnityEngine;
using YandexSDK.Scripts;

namespace Skins
{
    public class PlayerSkinSetter : MonoBehaviourInitializable
    {
        [SerializeField] private Animator animator;
        [field: SerializeField] public List<PlayerSkinSo> PlayerList { get; private set; }

        private int _prevId = -1;

        public override void Initialize()
        {
            _prevId = -1;
            SetCurrentSkin();
        }

        public void SetCurrentSkin()
        {
            SetSkin(PlayerList.Find(x => x.Id == LocalYandexData.Instance.SaveInfo.PlayerSkinId));
        }

        public void SetSkin(PlayerSkinSo playerSkinSo)
        {
            if(_prevId == playerSkinSo.Id) return;
            
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            var model = Instantiate(playerSkinSo.PlayerModel, transform);
            if (animator.avatar == playerSkinSo.Avatar) return;
            animator.avatar = playerSkinSo.Avatar;
            animator.Rebind();
            _prevId = playerSkinSo.Id;
        }
    }
}