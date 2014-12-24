using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using ZapServiceNS.DataObjects.Responses;
using ZapServiceNS.DataObjects.Requests;
using ZapService.Test.ZapServiceReference;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ZapService.Test
{
    [TestClass]
    public class ZapServiceHostTest
    {
        //private string ServiceUri = "http://localhost:63994/ZapService.svc/";
        private string ServiceUri = "http://localhost:8800/ZapService/";

        public ZapServiceHostTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public async Task Get_OK()
        {    
            using (HttpClient client = new HttpClient())                     
            {
                client.BaseAddress = new Uri(ServiceUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/test");  
                string result = string.Empty;

                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }

                result = result.Trim(new []{'"'});
                
                Assert.AreEqual<string>("OK!!!", result);         
            }                           
        }

        [TestMethod]
        public async Task Subscribe_Unsubscribe()
        {
            // Arrange
            SubscribeRequest requestObj = new SubscribeRequest() { Event = "Trigger_H", Target_URL = @"http://test.com/asdf" };
            SubscribeResponse responseObj = null;
            UnSubscribeResponse responseObj2 = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServiceUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // UnSubscribe
                HttpResponseMessage response = await client.PostAsJsonAsync("api/hooks", requestObj);
                
                if (response.IsSuccessStatusCode)
                {
                    responseObj = await response.Content.ReadAsAsync<SubscribeResponse>();
                }
                                
                Assert.IsNotNull(responseObj, "responseObj must to be created.");
                Assert.IsTrue(responseObj.Success, "Success must to be TRUE.");
                Assert.IsTrue(responseObj.SubscribeId > 0, "SubscribeId must to be more than 0.");


                // UnSubscribe
                response = await client.DeleteAsync(string.Format("api/hooks/{0}", responseObj.SubscribeId));
                
                if (response.IsSuccessStatusCode)
                {
                    responseObj2 = await response.Content.ReadAsAsync<UnSubscribeResponse>();
                }

                Assert.IsNotNull(responseObj2, "responseObj2 must to be created.");
                Assert.IsTrue(responseObj2.Success, "Success must to be TRUE.");
            } 
        }

        [TestMethod]
        public async Task Unsubscribe()
        {
            // Arrange
            UnSubscribeResponse responseObj2 = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServiceUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                // UnSubscribe
                HttpResponseMessage response = await client.DeleteAsync("api/hooks/26");

                if (response.IsSuccessStatusCode)
                {
                    responseObj2 = await response.Content.ReadAsAsync<UnSubscribeResponse>();
                }

                Assert.IsNotNull(responseObj2, "responseObj2 must to be created.");
                Assert.IsTrue(responseObj2.Success, "Success must to be TRUE.");
            }
        }
        


        [TestMethod]
        public async Task AutoProxy_GetOK()
        {
            // Arrange
            ZapServiceClient client = new ZapServiceClient();            
            String responseObj = null;

            // Act
            responseObj = await client.GetOKAsync();
            client.Close();

            // Assert
            Assert.IsTrue(responseObj.CompareTo("OK!!!") == 0, "responseObj must to be [OK!!!]...");
        }

        [TestMethod]
        public async Task AutoProxy_Subscribe()
        {
            // Arrange
            ZapServiceClient client = new ZapServiceClient();
            SubscribeRequest requestObj = new SubscribeRequest() { Event = "Trigger_H", Target_URL = @"http://test.com/asdf"};
            SubscribeResponse responseObj = null;
            
            // Act
            responseObj = await client.SubscribeAsync(requestObj);
            client.Close();

            // Assert
            Assert.IsNotNull(responseObj, "responseObj must to be created...");
            Assert.IsTrue(responseObj.Success, "Success must to be TRUE...");
            Assert.IsTrue(responseObj.SubscribeId > 0, "SubscribeId must to be bigger than 0...");
        }
    }
}
