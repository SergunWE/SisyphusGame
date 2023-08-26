using System.Collections.Generic;
using SkibidiRunner.Managers;
using UnityEngine;
using YandexSDK.Scripts;

namespace Skins
{
    public class PlayerSkinSetter : MonoBehaviourInitializable
    {
        [SerializeField] private Animator animator;
        [SerializeField] private List<PlayerSkinSo> playerList;
        
        public override void Initialize()
        {
            var model = playerList.Find(x => x.Id == LocalYandexData.Instance.SaveInfo.PlayerSkinIndex);
            animator.avatar = model.Avatar;
            Instantiate(model.PlayerModel, transform);
            animator.Rebind();
        }
    }
}