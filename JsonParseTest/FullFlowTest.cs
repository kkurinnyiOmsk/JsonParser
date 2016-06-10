using System;
using System.Security.Policy;
using JsonParse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JsonParseTest
{
    [TestClass]
    public class FullFlowTest
    {
        [TestMethod]
        public void EndResult()
        {
            string inputString = "{\"UserID\":53568,\"FirstName\":\"Kat\",\"LastName\":\"Burke\",\"About\":\" < br > \",\"Password\":\"b3c9f589aabff0d9ee18e2b342902095\",\"Email\":\"katburke @the8app.com\",\"UserName\":null,\"Gender\":null,\"Zipcode\":null,\"UserProfileStep\":4,\"DisplayLocation\":false,\"DisplayBirthday\":false,\"City\":null,\"Country\":null,\"CountryID\":null,\"IsVerified\":true,\"IsActive\":true,\"UserGuid\":\"0446cc76 - 5af9 - 4c23 - 9943 - 93f494dcdb15\",\"LastLogin\":\"2016 - 03 - 31T21: 24:43.127\",\"ModifiedDate\":\"2016 - 03 - 31T21: 24:43.127\",\"Settings\":null,\"UserType\":1,\"ProfilePicture\":null,\"ActiveAlerts\":null,\"CompanyEIN\":null,\"UserUrl\":\"katburke\",\"AgreedToLatestsTerms\":true,\"AccountTypes\":[],\"LegalOwnerName\":null,\"LegalOwnerTypeID\":0,\"LegalOwnerAddressLine1\":null,\"LegalOwnerAddressLine2\":null,\"LegalOwnerCity\":null,\"LegalOwnerCountryID\":0,\"LegalOwnerStateID\":0,\"LegalOwnerZipCode\":null,\"SourceID\":null,\"RegistrationSourceKey\":null,\"DeviceID\":null,\"DeviceTypeID\":2,\"PushToken\":null,\"ReferrerTypeID\":null,\"CreatedDate\":\"2016 - 03 - 28T16: 19:45.2\",\"DOB\":\"1996 - 02 - 03T00: 00:00\",\"VoteMagId\":0,\"InvitedByUserId\":null,\"PaymentDetails\":[],\"SignedInAsUser\":null,\"MagOwnerGuid\":null,\"MagManagerId\":null,\"ManagedMagId\":53871,\"HasMagsToManage\":false,\"MagUrl\":null,\"SelectAddress\":\"New York, NY, United States\",\"CableProvider\":null,\"DateDay\":\"3\",\"DateMonth\":\"2\",\"DateYear\":\"1996\",\"LanguageId\":null,\"SecurityAndPrivacy\":{\"VerifyByPhone\":false,\"AllowFindByName\":true,\"AllowFindByFirstAndLast\":true,\"AllowFindByEmail\":false},\"Communication\":{\"EmailWithNews\":true,\"EmailWithSuggestions\":true,\"EmailWithTips\":true,\"EmailWithNewFollowers\":false,\"EmailWithNewReposts\":false,\"EmailWithNewComments\":false},\"LoginHistory\":null}";

            string expectedResult = "";

            JsonParser jsonParser = new JsonParser();

            string outputString = jsonParser.HandleString(inputString);
        }

        [TestMethod]
        public void SmallSet()
        {
            string inputString = "{\"UserID\":53568,\"FirstName\":\"Kat\",\"LastName\":\"Burke\"}";


            JsonParser jsonParser = new JsonParser();
            string outputString = jsonParser.HandleString(inputString);

            string expectedResult = "{\n  \"UserID\":53568,\n  \"FirstName\":\"Kat\",\n  \"LastName\":\"Burke\"\n}";
            Assert.AreEqual(expectedResult, outputString);
        }

        [TestMethod]
        public void EndResultWithInsertedSet()
        {
            string inputString = "{\"UserID\":53568,\"FirstName\":\"Kat\",\"LastName\":\"Burke\",\"City\":{\"Count\":2342234,\"Name\":\"Omsk\",\"Country\":{\"Name\":\"Russia\"}}}";

            JsonParser jsonParser = new JsonParser();
            string outputString = jsonParser.HandleString(inputString);

            string expectedResult = "{\n  \"UserID\":53568,\n  \"FirstName\":\"Kat\",\n  \"LastName\":\"Burke\"\n}";
            Assert.AreEqual(expectedResult, outputString);
        }
    }
}
