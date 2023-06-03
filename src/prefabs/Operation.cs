using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoGameEngine.src.Engine;
using MonoGameEngine.src.Game;

namespace MonoGameEngine.src.prefabs
{
    internal class Operation
    {
        protected int value;
        protected Rectangle rect;
        protected string sign;

        protected Operation() { }
        public virtual void execute(int _playerScore) { }
        public virtual void drawOperation()
        {

        }
        public virtual void setValue(int _value)
        {
            value = _value;
        }

        public virtual void setSign(string _sign)
        {
            sign = _sign;
        }

        public virtual void setRect(Rectangle _rect)
        {
            this.rect = _rect;
        }
        public virtual void draw()
        {
            Render.drawString(Config.Instance.arialFont, sign + value.ToString(), rect);
        }
    }

    internal class OperationAdd : Operation
    {
        public OperationAdd()
        {
            sign = "+";
        }
        public override void execute(int _playerScore)
        {
            _playerScore += value;
        }
    }

    internal class OperationSubstract : Operation
    {
        public OperationSubstract()
        {
            sign = "-";
        }
        public override void execute(int _playerScore)
        {
            _playerScore -= value;
        }

    }

    internal class OperationMultiply : Operation
    {
        public OperationMultiply()
        {
            sign = "*";
        }
        public override void execute(int _playerScore)
        {
            _playerScore *= value;
        }
    }

    internal class OperationDivide : Operation
    {
        public OperationDivide() 
        {
            sign = "/";
        }    
        public override void execute(int _playerScore)
        {
            _playerScore /= value;
        }
    }
}
