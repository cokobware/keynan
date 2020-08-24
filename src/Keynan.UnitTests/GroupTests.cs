using System;
using Keynan.UnitTests.Example;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Keynan.UnitTests
{
    [TestClass]
    public class GroupTests
    {
        [TestMethod]
        public void SerializeGroup()
        {
            var testGroup = new ExampleConfigGroup();

            var json = testGroup.Serialize();

            Assert.IsNotNull(json);

        }

        [TestMethod]
        public void DeserializeGroup()
        {
            var testGroup = new ExampleConfigGroup();

            testGroup.FeatureA.Value = true;
            testGroup.HowManyVideos.Value = 500;
            testGroup.PickOne.Value = "Item #2";
            testGroup.PickAnother.Value = "Item #1";
            testGroup.EmailContact.Value = "demo@socyinc.com";

            var json = testGroup.Serialize();

            var testGroup2 = new ExampleConfigGroup
            {
                Configuration = json
            };

            testGroup2.Deserialize();

            Assert.AreEqual(testGroup.FeatureA.Value, testGroup2.FeatureA.Value);
            Assert.AreEqual(testGroup.HowManyVideos.Value, testGroup2.HowManyVideos.Value);
            Assert.AreEqual(testGroup.PickOne.Value, testGroup2.PickOne.Value);
            Assert.AreEqual(testGroup.PickAnother.Value, testGroup2.PickAnother.Value);
            Assert.AreEqual(testGroup.EmailContact.Value, testGroup2.EmailContact.Value);
        }


    }
}
