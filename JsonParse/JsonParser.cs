namespace JsonParse
{

    //todo реализовать возможность конфигурирования размера отсутпа для клиентов класса, а так же количество строк при переносе
    //todo каждую открывающую кавычку для вложенных объектов переносить на новую строку
    //todo покрыть этот код юнит тестами
    public class JsonParser
    {
        public const string TabConst = "  ";
        public const string TransferNewLine = "\n";

        public JsonParser()
        {

        }

        public string HandleString(string inputString)
        {
            int shiftCount = 0;
            for (int strIndex = 0; strIndex < inputString.Length; strIndex++)
            {
                if (inputString[strIndex] == '{')
                {
                    shiftCount++;
                    LineBreakAfterAndShift(ref inputString, strIndex, shiftCount);
                }
                if (inputString[strIndex] == ',')
                {
                    LineBreakAfterAndShift(ref inputString, strIndex, shiftCount);
                }

                //last
                if (inputString[strIndex] == '}' && strIndex == inputString.Length - 1)
                {
                    LineBreakeBefore(ref inputString, strIndex);
                    break;
                }

                if (inputString[strIndex] == '}')
                {
                    shiftCount--;
                    LineBreakBeforeAndShift(ref inputString, strIndex, shiftCount);
                    //increment index with tab new line and set after current
                    strIndex += TransferNewLine.Length + shiftCount*TabConst.Length;
                }
            }

            return inputString;
        }

        //сделать стратегию или шаблонный метод

        private void LineBreakBeforeAndShift(ref string str, int currentIndex, int shift)
        {
            LineBreakeBefore(ref str, currentIndex);
            currentIndex += TransferNewLine.Length ;
            SpaceShift(ref str, currentIndex, shift);
        }

        private void LineBreakAfterAndShift(ref string str, int currentIndex, int shift)
        {
            LineBreakeAfter(ref str, currentIndex);
            currentIndex += TransferNewLine.Length +1;
            SpaceShift(ref str, currentIndex, shift);
        }

        public void LineBreakeBefore(ref string str, int currentIndex)
        {
            str = str.Insert(currentIndex, TransferNewLine);
        }

        public void LineBreakeAfter(ref string str, int currentIndex)
        {
            str = str.Insert(currentIndex +1 , TransferNewLine);
        }

        public void SpaceShift(ref string str, int currentIndex, int shift)
        {
            for (int i = 0; i < shift; i++)
            {
                str = str.Insert(currentIndex, TabConst);
                currentIndex++;
            }
        }
    }
}