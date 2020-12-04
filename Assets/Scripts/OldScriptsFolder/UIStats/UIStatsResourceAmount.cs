using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UIStatsResources
{
    [System.Serializable]
    public struct StatAmount {
        public int statAmount;
        public UIStatsResource statResource;

        public override string ToString()
        {
            return $"{this.statAmount} {this.statResource.StatAmount} {this.statResource.StatMaxAmount}";
        }
        public bool OverHeal => this.statResource.StatAmount >= this.statResource.StatMaxAmount;
        public void Add() {
            this.statResource.CurrentUIStats += this.statAmount;
        }
        public void Remove() {
            this.statResource.CurrentUIStats -= this.statAmount;
        }
        public StatAmount(int statAmount, UIStatsResource statResource) {
            this.statAmount = statAmount;
            this.statResource = statResource;
        }
    }
}
