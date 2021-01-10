namespace Scellecs.Collections.TestSuite {
    using System.Collections;
    using System.Collections.Generic;
    using NUnit.Framework;
    using UnityEngine;
    using UnityEngine.TestTools;
    using System.Linq;

    public class MainFixture {
        [Test]
        [Category("IntHashSet")]
        public void IntHashSet_Simple_Ctor() {
            Assert.DoesNotThrow(() => {
                var ihs = new IntHashSet();
            });
        }
        
        [Test]
        [Category("IntHashSet")]
        public void IntHashSet_Simple_Ctor_With_Capacity() {
            var ihs = new IntHashSet(30);
            Assert.AreEqual(64, ihs.capacity);
        }
    }
}