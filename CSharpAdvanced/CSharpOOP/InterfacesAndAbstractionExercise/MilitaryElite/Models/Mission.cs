using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        private MissionStateEnum missionState;
        public Mission(string codeName, MissionStateEnum missionState)
        {
            CodeName = codeName;
            MissionState = TryParseState(missionState.ToString());
        }

        public string CodeName { get; }

        public MissionStateEnum MissionState { get; private set; }
       

        public void CompleteMission()
        {
            MissionState = MissionStateEnum.Finished;
        }
        private MissionStateEnum TryParseState(string stateStr)
        {
            MissionStateEnum state;
            bool parsed = Enum.TryParse<MissionStateEnum>(stateStr, out state);
            if (!parsed)
            {
                throw new ArgumentException("Invalid state!");
            }
            return state;

        }
    }
}
