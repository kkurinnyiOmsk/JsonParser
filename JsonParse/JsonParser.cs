using System.Collections.Generic;

namespace JsonParse
{

    //todo реализовать возможность конфигурирования размера отсутпа для клиентов класса, а так же количество строк при переносе
    //todo покрыть этот код юнит тестами
    public class JsonParser
    {
        public string TabConst = "  ";
        public string LineBreakeConst = "\n";

        public JsonParser()
        {

        }

        public JsonParser SetTabConst(int tabCount)
        {
            TabConst = string.Empty;

            for (int i = 0; i < tabCount; i++)
            {
                TabConst += " ";
            }

            return this;
        }

        public JsonParser SetLineBreakeConst(int lineBreakeCount)
        {
            LineBreakeConst = string.Empty;

            for (int i = 0; i < lineBreakeCount; i++)
            {
                LineBreakeConst += "\n";
            }
            return this;
        }

        /// <summary>
        /// return formatted string
        /// </summary>
        /// <param name="inputString">принимаемая для форматирования строка</param>
        /// <returns></returns>
        public string HandleString(string inputString)
        {
            string resultString = string.Empty;

            int shiftCount = 0;
            for (int strIndex = 0; strIndex < inputString.Length; strIndex++)
            {
                switch (inputString[strIndex])
                {
                    case '{':
                    case '[':
                    {
                        if (strIndex > 0 && inputString[strIndex - 1] == ':')
                        {
                            resultString += LineBreakeConst;
                            resultString += SpaceShift(shiftCount);
                            resultString += inputString[strIndex];
                            resultString += LineBreakeConst;
                            shiftCount++;
                            resultString += SpaceShift(shiftCount);
                        }
                        else
                        {
                            shiftCount++;
                            resultString += inputString[strIndex];
                            resultString += LineBreakeConst;
                            resultString += SpaceShift(shiftCount);
                        }

                        break;
                    }

                    case ',':
                    {
                        resultString += inputString[strIndex];
                        resultString += LineBreakeConst ;
                        resultString += SpaceShift(shiftCount);
                        break;
                    }

                    case '}':
                    case ']':
                    {
                        shiftCount--;
                        resultString += LineBreakeConst;
                        resultString += SpaceShift(shiftCount);
                        resultString += inputString[strIndex];
                        break;
                    }
                    default:
                    {
                        resultString += inputString[strIndex];
                        break;
                    }
                }
            }

            return resultString;
        }

        private string SpaceShift(int shift)
        {
            string result = string.Empty;

            for (int i = 0; i < shift; i++)
            {
                result += TabConst;
            }

            return result;
        }
    }
}