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

        [Test]
        [Category("IntHashSetExtensions")]
        public void IntHashSet_Add() {
            var ihs = new IntHashSet();
            
            ihs.Add(2);
            ihs.Add(4);
            ihs.Add(6);
            ihs.Add(8);

            Assert.AreEqual(4, ihs.length);
        }
        
        [Test]
        [TestCase()]
        [Category("IntHashSetExtensions")]
        public void IntHashSet_Remove() {
            var ihs = new IntHashSet(32);
            
            ihs.Add(2);
            ihs.Add(4);
            ihs.Add(6);
            ihs.Add(8);

            Assert.AreEqual(4, ihs.length);

            ihs.Remove(8);
            Assert.AreEqual(3, ihs.length);
            
            ihs.Remove(6);
            Assert.AreEqual(2, ihs.length);
            
            ihs.Remove(5); //IntHashSet does not contain '5', so it should have the same length.
            Assert.True(ihs.length == 2);
        }
        
        [Test]
        [Category("IntHashSetExtensions")]
        public void IntHashSet_CopyTo() {
            var ihs = new IntHashSet(32);
            var arr = new int[32];

            Assert.DoesNotThrow(() => ihs.CopyTo(arr));
        }
        
        [Test]
        [Category("IntHashSetExtensions")]
        public void IntHashSet_Has() {
            var ihs = new IntHashSet(32);
            ihs.Add(2);
            
            Assert.True(ihs.Has(2));
            
            Assert.False(ihs.Has(3));
        }
        
        [Test]
        [Category("IntHashSetExtensions")]
        public void IntHashSet_Clear() {
            var ihs = new IntHashSet(32);
            ihs.Add(2);
            ihs.Add(6);
            ihs.Add(4);
            ihs.Add(8);
            
            Assert.False(ihs.length == 0);
            ihs.Clear();
            
            Assert.True(ihs.length == 0);
        }
        
        [Test]
        [Category("IntHashMap")]
        public void IntHashMap_Simple_Ctor() {
            Assert.DoesNotThrow(() => {
                var ihm = new IntHashMap<int>();
            });
        }
    }
}