using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPC_Server
{
    internal static class Calculator
    {
        internal static float? Calculate(MessageModel model)
        {
            if (model.Task == TaskType.Addition)
            {
                return model.Number1 + model.Number2;
            }
            else if (model.Task == TaskType.Subtraction)
            {
                return model.Number1 - model.Number2;
            }
            else if (model.Task == TaskType.Multiplication)
            {
                return model.Number1 * model.Number2;
            }
            else if (model.Task == TaskType.Division)
            {
                return model.Number1 / model.Number2;
            }
            else
            {
                return null;
            }
        }
    }
}
