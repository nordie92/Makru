using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makru
{
    public class Variable
    {
        public bool IsEmpty { get; internal set; }
        public bool IsInt { get; internal set; }
        public bool IsFloat { get; internal set; }
        public bool IsBool { get; internal set; }
        private string m_value;
        public string Value
        {
            get
            {
                return m_value;
            }
            set
            {
                IsEmpty = true;
                IsInt = false;
                IsFloat = false;
                IsBool = false;

                m_value = value;
                if (value.Length > 0)
                {
                    IsEmpty = false;

                    int i = 0;
                    float f = 0f;
                    bool b = false;

                    IsInt = int.TryParse(value, out i);
                    IsFloat = float.TryParse(value, out f);
                    IsBool = bool.TryParse(value, out b);

                    Console.WriteLine("Detect \"" + value + "\": " + "int(" + IsInt + "), " + "float(" + IsFloat + "), " + "bool(" + IsBool + "), " + "length(" + value.Length + ")");
                }
            }
        }
        public string Name { get; set; }

        public Variable(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public Type GetValueType()
        {
            if (IsInt)
            {
                return typeof(int);
            }
            else if (IsFloat)
            {
                return typeof(float);
            }
            else if (IsBool)
            {
                return typeof(bool);
            }

            return null;
        }

        public static Variable Addition(Variable variable1, Variable variable2)
        {
            if ((variable1.IsInt || variable1.IsFloat) && (variable2.IsInt || variable2.IsFloat))
            {
                string value = (float.Parse(variable1.Value) + float.Parse(variable2.Value)).ToString();
                return new Variable("temp", value);
            }
            else
            {
                return new Variable("temp", variable1.Value + variable2.Value);
            }
        }

        public static Variable Substract(Variable variable1, Variable variable2)
        {
            if (variable1 != null && variable2 != null)
            {
                if ((variable1.IsInt || variable1.IsFloat) && (variable2.IsInt || variable2.IsFloat))
                {
                    string value = (float.Parse(variable1.Value) - float.Parse(variable2.Value)).ToString();
                    return new Variable("temp", value);
                }
                else
                {
                    return new Variable("temp", "0");
                }
            }
            else
            {
                return null;
            }
        }

        public static Variable Multiply(Variable variable1, Variable variable2)
        {
            if ((variable1.IsInt || variable1.IsFloat) && (variable2.IsInt || variable2.IsFloat))
            {
                string value = (float.Parse(variable1.Value) * float.Parse(variable2.Value)).ToString();
                return new Variable("temp", value);
            }
            else
            {
                return new Variable("temp", "0");
            }
        }

        public static Variable Divide(Variable variable1, Variable variable2)
        {
            if ((variable1.IsInt || variable1.IsFloat) && (variable2.IsInt || variable2.IsFloat))
            {
                string value = (float.Parse(variable1.Value) / float.Parse(variable2.Value)).ToString();
                return new Variable("temp", value);
            }
            else
            {
                return null;
            }
        }
    }
}
