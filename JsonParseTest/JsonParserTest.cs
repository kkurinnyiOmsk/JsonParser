using FluentAssertions;
using JsonParse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JsonParseTest
{
    [TestClass]
    public class JsonParserTest
    {

        [TestMethod]
        public void SmallSet()
        {
            //init
            string inputString = "{\"UserID\":53568,\"FirstName\":\"Kat\",\"LastName\":\"Burke\"}";
            JsonParser jsonParser = new JsonParser();
            
            //action
            string outputString = jsonParser.HandleString(inputString);
            
            //assert
            outputString.Should().Be("{\n  \"UserID\":53568,\n  \"FirstName\":\"Kat\",\n  \"LastName\":\"Burke\"\n}");
        }

        [TestMethod]
        public void EndResultWithInsertedSet()
        {
            //init
            string inputString = "{\"UserID\":53568,\"FirstName\":\"Kat\",\"LastName\":\"Burke\",\"City\":{\"Count\":2342234,\"Name\":\"Omsk\",\"Country\":{\"Name\":\"Russia\"}}}";
            JsonParser jsonParser = new JsonParser();
     
            //action
            string outputString = jsonParser.HandleString(inputString);
            
            //assert
            outputString.Should()
                .Be(
                    "{\n  \"UserID\":53568,\n  \"FirstName\":\"Kat\",\n  \"LastName\":\"Burke\",\n  \"City\":\n  {\n    \"Count\":2342234,\n    \"Name\":\"Omsk\",\n    \"Country\":\n    {\n      \"Name\":\"Russia\"\n    }\n  }\n}");
        }

        [TestMethod]
        public void SetTabConst_HandleStringWith2Tabs()
        {
            //init
            string inputString = "{\"UserID\":53568,\"FirstName\":\"Kat\",\"LastName\":\"Burke\"}";
            JsonParser jsonParser = new JsonParser();
            jsonParser.SetTabConst(2);
        
            //action
            var result = jsonParser.HandleString(inputString);
            
            //assert
            result.Should().Be("{\n  \"UserID\":53568,\n  \"FirstName\":\"Kat\",\n  \"LastName\":\"Burke\"\n}");
        }

        [TestMethod]
        public void SetTabConst_HandleStringWith5Tabs()
        {
            //init
            string inputString = "{\"UserID\":53568,\"FirstName\":\"Kat\",\"LastName\":\"Burke\"}";
            JsonParser jsonParser = new JsonParser();
            jsonParser.SetTabConst(5);
        
            //action
            var result = jsonParser.HandleString(inputString);
            
            //assert
            result.Should().Be("{\n     \"UserID\":53568,\n     \"FirstName\":\"Kat\",\n     \"LastName\":\"Burke\"\n}");
        }

        [TestMethod]
        public void SetLineBreakeConst_HandleStringWith2LineBreake()
        {
            //init
            string inputString = "{\"UserID\":53568,\"FirstName\":\"Kat\",\"LastName\":\"Burke\"}";
            JsonParser jsonParser = new JsonParser();
            jsonParser.SetLineBreakeConst(2);
     
            //action
            var result = jsonParser.HandleString(inputString);
           
            //assert
            result.Should().Be("{\n\n  \"UserID\":53568,\n\n  \"FirstName\":\"Kat\",\n\n  \"LastName\":\"Burke\"\n\n}");
        }
    }
}
