using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST1
{
    internal class StateManager
    {

        private State CurrentState { get; set; }
        private State? PreviusState { get; set; }

        public StateManager() {
            CurrentState = State.Menu;
        }

        public void ChangeState(State st)
        {
            PreviusState = CurrentState;
            CurrentState = st; // написать раеализацию перехода на новую сцену
        }

        public State GetCurrentState()
        {
            return CurrentState;
        }
        public State? GetPreviusState()
        {
            return PreviusState;
        }
    }

}
