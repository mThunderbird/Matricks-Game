using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameEngine.src.Engine
{
    internal class State
    {
        public State()
        {

        }

        public virtual void Init() { }
        public virtual void Update() { }
        public virtual void Draw() { }
        public virtual void Dispose() { }


    }

}
