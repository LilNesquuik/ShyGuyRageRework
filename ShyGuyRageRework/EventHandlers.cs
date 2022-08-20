using Exiled.Events.EventArgs;
using Exiled.API.Features.Roles;
using MEC;
using System.Collections.Generic;
using UnityEngine;
using Exiled.API.Features;
using Exiled.API.Enums;

namespace ShyGuyRageRework
{
    internal class EventHandlers
    {

        private bool Calm096;

        public IEnumerator<float> GetTargets(Scp096Role role096)
        {
            Calm096 = false;
            do
            {
                int RefreshDelay = 1;

                for (int ii = 0; ii < Application.targetFrameRate * RefreshDelay; ii++)
                {
                    yield return Timing.WaitForOneFrame;
                }

                if (role096 is null || role096.Owner is null || !role096.IsValid)
                    yield break;

                int TargetCount = role096.Targets.Count;

                if (TargetCount == 0)
                {
                    Calm096 = true;

                    role096.Script.EnrageTimeLeft = 0;
                }
            } while (!Calm096);
        }

        public void OnEnraging(EnragingEventArgs ev)
        {
            Timing.RunCoroutine(GetTargets(ev.Player.Role.As<Scp096Role>()));
        }

        public void OnTryingToCalm(CalmingDownEventArgs ev)
        {
            ev.IsAllowed = Calm096;
        }

    }
}
